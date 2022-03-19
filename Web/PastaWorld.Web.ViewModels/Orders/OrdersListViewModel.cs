namespace PastaWorld.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OrdersListViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
