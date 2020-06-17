using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using System;

namespace DeliveryApp.Controllers
{
    public class PedidoController : Controller
    {
        // [HttpGet]
        public IActionResult Index(Pedido pedido)
        {
            using (PedidoData data = new PedidoData())
                return View(data.Read(pedido));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Pedido());
        }

        [HttpPost] // atributo // annotations
        public IActionResult Create(Pedido model, Cliente cliente, Empresa empresa, Endereco endereco, ItensComprados itenscomprados) // Model Binding (MVC - HTML, API - JSON)
        {

            if (!ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();

            using (PedidoData data = new PedidoData())
                data.Create(model, cliente, empresa, endereco, itenscomprados);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {

            using (PedidoData data = new PedidoData())
                data.Delete(new Guid(id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            using (PedidoData data = new PedidoData())
                return View(data.Read(new Guid(id)));
        }

        [HttpPost]
        public IActionResult Update(string id, Pedido model, ItensComprados itenscomprados)
        { 
            if (!ModelState.IsValid)
                return View(model);

            model.Id = new Guid(id);

            using (PedidoData data = new PedidoData())
                data.Update(model, itenscomprados);

            return RedirectToAction("Index");
        }

    }

}