using System.Net;

namespace Core.Results;

public class Result
{
    public bool IsSuccess { get; }
    public string? Message { get; }
    public HttpStatusCode StatusCode { get; }

    public Result(bool isSuccess, HttpStatusCode statusCode, string? message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message;
    }
}

public class Result<T> : Result
{
    public T? Data { get; }

    public Result(bool isSuccess, HttpStatusCode statusCode, T? data = default, string? message = null)
        : base(isSuccess, statusCode, message)
    {
        Data = data;
    }
}