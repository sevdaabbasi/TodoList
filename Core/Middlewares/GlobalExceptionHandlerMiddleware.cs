using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using UnauthorizedAccessException = System.UnauthorizedAccessException;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (TodoNotFoundException ex)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, ex.Message);
        }
        catch (CategoryNotFoundException ex)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.Forbidden, ex.Message);
        }
        catch (ValidationException ex)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
        }
    }

    private Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(new { message }.ToString());
    }
}