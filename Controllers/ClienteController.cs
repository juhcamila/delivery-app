using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using System;

namespace DeliveryApp.Controllers
{
    public class ClienteController : Controller
    {
        // [HttpGet]
        public IActionResult Index(Cliente cliente)
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
        public IActionResult Create(Cliente model, Endereco endereco) // Model Binding (MVC - HTML, API - JSON)
        {
            // VALIDAÇÃO
            if (!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();

            using (ClienteData data = new ClienteData())
                data.Create(model,endereco);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {

            using (ClienteData data = new ClienteData())
                data.Delete(new Guid(id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            using (ClienteData data = new ClienteData())
                return View(data.Read(new Guid(id)));
        }

        [HttpPost]
        public IActionResult Update(string id, Cliente model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = new Guid(id);

            using (ClienteData data = new ClienteData())
                data.Update(model);

            return RedirectToAction("Index");
        }

    }

}