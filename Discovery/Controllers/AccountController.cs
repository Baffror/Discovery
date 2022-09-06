using Discovery.Data.Models;
using Discovery.Models;
using Discovery.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Discovery.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly IEmailSender emailSender;
        private readonly UserManager<User> UserManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            this.UserManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
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

                if (model.Password == model.ConfirmPassword)
                {
                    var user = new User
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Lastname = model.Lastname,
                        UserName = model.Email
                    };
                    await emailSender.SendMail(model.Email, "Confirmez votre email", "Copier coller le lien :" + confirmUrl);

                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                        var routeValue = new { email = model.Email, code = HttpUtility.UrlEncode(code) };
                        var confirmUrl = Url.Action("ConfirmEmail", "Account", routeValue, Request.Scheme);

                        return RedirectToAction("Index", "Home", new { message = "Un email de confirmation vous a été envoyé " });
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Les mots de passes ne conrrespondent pas");
                }
            }
            model.Password = String.Empty;
            model.ConfirmPassword = String.Empty;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user?.EmailConfirmed == false)
            {
                code = HttpUtility.UrlDecode(code);
                var confirmationresult = await UserManager.ConfirmEmailAsync(user, code);
                if (confirmationresult.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                }
            }
            return RedirectToAction("index", "home");

        }

        [HttpGet]
        public IActionResult Login()
        {
            var login = new LoginViewModel();
            return View("Login", login);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                if (user.EmailConfirmed)
                {
                    if (ModelState.IsValid)
                    {
                        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemenberMe, false);
                        if (result.Succeeded)
                        {

                        }
                        else
                        {
                            ModelState.AddModelError("Email", "Email ou Mot de passe incorrect");
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "Confirmation d'email nécessaire");
                }

            }
            else
            {
                ModelState.AddModelError("Email", "Email ou Mot de passe incorrect");
            }
            model.Password = String.Empty;
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
