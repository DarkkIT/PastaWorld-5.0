using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastaWorld.Web.Controllers
{
    public class AllMenuController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
