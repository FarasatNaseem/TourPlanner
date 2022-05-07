using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;
using TourPlanner.Model.DbSchema;
using TourPlanner.Server.DL.Config;

namespace TourPlanner.Server.DL.DB
{
    public class Database
    {
        private readonly DBConfigData _configData;
        public Database(string connectionString)
        {
            this._configData = JsonConvert.DeserializeObject<DBConfigData>(connectionString);
        }

        public (bool, string) AddTour(TourSchemaWithoutLog tourSchema)
        {
            using (IDbConnection connection = this.Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into tour values(@Id, @Name, @TourDescription, @From, @To, @Distance, @TransportType, @RouteImagePath, @EstimatedTime)";
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", this.AutoIncrement("tour")));
                    cmd.Parameters.Add(new NpgsqlParameter("@Name", tourSchema.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@TourDescription", tourSchema.TourDescription));
                    cmd.Parameters.Add(new NpgsqlParameter("@From", tourSchema.From));
                    cmd.Parameters.Add(new NpgsqlParameter("@To", tourSchema.To));
                    cmd.Parameters.Add(new NpgsqlParameter("@Distance", tourSchema.Distance));
                    cmd.Parameters.Add(new NpgsqlParameter("@TransportType", tourSchema.TransportType.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@RouteImagePath", tourSchema.RouteImage));
                    cmd.Parameters.Add(new NpgsqlParameter("@EstimatedTime", tourSchema.EstimatedTime));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return (false, "Tour cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return (true, "Tour has been added.");
            }
        }

        public (bool, string) AddTourLog(TourLogSchema tourLogSchema)
        {
            using (IDbConnection connection = this.Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into tourlog values(@Id, @TourId, @Datatime, @Comment, @Difficulty, @TotalDuration, @Rating)";
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", this.AutoIncrement("tourlog")));
                    cmd.Parameters.Add(new NpgsqlParameter("@TourId", tourLogSchema.TourId));
                    cmd.Parameters.Add(new NpgsqlParameter("@Datatime", tourLogSchema.DateTime.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@Comment", tourLogSchema.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@Difficulty", tourLogSchema.Difficulty.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@TotalDuration", tourLogSchema.TotalDuration.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@Rating", tourLogSchema.Rating.ToString()));

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return (false, "Tour log cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return (true, "Tour log has been added.");
            }
        }

        public (List<TourSchemaWithoutLog>, string) GetAllTour()
        {
            var tours = new List<TourSchemaWithoutLog>();

            using (IDbConnection connection = Connect())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.Connection = connection;
                cmd.CommandText = "Select * from tour";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0].ToString());
                    string name = reader[1].ToString();
                    string from = reader[3].ToString();
                    string to = reader[4].ToString();
                    string tourDescription = reader[2].ToString();
                    double distance = Convert.ToDouble(reader[5]);
                    string transportType = reader[6].ToString();
                    string imgPath = reader[7].ToString();
                    string timeSpan = reader[8].ToString();

                    tours.Add(new TourSchemaWithoutLog(id, name, from, to, tourDescription, TransportType.Bike, distance, imgPath, new TimeSpan()));
                }
                cmd.Dispose();
                connection.Close();
            }

            return (tours, "Tours are fetched successfully");
        }

        public (List<TourSchemaWithLog>, string) GetAllTourWithLogs()
        {
            var toursWithLog = new List<TourSchemaWithLog>();

            var tours = this.GetAllTour().Item1;

            foreach (var tour in tours)
            {
                toursWithLog.Add(new TourSchemaWithLog(tour.Id, tour.Name, tour.From, tour.To, tour.TourDescription, tour.TransportType, tour.Distance, tour.RouteImage, tour.EstimatedTime, this.GetTourLogsByID(tour.Id).Item1));
            }

            return (toursWithLog, "Tours with logs are fetched successfully");
        }

        public (List<TourLogSchema>, string) GetAllTourLogs()
        {
            var tourLogs = new List<TourLogSchema>();

            using (IDbConnection connection = Connect())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.Connection = connection;
                cmd.CommandText = "Select * from tourLog";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0].ToString());
                    int tourId = Convert.ToInt32(reader[1].ToString());
                    DateTime dateTime = Convert.ToDateTime(reader[2].ToString());
                    string comment = reader[3].ToString();
                    Difficulty difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), reader[4].ToString());
                    TimeSpan timespan = TimeSpan.Parse(reader[5].ToString());
                    Rating rating = (Rating)Enum.Parse(typeof(Rating), reader[6].ToString());

                    tourLogs.Add(new TourLogSchema(id, tourId, dateTime, comment, difficulty, timespan, rating));
                }
                cmd.Dispose();
                connection.Close();
            }

            return (tourLogs, "Tours are fetched successfully");
        }

        public (List<TourLogSchema>, string) GetTourLogsByID(int id)
        {
            try
            {
                var tourLogs = this.GetAllTourLogs().Item1;

                var sortedTourLogs = tourLogs.Where(x => x.TourId == id).ToList();

                return (sortedTourLogs, "Tour logs are fetched successfully");
            }
            catch (Exception ex)
            {
                return (null, "Due to some error logs cant be fetched.");
            }
        }


        private IDbConnection Connect()
        {
            return (new NpgsqlConnection($"Host={_configData.Host};Username={_configData.Username};Password={_configData.Password};Database={_configData.Database}"));
        }

        // Finished.
        private int AutoIncrement(string tableName)
        {

            return this.GetLastId(tableName) + 1;
        }

        // Finished.
        private int GetLastId(string tableName)
        {
            int id = 0;
            using (IDbConnection connection = Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = $"Select * from {tableName}";
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        id = Convert.ToInt32((reader[0].ToString()));
                    }
                    cmd.Dispose();

                    return id;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
