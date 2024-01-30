namespace DTO.Package
{
    public enum StatusCode
    {
        // Success
        Found = 100,
        Success = 101,
        Generated = 104,

        // Failure
        NotFound = 200,
        UnSuccess = 201,

        // Exceptions
        knownException = 300,
    }
}