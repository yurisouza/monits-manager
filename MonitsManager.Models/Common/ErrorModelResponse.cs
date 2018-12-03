namespace MonitsManager.Models.Common
{
    public class ErrorModelResponse
    {
        public ErrorModelResponse(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
