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
    
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {      
            using(EmpresaData data = new EmpresaData())
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

           Usuario usuario = null;
           Endereco endereco = null;

            if(!ModelState.IsValid)
                return View(model);
                
            model.Usuario.Tipo = 1;
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