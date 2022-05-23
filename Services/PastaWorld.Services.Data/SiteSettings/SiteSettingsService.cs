namespace PastaWorld.Services.Data.SiteSettings
{
    using System.Linq;
    using System.Threading.Tasks;

    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.SiteSetting;

    public class SiteSettingsService : ISiteSettingsService
    {
        private readonly IDeletableEntityRepository<SiteSetting> siteSetingRepository;

        public SiteSettingsService(IDeletableEntityRepository<SiteSetting> siteSetingRepository)
        {
            this.siteSetingRepository = siteSetingRepository;
        }

        public double GetDeliveryPrice()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.PriceDelivery).FirstOrDefault();

            return result;
        }

        public async Task SetDeliveryPrice( double deliveryPrice)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.PriceDelivery = deliveryPrice;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public int GetDeliveryTime()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.DeliveryTime).FirstOrDefault();

            return result;
        }

        public async Task SetDeliveryTime(int deliveryTime)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.DeliveryTime = deliveryTime;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetWorkingHours()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.WorkingHours).FirstOrDefault();

            return result;
        }

        public async Task SetWorkingHours(string workingHours)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.WorkingHours = workingHours;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetMol()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.Mol).FirstOrDefault();

            return result;
        }

        public async Task SetMol(string mol)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.Mol = mol;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetCompanyName()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.CompanyName).FirstOrDefault();

            return result;
        }

        public async Task SetCompanyName(string companyName)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.CompanyName = companyName;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetAddres()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.Address).FirstOrDefault();

            return result;
        }

        public async Task SetAddres(string addres)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.Address = addres;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetBulstat()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.Bulstat).FirstOrDefault();

            return result;
        }

        public async Task SetBulstat(string bulstat)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.Bulstat = bulstat;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetHomePageFirstImageTitle()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.HomePageImageTitle).FirstOrDefault();

            return result;
        }

        public async Task SetHomePageFirstImageTitle(string homePageFirstImageTitle)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.HomePageImageTitle = homePageFirstImageTitle;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetHomePageSecondImageTitle()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.HomePageSecondImageTitle).FirstOrDefault();

            return result;
        }

        public async Task SetHomePageSecondImageTitle(string homePageSecondImageTitle)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.HomePageSecondImageTitle = homePageSecondImageTitle;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetHomePageThirdImageTitle()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.HomePageThirdImageTitle).FirstOrDefault();

            return result;
        }

        public async Task SetHomePageThirdImageTitle(string homePageThirdImageTitle)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.HomePageThirdImageTitle = homePageThirdImageTitle;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        public string GetHomePageSubImageTitle()
        {
            var result = this.siteSetingRepository.All().Where(x => x.Id == 1).To<SiteSettingViewModel>().Select(x => x.HomePageSubImageTitle).FirstOrDefault();

            return result;
        }

        public async Task SetHomeHomePageSubImageTitle(string homePageSubImageTitle)
        {
            var siteSeting = this.siteSetingRepository.All().FirstOrDefault();

            siteSeting.HomePageSubImageTitle = homePageSubImageTitle;

            this.siteSetingRepository.Update(siteSeting);
            await this.siteSetingRepository.SaveChangesAsync();
        }

        //// Id	HomePageImageTitle	HomePageSecondImageTitle	HomePageThirdImageTitle	HomePageSubImageTitle
    }
}
