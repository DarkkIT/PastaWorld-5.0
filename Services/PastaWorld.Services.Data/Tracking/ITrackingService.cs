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
        IEnumerable<OrderViewModel> GetAllOrders<T>();

        IEnumerable<OrderViewModel> GetAllUserOrders<T>(string userId);

        OrderViewModel GetCurretUserOrder<T>(string userId);

        IEnumerable<OrderViewModel> GetOrdersByStatus<T>(string status);

        IEnumerable<OrderViewModel> GetAllOrdersWithNoFinalizedStatus<T>();

        Task ChangeOrderStatus(string newStatus, int orderId);
    }
}
