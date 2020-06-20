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
        public IActionResult Create(Pedido model) 
        {

            if (!ModelState.IsValid)
                return View(model);
<<<<<<< Updated upstream


=======
       
>>>>>>> Stashed changes
            using (PedidoData data = new PedidoData())
                data.Create(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            using (PedidoData data = new PedidoData())
                data.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
<<<<<<< Updated upstream
        public IActionResult Update(int id, int status)
        {
            using (PedidoData data = new PedidoData())
                data.Update(id, status);

            return RedirectToAction("ShowEmpresa", new { id = id });
=======
        public IActionResult Update(Empresa model, int status)
        {
            using (PedidoData data = new PedidoData())
                return View(data.Read(model,status));
        }

        [HttpPost]
        public IActionResult Update(int id, Pedido model)
        { 
            if (!ModelState.IsValid)
                return View(model);
       

            using (PedidoData data = new PedidoData())
                data.Update(model);

            return RedirectToAction("Index");
>>>>>>> Stashed changes
        }

    }

}