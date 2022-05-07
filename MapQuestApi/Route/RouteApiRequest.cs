namespace MapQuestApi.Route
{
    public class RouteApiRequest
    {
        public RouteApiRequest(string from, string to)
        {
            this.Key = new APIKey();
            this.From = from;
            this.To = to;
        }

        public APIKey Key { get; }
        public string From { get; }
        public string To { get; }
    }
}
