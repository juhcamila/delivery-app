using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult AuthEmpresa()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserPage");
            }
             return View();
        }

        
        [HttpPost]
        public IActionResult AuthEmpresa(Usuario usuario)
        {
           
            if (ModelState.IsValid)
            {
                    
                using(UsuarioData data = new UsuarioData())
                {
                    bool result = data.Logar(usuario);
                
                    if (result)
                    {
                        Login(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Erro = "Usuário e / ou senha incorretos!";
                    }
            }}

            return View();
        }

        private async void Login(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim(ClaimTypes.Role, "Usuario_Comum")
            };

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}