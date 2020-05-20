

namespace ProductionSystem.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using ProductionSystem.Web.Data.Entities;
    using ProductionSystem.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserHelper : IUserHelper
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;


        //esta inyeccion de user manager viene por el core no hay que configurarla
        public UserHelper(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }



        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        //Para obetner el usario por email
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
            model.Username,
            model.Password,
            model.RememberMe,
            false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        //Para agregar un usuario a un role
        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await this.userManager.AddToRoleAsync(user, roleName);
        }

        //No se bien que hace esto
        public async Task CheckRoleAsync(string roleName)
        {
            var rolExists = await this.roleManager.RoleExistsAsync(roleName);
            if (!rolExists)
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }

        }

        //Para saber si el usuario esta en el rol
        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await this.userManager.IsInRoleAsync(user, roleName);
        }

        //Para validar la contrasenha
        public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
        {
            return await this.signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);
        }

        //
        //Para optener todos los Usuarios
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await this.userManager.Users
                .OrderBy(u => u.Nombre)
                .ThenBy(u => u.ApellidoPaterno)
                .ToListAsync();
        }

        //Para obtener un usuario especifico
        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await this.userManager.FindByIdAsync(userId);
        }

        public async Task RemoveUserFromRoleAsync(User user, string roleName)
        {
            await this.userManager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task DeleteUserAsync(User user)
        {
            await this.userManager.DeleteAsync(user);
        }


        //Para cambiar el estado de la cuenta
        public async Task CambiarEstadoADisponible(User user)
        {
            user.Disponible = true;
            await this.userManager.UpdateAsync(user);
        }

        public async Task CambiarEstadoANoDisponible(User user)
        {
            user.Disponible = false;
            await this.userManager.UpdateAsync(user);
        }

                






    }
}
