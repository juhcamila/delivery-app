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
        public IActionResult IndexEmpresa()
        {
            Empresa empresa = null;

            using(EmpresaData data = new EmpresaData())
                empresa = data.GetEmpresa(User.Identity.Name);

            using(PedidoData data = new PedidoData())
                return View(data.Read(empresa));
        }

        public IActionResult ShowEmpresa(int? id)
        {
            using(ItensCompradosData data = new ItensCompradosData())
                return View(data.Read(Convert.ToInt32(id)));
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
        public IActionResult Update(int id, int status)
        {
            using (PedidoData data = new PedidoData())
                data.Update(id, status);

            return RedirectToAction("ShowEmpresa", new { id = id });
        }

    }

}