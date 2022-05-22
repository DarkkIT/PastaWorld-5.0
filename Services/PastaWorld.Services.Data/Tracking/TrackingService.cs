namespace PastaWorld.Services.Data.Tracking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PastaWorld.Common;
    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Orders;

    public class TrackingService : ITrackingService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Meal> mealRepository;
        private readonly IRepository<CartItem> carItemRepository;

        public TrackingService(IRepository<Order> orderRepository, IRepository<Meal> mealRepository, IRepository<CartItem> carIremRepository)
        {
            this.orderRepository = orderRepository;
            this.mealRepository = mealRepository;
            this.carItemRepository = carIremRepository;
        }

        public async Task ChangeOrderStatus(string newStatus, int orderId)
        {
            var order = this.orderRepository.All().FirstOrDefault(x => x.Id == orderId);

            order.Status = newStatus;

            this.orderRepository.Update(order);
            await this.orderRepository.SaveChangesAsync();
        }

        public IEnumerable<OrderTrackingViewModel> GetAllOrders<T>()
        {
            var orders = this.orderRepository.All().To<OrderTrackingViewModel>().ToList();

            return orders;
        }

        public IEnumerable<OrderTrackingViewModel> GetAllOrdersWithNoFinalizedStatus<T>()
        {
            var orders = this.orderRepository.All().OrderByDescending(x => x.CreatedOn).To<OrderTrackingViewModel>().Where(x => x.Status != GlobalConstants.Finalized).ToList();

            return orders;
        }

        public IEnumerable<OrderTrackingViewModel> GetAllUserOrders<T>(string userId)
        {
            var orders = this.orderRepository.All().Where(x => x.ClientId == userId).To<OrderTrackingViewModel>().ToList();

            return orders;
        }

        public OrderTrackingViewModel GetCurretUserOrder<T>(string userId)
        {
            var orders = this.orderRepository.All().OrderByDescending(x => x.CreatedOn).To<OrderTrackingViewModel>().FirstOrDefault(x => x.CliendId == userId);

            return orders;
        }

        public IEnumerable<OrderTrackingViewModel> GetOrdersByStatus<T>(string status)
        {
            var orders = this.orderRepository.All().OrderBy(x => x.CreatedOn).To<OrderTrackingViewModel>().Where(x => x.Status == status).ToList();

            foreach (var order in orders)
            {
                var counter = 1;
                var sb = new StringBuilder();
                foreach (var item in order.Items)
                {
                    sb.AppendLine(counter + ". " + item.Meal.Name + " - " + item.Quantity + " бр.");
                    counter++;
                }

                order.Meals = sb.ToString().TrimStart().TrimEnd();
            }

            return orders;
        }
    }
}
