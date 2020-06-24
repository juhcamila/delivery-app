using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace DeliveryApp.Controllers
{
    public class EmpresaController : Controller
    {
        // [HttpGet]
        [Authorize]
        public IActionResult Index(Empresa empresa)
        {
            using (EmpresaData data = new EmpresaData())
                return View(data.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Empresa());
        }

        [HttpPost] 
        public IActionResult Create(Empresa model)
        {
            //if (model.Endereco.Numero <= 100){
            //    ModelState.AddModelError("Endereco.Numero", "Tem que ser maior que 100, sua anta");
           //     return View(model);
          //  }
           Usuario usuario = null;
           Endereco endereco = null;

            if(!ModelState.IsValid)
                return View(model);

            using(UsuarioData data = new UsuarioData())
                 usuario = data.Create(model.Usuario);

            using(EnderecoData data = new EnderecoData())
                endereco = data.Create(model.Endereco);    
            
            model.Usuario.Id = usuario.Id;
            model.Endereco.Id = endereco.Id;

            using(EmpresaData data = new EmpresaData())
                data.Create(model);

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult Update()  
        {

            using(EmpresaData data = new EmpresaData())
                return View(data.GetEmpresa(User.Identity.Name));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(Empresa model) 
        {
            using(EmpresaData data = new EmpresaData())
                data.Update(model);

            return RedirectToAction("IndexEmpresa", "Pedido");
        }

    }
}