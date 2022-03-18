namespace PastaWorld.Web.ViewModels.Meals
{
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;

    public class BaseMealViewModel : IMapFrom<Meal>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }

        public string MainImagePath => "/images/meals/" + this.ImageName + ".jpg";
    }
}
