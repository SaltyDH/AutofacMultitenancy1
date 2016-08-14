using System;
using Microsoft.AspNetCore.Http.Extensions;

namespace AutofacMultitenancy1
{
    public class TestMultitenancyContext
    {
        public object TenantId { get; }

        public TestMultitenancyContext()
        {
            var context = RequestMiddleware.Context;
            if (context == null)
                return;

            object tenantId;
            MultitenantIdentificationStrategy.TryIdentifyTenant(new Uri(context.Request.GetDisplayUrl()), out tenantId);
            TenantId = tenantId;
        }
    }
}