using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System;


namespace DeliveryApp.Controllers
{
    public class EmpresaController : Controller
    {
        // [HttpGet]
        public IActionResult Index(Empresa empresa)
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
            //if (model.Endereco.Numero <= 100){
            //    ModelState.AddModelError("Endereco.Numero", "Tem que ser maior que 100, sua anta");
           //     return View(model);
          //  }
           
            if(ModelState.IsValid)
                return View(model);

            model.Id = Guid.NewGuid();
            model.Usuario.Id = Guid.NewGuid();
            model.Endereco.Id = Guid.NewGuid();

            using(UsuarioData data = new UsuarioData())
                data.Create(model.Usuario);

            using(EnderecoData data = new EnderecoData())
                data.Create(model.Endereco);    

            using(EmpresaData data = new EmpresaData())
                data.Create(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id) {

        using(EmpresaData data = new EmpresaData())
            data.Delete(new Guid(id));

        return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string id)  
        {
        using(EmpresaData data = new EmpresaData())
            return View(data.Read(new Guid(id)));
        }

        [HttpPost]
        public IActionResult Update(string id, Empresa model) 
        {
            if(!ModelState.IsValid)
            return View(model);

            model.Id = new Guid(id);

            using(EmpresaData data = new EmpresaData())
            data.Update(model);

            return RedirectToAction("Index");
        }

    }
}