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
using Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace TourPlanner.Server.DL.DB
{
    public class Database
    {
        private readonly DBConfigData _configData;
        private readonly ILogger logger = Logger.CreateLogger<Database>();

        public Database(IConfiguration config)
        {
            var section = config.GetSection(nameof(DBConfigData));

            this._configData = section.Get<DBConfigData>();
        }

        public (bool, string) AddTour(TourSchemaWithoutLog tourSchema)
        {
            var tour = this.GetTourByName(tourSchema.Name);

            if (!(tour.Item1 is null))
            {
                return (false, "Tour cant be added.");
            }


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

                    logger.Log(LogLevel.Information, $"Tour data with name {tourSchema.Name} has been added successfully");
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.StackTrace);
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

                    logger.Log(LogLevel.Information, $"Tour log data with tour id { tourLogSchema.TourId} has been added successfully");
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.StackTrace);

                    return (false, "Tour log cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return (true, "Tour log has been added.");
            }
        }

        public (bool, string) StoreBackup(List<TourSchemaWithLog> tours)
        {
            try
            {
                var storeTourResult = this.StoreTours(tours);
                var storeTourLogResult = this.StoreTourLogs(tours);

                return (true, "Tours data has been imported.");
            }
            catch (Exception ex)
            {
                // log.
            }

            return (false, "Tours data cant be imported.");
        }

        private (bool, string) StoreTours(List<TourSchemaWithLog> tours)
        {
            bool isFound = false;

            var oldToursFromDB = this.GetAllTourWithLogs();

            try
            {
                foreach (var newTour in tours)
                {
                    if (oldToursFromDB.Item1.Count > 0)
                    {
                        isFound = oldToursFromDB.Item1.All(x => x.Name == newTour.Name);
                    }

                    if (!isFound)
                    {
                        var tourRes = this.AddTour(newTour);
                    }

                    isFound = false;
                }

                return (true, "Tours data has been imported.");
            }
            catch (Exception ex)
            {
                // log.
            }

            return (false, "Tours data cant be imported.");
        }

        private (bool, string) StoreTourLogs(List<TourSchemaWithLog> tours)
        {
            bool isFound = false;

            var oldTourLogsFromDB = this.GetAllTourLogs();

            try
            {
                for (int i = 0; i < tours.Count; i++)
                {
                    foreach (var log in tours[i].Logs)
                    {
                        if (oldTourLogsFromDB.Item1.Count > 0)
                        {
                            isFound = oldTourLogsFromDB.Item1.All(x => x.Id == log.Id && x.TourId == log.TourId);
                        }

                        if (!isFound)
                        {
                            var tourLogResult = this.AddTourLog(log);
                        }

                        isFound = false;
                    }
                }


                return (true, "Tour log data has been imported.");
            }
            catch (Exception ex)
            {
                // log.
            }

            return (false, "Tour log data cant be imported.");
        }

        public (bool, string) AddReview(ReviewSchema reviewSchema)
        {
            using (IDbConnection connection = this.Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into review values(@id, @name, @feedback)";
                    cmd.Parameters.Add(new NpgsqlParameter("@id", this.AutoIncrement("review")));
                    cmd.Parameters.Add(new NpgsqlParameter("@name", reviewSchema.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@feedback", reviewSchema.Feedback));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    logger.Log(LogLevel.Information, $"Review has been added successfully");
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.StackTrace);

                    return (false, "Review cant be added.");
                }
                finally
                {
                    connection.Close();
                }

                return (true, "Review has been added.");
            }
        }
        public (List<ReviewSchema>, string) GetAllReview()
        {
            var reviews = new List<ReviewSchema>();

            using (IDbConnection connection = Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();

                    cmd.Connection = connection;
                    cmd.CommandText = "Select * from review";
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = reader[1].ToString();
                        string feedback = reader[2].ToString();

                        reviews.Add(new ReviewSchema(name, feedback));
                    }
                    cmd.Dispose();

                    logger.Log(LogLevel.Information, "Reviews been fetched successfully");
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.StackTrace);
                    return (reviews, "reviews cant be fetched");
                }
                finally
                {
                    connection.Close();
                }
            }

            return (reviews, "Tours are fetched successfully");
        }

        public (List<TourSchemaWithoutLog>, string) GetAllTourWithoutLog()
        {
            var tours = new List<TourSchemaWithoutLog>();

            using (IDbConnection connection = Connect())
            {
                try
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
                        TimeSpan timeSpan = TimeSpan.Parse(reader[8].ToString());

                        tours.Add(new TourSchemaWithoutLog(id, name, from, to, tourDescription, TransportType.Bike, distance, imgPath, timeSpan));
                    }
                    cmd.Dispose();

                    logger.Log(LogLevel.Information, "Tours data has been fetched successfully");

                    return (tours, "Tours are fetched successfully");
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.StackTrace);
                    return (tours, "Tours data cant be fetched");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public (TourSchemaWithoutLog, string) GetTourById(int id)
        {
            var tour = this.GetAllTourWithoutLog().Item1.Where(x => x.Id == id).First();
            return (tour, "Tour data is fetched successfully");
        }

        public (TourSchemaWithoutLog, string) GetTourByName(string name)
        {
            var tour = this.GetAllTourWithoutLog().Item1.Where(x => x.Name == name).FirstOrDefault();
            return (tour, "Tour data is fetched successfully");
        }

        public (bool, string) UpdateTour(TourSchemaWithoutLog tourSchema)
        {
            using (IDbConnection connection = Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update tour set \"Name\"=@name, \"TourDescription\"=@tourDescription, \"From\"=@from, \"To\"=@to, \"Distance\"=@distance, \"TransportType\"=@transportType, \"RouteImagePath\"=@routeImagePath, \"EstimatedTime\"=@estimatedTime  WHERE \"Id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", tourSchema.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@name", tourSchema.Name));
                    cmd.Parameters.Add(new NpgsqlParameter("@tourDescription", tourSchema.TourDescription));
                    cmd.Parameters.Add(new NpgsqlParameter("@from", tourSchema.From));
                    cmd.Parameters.Add(new NpgsqlParameter("@to", tourSchema.To));
                    cmd.Parameters.Add(new NpgsqlParameter("@distance", tourSchema.Distance));
                    cmd.Parameters.Add(new NpgsqlParameter("@transportType", tourSchema.TransportType.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@routeImagePath", tourSchema.RouteImage));
                    cmd.Parameters.Add(new NpgsqlParameter("@estimatedTime", tourSchema.EstimatedTime));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (true, "Tour data is updated");
            }
        }
        public (bool, string) UpdateTourLog(TourLogSchema tourLogSchema)
        {
            using (IDbConnection connection = Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "update tourlog set \"Datetime\"=@datatime, \"Comment\"=@comment, \"Difficulty\"=@difficulty, \"TotalDuration\"=@totalDuration, \"Rating\"=@rating WHERE \"Id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", tourLogSchema.Id));
                    cmd.Parameters.Add(new NpgsqlParameter("@datatime", tourLogSchema.DateTime.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@comment", tourLogSchema.Comment));
                    cmd.Parameters.Add(new NpgsqlParameter("@difficulty", tourLogSchema.Difficulty.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@totalDuration", tourLogSchema.TotalDuration.ToString()));
                    cmd.Parameters.Add(new NpgsqlParameter("@rating", tourLogSchema.Rating.ToString()));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (true, "Tour log data is updated");
            }
        }

        public (List<TourSchemaWithLog>, string) GetAllTourWithLogs()
        {
            var toursWithLog = new List<TourSchemaWithLog>();

            var tours = this.GetAllTourWithoutLog().Item1;

            foreach (var tour in tours)
            {
                toursWithLog.Add(new TourSchemaWithLog(tour.Id, tour.Name, tour.From, tour.To, tour.TourDescription, tour.TransportType, tour.Distance, tour.RouteImage, tour.EstimatedTime, this.GetTourLogsByTourID(tour.Id).Item1));
            }

            logger.Log(LogLevel.Information, $"Tours data with logs has been fetched successfully");

            return (toursWithLog, "Tours with logs are fetched successfully");
        }

        public (List<TourLogSchema>, string) GetAllTourLogs()
        {
            var tourLogs = new List<TourLogSchema>();

            using (IDbConnection connection = Connect())
            {
                try
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
                    logger.Log(LogLevel.Information, "Tour log data has been fetched successfully");
                }
                catch (Exception ex)
                {
                    logger.Log(LogLevel.Error, ex.StackTrace);
                }
                finally
                {
                    connection.Close();
                }
            }

            return (tourLogs, "Tours are fetched successfully");
        }

        public (List<TourLogSchema>, string) GetTourLogsByTourID(int id)
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

        public (TourLogSchema, string) GetTourLogByID(int id)
        {
            try
            {
                var tourLog = this.GetAllTourLogs().Item1.Where(x => x.Id == id).ToList();

                TourLogSchema tourLogSchema = null;

                foreach (var item in tourLog)
                {
                    tourLogSchema = new TourLogSchema(item.Id, item.TourId, item.DateTime, item.Comment, item.Difficulty, item.TotalDuration, item.Rating);
                }

                return (tourLogSchema, "Tour log is fetched successfully");
            }
            catch (Exception ex)
            {
                return (null, "Due to some error log cant be fetched.");
            }
        }

       

        public (List<TourSchemaWithLog>, string) FilterTours(string someText)
        {
            if (someText.Length == 0)
            {
                return this.GetAllTourWithLogs();
            }

            var toursWithLog = new List<TourSchemaWithLog>();

            var tours = this.GetAllTourWithoutLog().Item1;

            var filteredTours = tours.Where(x => x.Name.Contains(someText)).ToList();

            if (filteredTours.Count != 0)
            {
                foreach (var tour in filteredTours)
                {
                    toursWithLog.Add(new TourSchemaWithLog(tour.Id, tour.Name, tour.From, tour.To, tour.TourDescription, tour.TransportType, tour.Distance, tour.RouteImage, tour.EstimatedTime, this.GetTourLogsByTourID(tour.Id).Item1));
                }

                return (toursWithLog, "Sorted Tours with logs are fetched successfully");
            }

            return (null, $"Nothing is found like {someText}");
        }

        public (List<TourLogSchema>, string) FilterTourLogs(string someText, int id)
        {
            try
            {
                var tourLogs = this.GetAllTourLogs().Item1;

                if (someText.Length == 0 || someText == "empty")
                {
                    return (tourLogs.Where(x => x.TourId == id).ToList(), $"Sorted Tour logs of id {id} are fetched successfully");
                }

                var filteredTourLogs = tourLogs.Where(x => x.Comment.Contains(someText) && x.TourId == id).ToList();

                return (filteredTourLogs, $"Sorted Tour logs of id {id} are fetched successfully");
            }
            catch
            {
                return (null, $"Nothing is found like {someText}");
            }
        }

        public (bool, string) DeleteTourById(int id)
        {
            using (IDbConnection connection = Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM tour WHERE \"Id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return (false, "Tour cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return (true, "Tour is deleted successfully");
        }

        public (bool, string) DeleteTourLogById(int id)
        {
            using (IDbConnection connection = Connect())
            {
                try
                {
                    connection.Open();
                    IDbCommand cmd = connection.CreateCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM tourlog WHERE \"Id\"=@id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    return (false, "Tour log cant be deleted!");
                }
                finally
                {
                    connection.Close();
                }
            }

            return (true, "Tour log is deleted successfully");
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
                        if (Convert.ToInt32((reader[0].ToString())) > id)
                        {
                            id = Convert.ToInt32((reader[0].ToString()));
                        }
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
