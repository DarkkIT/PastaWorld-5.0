namespace PastaWorld.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class OrdersListViewModel
    {
        public IEnumerable<OrderTrackingViewModel> Orders { get; set; }
    }
}
