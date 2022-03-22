using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastaWorld.Web.Controllers
{
    public class AllMenuController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
