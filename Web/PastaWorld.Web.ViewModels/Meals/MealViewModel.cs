namespace PastaWorld.Web.ViewModels.Meals
{
    using System;

    using AutoMapper;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;

    public class MealViewModel : IMapFrom<Meal>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public DateTime NewsDate { get; set; }

        public string Publisher { get; set; }

        public string ImageName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public string MainImagePath => "/images/meals/" + this.ImageName + ".jpg";
    }
}
