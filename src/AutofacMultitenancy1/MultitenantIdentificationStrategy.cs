using System;
using Autofac.Multitenant;
using Microsoft.AspNetCore.Http.Extensions;

namespace AutofacMultitenancy1
{
    public class MultitenantIdentificationStrategy : ITenantIdentificationStrategy
    {
        public const string DefaultTenantId = null;

        public bool TryIdentifyTenant(out object tenantId)
        {
            var context = RequestMiddleware.Context;
            tenantId = DefaultTenantId;

            if (context == null)
                return false;

            return GetTenantId(new Uri(context.Request.GetEncodedUrl()), out tenantId);
        }

        public static bool TryIdentifyTenant(Uri uri, out object tenantId)
        {
            return GetTenantId(uri, out tenantId);
        }

        private static bool GetTenantId(Uri uri, out object tenantId)
        {
            tenantId = DefaultTenantId;

            var host = uri.Host;
            var firstSegment = host.IndexOf(".", StringComparison.Ordinal);

            if (firstSegment <= 0)
                return false;

            tenantId = host.Substring(0, firstSegment);
            Console.WriteLine($"TenantId: {tenantId}");
            return true;
        }
    }
}