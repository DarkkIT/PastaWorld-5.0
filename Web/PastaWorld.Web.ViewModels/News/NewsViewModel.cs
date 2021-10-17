namespace PastaWorld.Web.ViewModels.News
{
    using System;

    using AutoMapper;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;

    public class NewsViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime NewsDate { get; set; }

        public string Publisher { get; set; }

        public string ImageName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public string MainImagePath => "/images/news/" + this.ImageName + ".jpg";

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<News, NewsViewModel>().ForMember(
                m => m.Publisher,
                opt => opt.MapFrom(x => x.ApplicationUser.UserName));
        }
    }
}
