namespace TourPlanner.FileSystem.JSON
{
    using Logging;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TourPlanner.FileSystem.Handler;

    public class JSONFileHandler : IFileHandler
    {
        private readonly ILogger logger = Logger.CreateLogger<IFileHandler>();

        public async Task<(string, string)> Read(string filePath)
        {
            try
            {
                var data = await File.ReadAllTextAsync(filePath).ConfigureAwait(false);
                
                logger.Log(LogLevel.Debug, $"Data from file {filePath} is being fetched");

                return (data, "File data has been fetched successfully.");
            }
            catch (JsonException jsonEx)
            {
                logger.Log(LogLevel.Error, jsonEx.StackTrace);
                
                return (null, "Invalid data given.");
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex.StackTrace);
                
                return (null, "Could not read data from file.");
            }
        }


        public async Task<(bool, string)> Write(string filePath, string serializedData)
        {
            try
            {
                await File.WriteAllTextAsync(filePath, serializedData);

                logger.Log(LogLevel.Debug, $"Data in file {filePath} is being written");

                return (true, "Data has been written in the given file path");
            }
            catch (JsonException jsonEx)
            {
                logger.Log(LogLevel.Warning, jsonEx.StackTrace);
                return (false, "Could not write data in given path!\nPlease try again later.");
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Warning, ex.StackTrace);
                return (false, "Could not write data in given path!");
            }
        }
    }
}
