using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using System;

namespace DeliveryApp.Controllers
{
    public class EnderecoController : Controller
    {
        // [HttpGet]
        public IActionResult Index(Cliente cliente)
        {
        using(EnderecoData data = new EnderecoData())
            return View(data.Read(cliente.Endereco.Id));
        }

        public IActionResult Index(Empresa empresa)
        {
        using(EnderecoData data = new EnderecoData())
            return View(data.Read(empresa.Endereco.Id));
        }


           [HttpGet]
        public IActionResult Create()
        {
            return View(new Endereco());
        }

        [HttpPost] 
    public IActionResult Create(Endereco model) 
    {
      // VALIDAÇÃO
      if(!ModelState.IsValid)
        return View(model);


      using(EnderecoData data = new EnderecoData())
        data.Create(model);

      return RedirectToAction("Index", "Home");
    }

    public IActionResult Delete(int id) {

      using(EnderecoData data = new EnderecoData())
        data.Delete(id);

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateEmpresa()  
    {
      Empresa empresa = null;

      using(EmpresaData data = new EmpresaData())
          empresa = data.GetEmpresa(User.Identity.Name);

      using(EnderecoData data = new EnderecoData())
          return View(data.Read(empresa.EnderecoId));
    }


    [HttpPost]
    public IActionResult UpdateEmpresa(Endereco model) 
    {

        if(!ModelState.IsValid)
          return View(model);

        using(EnderecoData data = new EnderecoData())
          data.Update(model);

        return RedirectToAction("IndexEmpresa","Pedido");
    }

    [HttpGet]
    public IActionResult Update(int id)  
    {
      id = 3;
      using(EnderecoData data = new EnderecoData())
        return View(data.Read(id));
    }

    [HttpPost]
    public IActionResult Update(Endereco model) 
    {
      model.Id = 3;
        if(!ModelState.IsValid)
          return View(model);

        using(EnderecoData data = new EnderecoData())
          data.Update(model);

        return RedirectToAction("Index","Home");
    }

  }
    
}