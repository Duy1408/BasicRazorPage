using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repo.Interface;

namespace Eyeglasses_NguyenThienCaoDuy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStoreAccountRepo _acountRepo;

        public IndexModel(IStoreAccountRepo accountRepo)
        {
            _acountRepo = accountRepo;  
        }
        [BindProperty]
        public StoreAccount Account { get; set; } = default!;

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var checkLogin = _acountRepo.CheckLogin(Account.EmailAddress, Account.AccountPassword);
            if (checkLogin == null)
            {
                ViewData["notification"] = "Email or Password is wrong!";
                return Page();
            }
            else if (checkLogin != null && (checkLogin.Role == 1))
            {
                return RedirectToPage("./EyeglassManager/Index");
            }
            else
            {
                ViewData["notification"] = "You do not have permission to do this function!";
                return Page();
            }
        }
    }
}