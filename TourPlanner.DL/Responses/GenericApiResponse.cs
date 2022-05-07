namespace TourPlanner.Client.DL.Responses
{
    public class GenericApiResponse
    {
        public GenericApiResponse(string responseMessage, object data, bool isCorrectlyResponded)
        {
            this.ResponseMessage = responseMessage;
            this.Data = data;
            this.IsCorrectlyResponded = isCorrectlyResponded;
        }

        public string ResponseMessage { get; }
        public object Data { get; }
        public bool IsCorrectlyResponded { get; }
    }
}