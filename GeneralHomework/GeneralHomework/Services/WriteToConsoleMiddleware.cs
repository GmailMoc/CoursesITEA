using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class WriteToConsoleMiddleware
    {
        public readonly RequestDelegate _next;
        private readonly string _str;

        public WriteToConsoleMiddleware(RequestDelegate next, string str)
        {
            _next = next;
            _str = str;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"{_str}. Before");
            await _next(context);
            Console.WriteLine($"{_str}. After");
        }
    }
}
