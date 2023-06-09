namespace TextAnalyticsService.Helper
{
    public class ResponseResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }

        public static ResponseResult Successs(string message, object responseObject)
        {
            return new ResponseResult { IsSuccess=true,Message = message,Result = responseObject };
        }
        public static ResponseResult Fail(string message)
        {
            return new ResponseResult { IsSuccess = false, Message = message, Result = null };
        }
    }
}
