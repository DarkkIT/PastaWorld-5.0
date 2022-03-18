namespace PastaWorld.Web.ViewModels.Meals
{
    using System;

    using AutoMapper;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;

    public class MealViewModel : BaseMealViewModel, IMapFrom<Meal>
    {

        public string Description { get; set; }

        public string Type { get; set; }

        public bool IsTop { get; set; }

        public DateTime NewsDate { get; set; }

        public string Publisher { get; set; }

        public string ImageName { get; set; }

        public string MainImagePath => "/images/meals/" + this.ImageName + ".jpg";

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

    }
}
