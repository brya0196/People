using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace People.Web.Controllers.Views
{
    public class ResidenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}