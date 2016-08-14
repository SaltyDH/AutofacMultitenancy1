using System;
using Microsoft.AspNetCore.Mvc;

namespace AutofacMultitenancy1.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestMultitenancyContext _multitenancy;

        public HomeController(TestMultitenancyContext multitenancy)
        {
            _multitenancy = multitenancy;
        }

        public IActionResult Index()
        {
            return Ok(_multitenancy.TenantId);
        }
    }
}
