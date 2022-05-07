namespace TourPlanner.Server.DL.Config
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
}
