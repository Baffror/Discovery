using Discovery.Models;
using Microsoft.AspNetCore.Mvc;

namespace Discovery.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            var vm = new RegisterViewModel();
            return View(vm);
        }
    
        public async Task<IActionResult> CreateAccount()
        {
            return View();  
        }

    }
}
