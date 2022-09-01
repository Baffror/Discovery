using Discovery.Data.Models;
using Discovery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Discovery.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;

        private readonly UserManager<User> UserManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.UserManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var vm = new RegisterViewModel();
            return View(vm);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.Password == model.ConfirmPassword) { 

                var user = new User
                {
                    Email = model.Email,
                    Name = model.Name,
                    Lastname = model.Lastname,
                    UserName = model.Email
                };
                var result = await UserManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false); 
                    return RedirectToAction("Index", "Home");
                }
                } else
                {
                    ModelState.AddModelError("incorrect_confirmation","Les mots de passes ne conrrespondent pas");
                }
            }
            model.Password = String.Empty;
            model.ConfirmPassword = String.Empty;
            return View(model);  
        }

    }
}
