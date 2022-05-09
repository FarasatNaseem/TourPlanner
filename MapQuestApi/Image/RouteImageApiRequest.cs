namespace MapQuestApi.Image
{
    public class RouteImageApiRequest
    {
        public RouteImageApiRequest(string imageWidth, string imageHeight, string from, string to)
        {
            this.Key = new APIKey();
            this.ImageWidth = imageWidth;
            this.ImageHeight = imageHeight;
            this.From = from;
            this.To = to;
        }

        public APIKey Key { get; }
        public string ImageWidth { get; }
        public string ImageHeight { get; }
        public string From { get; }
        public string To { get; }
    }
}
