namespace DTO.Package
{
    public static class StatusMessage
    {
        public static string GetMessage(StatusCode statusCode, string? exception)
        {
            switch (statusCode)
            {
                // Success
                case StatusCode.Found:
                    return "Content Found";
                case StatusCode.Success:
                    return "Operation Successful";
                case StatusCode.Generated:
                    return "Content Generated";

                // Failure
                case StatusCode.NotFound:
                    return "Content Not Found";
                case StatusCode.UnSuccess:
                    return "Operation Unsuccessful";

                // Exceptions
                case StatusCode.knownException:
                    if (exception != null)
                    {
                        return exception;
                    }
                    else
                    {
                        return "Unknown exception";
                    }

                // Default
                default:
                    return "Unknown Status Code";
            }
        }
    }
}