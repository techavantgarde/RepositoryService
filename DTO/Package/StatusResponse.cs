namespace DTO.Package
{
    public class StatusResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public StatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public StatusResponse(bool success, T data, StatusCode statusCode, Exception? exception)
        {
            Success = success;
            Data = data;
            StatusCode = statusCode;
            if (exception != null)
            {
                StatusMessage = Package.StatusMessage.GetMessage(statusCode, ExceptionHandler.FormatExceptionsDetails(exception));
            }
            else
            {
                StatusMessage = Package.StatusMessage.GetMessage(statusCode, null);
            }
        }

        // Factory methods for success/failure
        public static StatusResponse<T> SuccessStatus(T data, StatusCode statusCode)
        {
            return new StatusResponse<T>(true, data, statusCode, null);
        }

        public static StatusResponse<T> FailureStatus(StatusCode statusCode, Exception exception)
        {
            return new StatusResponse<T>(false, default!, statusCode, exception);
        }
    }
}
