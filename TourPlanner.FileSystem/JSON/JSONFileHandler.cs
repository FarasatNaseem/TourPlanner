namespace TourPlanner.FileSystem.JSON
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using TourPlanner.FileSystem.Handler;

    public class JSONFileHandler : IFileHandler
    {
        public string Read(string filePath)
        {
            try
            {
                JObject fileData = null;

                using (StreamReader file = File.OpenText(filePath))

                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    fileData = (JObject)JToken.ReadFrom(reader);
                }

                return fileData.ToString(Formatting.None);
            }
            catch (Exception)
            {
                return filePath;
            }
        }

        public void Write(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
