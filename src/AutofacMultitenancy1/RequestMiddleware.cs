using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AutofacMultitenancy1
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly AsyncLocal<HttpContext> _context = new AsyncLocal<HttpContext>();

        public static HttpContext Context => _context.Value;

        public RequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _context.Value = context;
                await _next(context);
            }
            finally
            {
                _context.Value = null;
            }
        }
    }
}