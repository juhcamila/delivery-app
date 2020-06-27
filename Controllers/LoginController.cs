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
        public IActionResult AuthCliente()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Empresa");
            }
             return View();
        }

        [HttpGet]
        public IActionResult AuthEmpresa()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("IndexEmpresa", "Pedido");
            }
             return View();
        }

        
        [HttpPost]
        public IActionResult AuthEmpresa(Usuario usuario)
        {
           
            if (ModelState.IsValid)
            {
                usuario.Tipo = 1;    
                using(UsuarioData data = new UsuarioData())
                {
                    bool result = data.Logar(usuario);
                
                    if (result)
                    {
                        Login(usuario);
                        return RedirectToAction("IndexEmpresa", "Pedido");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "E-mail ou senha incorreto!");
                    }
            }}

            return View(usuario);
        }

         [HttpPost]
        public IActionResult AuthCliente(Usuario usuario)
        {
           
            if (ModelState.IsValid)
            {
                usuario.Tipo = 2;        
                using(UsuarioData data = new UsuarioData())
                {
                    bool result = data.Logar(usuario);
                
                    if (result)
                    {
                        Login(usuario);
                        return RedirectToAction("Index", "Empresa");
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
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
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
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}