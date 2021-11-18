namespace PastaWorld.Web.ViewModels.Meals
{
    using System.Collections.Generic;

    public class MealListViewModel : PagingViewModel
    {
        public IEnumerable<MealViewModel> MealList { get; set; }

        public string TypeName { get; set; }

        public string PageName { get; set; }
    }
}
