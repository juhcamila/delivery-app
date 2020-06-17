using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using System;

namespace DeliveryApp.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public IActionResult Index(Empresa empresa)
        {
        using(ProdutoData data = new ProdutoData())
            return View(data.Read(empresa.Id));
        }

           [HttpGet]
        public IActionResult Create()
        {
            return View(new Produto());
        }

        [HttpPost] // atributo // annotations
    public IActionResult Create(Produto model, Empresa empresa) // Model Binding (MVC - HTML, API - JSON)
    {
      // VALIDAÇÃO
      if(!ModelState.IsValid)
        return View(model);

      model.Id = Guid.NewGuid();

      using(ProdutoData data = new ProdutoData())
        data.Create(model, empresa);

      return RedirectToAction("Index");
    }

    public IActionResult Delete(string id) {

      using(ProdutoData data = new ProdutoData())
        data.Delete(new Guid(id));

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(string id)  
    {
      using(ProdutoData data = new ProdutoData())
        return View(data.Read(new Guid(id)));
    }

    [HttpPost]
    public IActionResult Update(string id, Produto model) 
    {
        if(!ModelState.IsValid)
          return View(model);

        model.Id = new Guid(id);

        using(ProdutoData data = new ProdutoData())
          data.Update(model);

        return RedirectToAction("Index");
    }

  }
    
}