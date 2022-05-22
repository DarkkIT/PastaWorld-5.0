namespace PastaWorld.Services.Data.Tracking
{
    using PastaWorld.Data.Models;
    using PastaWorld.Web.ViewModels.Orders;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITrackingService
    {
        IEnumerable<OrderTrackingViewModel> GetAllOrders<T>();

        IEnumerable<OrderTrackingViewModel> GetAllUserOrders<T>(string userId);

        OrderTrackingViewModel GetCurretUserOrder<T>(string userId);

        IEnumerable<OrderTrackingViewModel> GetOrdersByStatus<T>(string status);

        IEnumerable<OrderTrackingViewModel> GetAllOrdersWithNoFinalizedStatus<T>();

        Task ChangeOrderStatus(string newStatus, int orderId);
    }
}
