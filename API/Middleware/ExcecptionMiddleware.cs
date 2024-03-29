﻿using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ExcecptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcecptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExcecptionMiddleware(RequestDelegate next, ILogger<ExcecptionMiddleware> logger,IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment() 
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);
                //var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
