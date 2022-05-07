using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TourPlanner.Model;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Rough
{

    public class DBConfigData
    {
        public DBConfigData(string host, string username, string password, string database)
        {
            this.Host = host;
            this.Username = username;
            this.Password = password;
            this.Database = database;
        }

        public string Host
        {
            get;
        }

        public string Username
        {
            get;
        }

        public string Password
        {
            get;
        }

        public string Database
        {
            get;
        }
    }
    class Program
    {
        private static IDbConnection Connect()
        {
            // deserialize JSON directly from a file
            //using (StreamReader file = File.OpenText(@"C:\Users\Privat\source\repos\TourPlanner\TourPlanner.Server.DL\Config\TourPlannerDbConfig.json"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    JObject o2 = (JObject)JToken.ReadFrom(reader);
            //}

            DBConfigData configData = JsonConvert.DeserializeObject<DBConfigData>(File.ReadAllText(@"C:\Users\Privat\source\repos\TourPlanner\TourPlanner.Server.DL\Config\TourPlannerDbConfig.json"));
            return new NpgsqlConnection($"Host={configData.Host};Username={configData.Username};Password={configData.Password};Database={configData.Database}");
        }

        private static int AutoIncrement(string tableName)
        {
            return GetLastId(tableName) + 1;
        }

        // Finished.
        private static int GetLastId(string tableName)
        {
            int id = 0;
            using (IDbConnection connection = Connect())
            {
                connection.Open();
                IDbCommand cmd = connection.CreateCommand();

                cmd.Connection = connection;
                cmd.CommandText = $"Select id from {tableName}";
                NpgsqlDataReader reader = (NpgsqlDataReader)cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32((reader[0].ToString()));
                }
                cmd.Dispose();
                connection.Close();
                //Console.WriteLine($"Package last id is {id}");
                return id;
            }
        }



        public static void SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }

        static void Main(string[] args)
        {
            //AddTour();
            var uri = new Uri("https://open.mapquestapi.com/staticmap/v5/map?start=Vienna,AT&end=Klagenfurt,AT&size=600,400@2x&key=kmzagLUfOds5SBeFiVMOjG1wnCjXWVnm");
            string outputPath = @"C:\Users\Privat\source\repos\tourimg1.png";

            //var locations = new Location("Vienna", "Graz");
            //var options = new List<string>();
            //options.Add("")


            //using (WebClient client = new WebClient())
            //{
            //    client.DownloadFileAsync(uri, outputPath);
            //}

            //            try
            //            {
            //                SaveImage(uri.ToString(), outputPath, ImageFormat.Png);
            //}
            //            catch (ExternalException ex)
            //            {
            //                // Something is wrong with Format -- Maybe required Format is not 
            //                // applicable here
            //            }
            //            catch (ArgumentNullException)
            //            {
            //                // Something wrong with Stream
            //}
        }
    }
}
