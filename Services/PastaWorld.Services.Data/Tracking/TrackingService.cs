namespace PastaWorld.Services.Data.Tracking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PastaWorld.Common;
    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.Orders;

    public class TrackingService : ITrackingService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Meal> mealRepository;

        public TrackingService(IRepository<Order> orderRepository, IRepository<Meal> mealRepository)
        {
            this.orderRepository = orderRepository;
            this.mealRepository = mealRepository;
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
            var orders = this.orderRepository.All().OrderByDescending(x => x.CreatedOn).To<OrderViewModel>().FirstOrDefault(x => x.CliendId == userId);

            return orders;
        }

        public IEnumerable<OrderViewModel> GetOrdersByStatus<T>(string status)
        {
            var orders = this.orderRepository.All().OrderByDescending(x => x.CreatedOn).To<OrderViewModel>().Where(x => x.Status == status).ToList();

            return orders;
        }
    }
}
