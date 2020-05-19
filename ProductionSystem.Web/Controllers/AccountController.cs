

namespace ProductionSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProductionSystem.Web.Helpers;
    using ProductionSystem.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;
        private readonly ICombosHelper combosHelper;
        private readonly IConverterHelper converterHelper;

        public AccountController(IUserHelper userHelper, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            this.userHelper = userHelper;
            this.combosHelper = combosHelper;
            this.converterHelper = converterHelper;
        }


        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }

                    return this.RedirectToAction("Index", "Home");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Failed to login.");
            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }

        //
        public async Task<IActionResult> Index()
        {
            var users = await this.userHelper.GetAllUsersAsync();
            foreach (var user in users)
            {
                var myUser = await this.userHelper.GetUserByIdAsync(user.Id);
                if (myUser != null)
                {
                    user.IsAdmin = await this.userHelper.IsUserInRoleAsync(myUser, "Administrador");
                }
            }

            return this.View(users);
        }

        //GET
        public IActionResult Register()
        {
            var model = new RegisterUserViewModel
            {
                Cargos = combosHelper.GetComboCargos(),
            };

            return this.View(model);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(model.UserName);
                if (user == null)
                {
                    user = await converterHelper.ToUserAsync(model); 

                    var result = await this.userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        this.ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return this.View(model);
                    }
                    
                    await this.userHelper.CheckRoleAsync(user.Cargo);
                    await this.userHelper.AddUserToRoleAsync(user, user.Cargo);
                    var isInRole = await this.userHelper.IsUserInRoleAsync(user, user.Cargo);

                    if (!isInRole)
                    {
                        await this.userHelper.AddUserToRoleAsync(user, user.Cargo);
                    }

                    //Esto hacia que se logee automaticamente cuando se creaba el usuario
                    var loginViewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        Username = model.UserName,
                    };

                    var result2 = await this.userHelper.LoginAsync(loginViewModel);

                    if (result2.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }

                    this.ModelState.AddModelError(string.Empty, "The user couldn't be login.");
                    return this.View(model);
                }

                this.ModelState.AddModelError(string.Empty, "The username is already registered.");
            }

            return this.View(model);
        }





    }
}
