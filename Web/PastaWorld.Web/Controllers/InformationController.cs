namespace PastaWorld.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class InformationController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
