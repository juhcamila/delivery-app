using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using System;

namespace DeliveryApp.Controllers
{
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Read(Cliente cliente)
        {
            using (ClienteData data = new ClienteData())
                return View(data.Read(cliente.Id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cliente());
        }

        [HttpPost] // atributo // annotations
        public IActionResult Create(Cliente model) // Model Binding (MVC - HTML, API - JSON)
        {
            // VALIDAÇÃO
           // Usuario usuario = null;
           //Endereco endereco = null;

            if (!ModelState.IsValid)
                return View(model);

            using (ClienteData data = new ClienteData())
                data.Create(model);

            /*using(UsuarioData data = new UsuarioData())
            usuario = data.Create(model.Usuario);

            using(EnderecoData data = new EnderecoData())
                endereco = data.Create(model.Endereco);    
            
            model.Usuario.Id = usuario.Id;
            model.Endereco.Id = endereco.Id;

*/            

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {

            using (ClienteData data = new ClienteData())
                data.Delete(id);

            return RedirectToAction("Index", "Home");
        }
     
        [HttpGet]
        public IActionResult Update()  
        {
            int id = 5;
            Console.WriteLine(id);
            using (ClienteData data = new ClienteData())
                return View(data.Read(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Cliente model)
        {
            model.Id = 5;
            if (!ModelState.IsValid)
                return View(model);

            using (ClienteData data = new ClienteData())
                data.Update(model);

            return RedirectToAction("Index", "Home");
        }

    }

}