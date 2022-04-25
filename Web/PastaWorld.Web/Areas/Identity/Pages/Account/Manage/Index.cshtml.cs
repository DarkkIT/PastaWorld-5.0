namespace PastaWorld.Web.Areas.Identity.Pages.Account.Manage
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userRepository = userRepository;
        }

        public string Username { get; set; }

        [Display(Name = "Град")]
        public string Town { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Телефонен номер")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            var userAdress = user.Address;
            var userTown = user.Town;

            this.Username = userName;
            this.Town = userTown;
            this.Address = userAdress;

            this.Input = new InputModel
            {
                PhoneNumber = phoneNumber,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(string userName, string address, string town)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    this.StatusMessage = "Unexpected error when trying to set phone number.";
                    return this.RedirectToPage();
                }
            }

            user.NormalizedUserName = userName.ToUpper();
            user.UserName = userName;
            user.Town = town;
            user.Address = address;

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Вашият профил беше актуализиран.";
            return this.RedirectToPage();
        }
    }
}
