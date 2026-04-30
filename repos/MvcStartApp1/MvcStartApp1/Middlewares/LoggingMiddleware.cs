using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MvcStartApp1.Data.Interfaces;
using MvcStartApp1.Models.Db;

namespace MvcStartApp1.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IRequestLogRepository logRepository)
        {
            var requestLog = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"{context.Request.Method} {context.Request.Path}{context.Request.QueryString}"
            };
            _ = Task.Run(async () =>
            {
                try
                {
                    await logRepository.LogRequestAsync(requestLog);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LoggingMiddleware] Error: {ex.Message}");
                }
            });
            await _next(context);
        }
    }
}
