namespace PastaWorld.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PastaWorld.Services.Data.Tracking;
    using PastaWorld.Web.ViewModels.Orders;

    public class TrackingController : Controller
    {
        private readonly ITrackingService trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            this.trackingService = trackingService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AdminIndex()
        {
            var orders = this.trackingService.GetAllOrdersWithNoFinalizedStatus<OrderViewModel>();

            var viewModel = new OrdersListViewModel { Orders = orders };

            return this.View(viewModel);
        }
    }
}
