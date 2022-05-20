namespace PastaWorld.Data.Models
{
    using PastaWorld.Data.Common.Models;

    public class SiteSetting : BaseDeletableModel<int>
    {
        public string HomePageImageTitle { get; set; }

        public string HomePageSecondImageTitle { get; set; }

        public string HomePageThirdImageTitle { get; set; }

        public string HomePageSubImageTitle { get; set; }

        public double PriceDelivery { get; set; }

        public string WorkingHours { get; set; }

        public int DeliveryTime { get; set; }

        public string Address { get; set; }

        public string Mol { get; set; }

        public string Bulstat { get; set; }

        public string CompanyName { get; set; }
    }
}
