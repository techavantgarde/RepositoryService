namespace Shared.DTO.Package
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public APIResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        // Factory methods for success/failure
        public static APIResponse<T> SuccessResponse(T data, string message = "")
        {
            return new APIResponse<T>(true, message, data);
        }

        public static APIResponse<T> FailureResponse(string message)
        {
            return new APIResponse<T>(false, message, default!);
        }
    }

}