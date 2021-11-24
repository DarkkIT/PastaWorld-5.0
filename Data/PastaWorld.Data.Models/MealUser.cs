namespace PastaWorld.Data.Models
{
    using PastaWorld.Data.Common.Models;

    public class MealUser : BaseModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }
    }
}
