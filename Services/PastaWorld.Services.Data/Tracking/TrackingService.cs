namespace PastaWorld.Services.Data.Tracking
{
    using PastaWorld.Common;
    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.Orders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TrackingService : ITrackingService
    {
        private readonly IRepository<Order> orderRepository;

        public TrackingService(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task ChangeOrderStatus(string newStatus, int orderId)
        {
            var order = this.orderRepository.All().FirstOrDefault(x => x.Id == orderId);

            order.Status = newStatus;

            this.orderRepository.Update(order);
            await this.orderRepository.SaveChangesAsync();
        }

        public IEnumerable<OrderViewModel> GetAllOrders<T>()
        {
            var orders = this.orderRepository.All().To<OrderViewModel>().ToList();

            return orders;
        }

        public IEnumerable<OrderViewModel> GetAllOrdersWithNoFinalizedStatus<T>()
        {
            var orders = this.orderRepository.All().OrderByDescending(x => x.CreatedOn).To<OrderViewModel>().Where(x => x.Status != GlobalConstants.Finalized).ToList();

            return orders;
        }

        public IEnumerable<OrderViewModel> GetAllUserOrders<T>(string userId)
        {
            var orders = this.orderRepository.All().Where(x => x.ClientId == userId).To<OrderViewModel>().ToList();

            return orders;
        }

        public OrderViewModel GetCurretUserOrder<T>(string userId)
        {
            var orders = this.orderRepository.All().OrderByDescending(x => x.CreatedOn).To<OrderViewModel>().FirstOrDefault(x => x.ClientId == userId);

            return orders;
        }

        public IEnumerable<OrderViewModel> GetOrdersByStatus<T>(string status)
        {
            var orders = this.orderRepository.All().OrderByDescending(x => x.CreatedOn).To<OrderViewModel>().Where(x => x.Status == status);

            return orders;
        }
    }
}
