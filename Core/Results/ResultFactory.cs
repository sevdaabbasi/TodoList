using System.Net;

namespace Core.Results;

public static class ResultFactory
{
    public static Result Success(HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null) =>
        new Result(true, statusCode, message);

    public static Result Failure(HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "Operation failed.") =>
        new Result(false, statusCode, message);

    public static Result<T> Success<T>(T data, HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null) =>
        new Result<T>(true, statusCode, data, message);

    public static Result<T> Failure<T>(T data, HttpStatusCode statusCode = HttpStatusCode.BadRequest, string message = "Operation failed.") =>
        new Result<T>(false, statusCode, default, message);
}