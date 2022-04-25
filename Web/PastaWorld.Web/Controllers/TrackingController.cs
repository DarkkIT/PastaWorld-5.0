namespace PastaWorld.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PastaWorld.Common;
    using PastaWorld.Services.Data.Tracking;
    using PastaWorld.Web.ViewModels.Orders;

    public class TrackingController : BaseController
    {
        private readonly ITrackingService trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            this.trackingService = trackingService;
        }

        public IActionResult UserTracking()
        {
            return this.View();
        }

        public IActionResult AdminTrackingAll()
        {
            var orders = this.trackingService.GetAllOrdersWithNoFinalizedStatus<OrderViewModel>();

            var viewModel = new OrdersListViewModel { Orders = orders };

            return this.View(viewModel);
        }

        public IActionResult AdminTrackingAccepted()
        {
            var orders = this.trackingService.GetOrdersByStatus<OrderViewModel>(GlobalConstants.Accepted);

            var viewModel = new OrdersListViewModel { Orders = orders };

            return this.View(viewModel);
        }

        public IActionResult AdminTrackingCooked()
        {
            var orders = this.trackingService.GetOrdersByStatus<OrderViewModel>(GlobalConstants.Cooked);

            var viewModel = new OrdersListViewModel { Orders = orders };

            return this.View(viewModel);
        }

        public IActionResult AdminTrackingOnRoad()
        {
            var orders = this.trackingService.GetOrdersByStatus<OrderViewModel>(GlobalConstants.OnRoad);

            var viewModel = new OrdersListViewModel { Orders = orders };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ChangeStatus(string status, int orderId)
        {
            await this.trackingService.ChangeOrderStatus(status, orderId);

            if (status == "Cooked")
            {
                return this.RedirectToAction("AdminTrackingAccepted");
            }
            else if (status == "OnRoad")
            {
                return this.RedirectToAction("AdminTrackingCooked");
            }
            else if (status == "Delivered")
            {
                return this.RedirectToAction("AdminTrackingOnRoad");
            }
            else
            {
                return this.RedirectToAction("AdminTrackingAll");
            }
        }
    }
}
