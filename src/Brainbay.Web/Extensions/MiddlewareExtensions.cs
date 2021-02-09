using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainbay.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseResponseHeader(this IApplicationBuilder app, string name, string value)
        {
            return app.Use(async (context, nextMiddleware) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add(name, value);
                    return Task.FromResult(0);
                });
                await nextMiddleware();
            });
        }
    }
}
