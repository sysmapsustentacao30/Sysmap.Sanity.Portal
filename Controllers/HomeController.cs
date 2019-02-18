using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sysmap.Portal.Sanity.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "All-Admin,All-User")]
        public IActionResult Home()
        {
            return View();
        }
    }
}