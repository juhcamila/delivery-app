using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace DeliveryApp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IWebHostEnvironment env;
        public ProdutoController(IWebHostEnvironment env){
          this.env = env;
        }

        [Authorize]
        public IActionResult AdicionarCarrinho(int id)
        {
          HttpContext.Session.SetInt32("produto" + id, id);
          return RedirectToAction("Carrinho", "Pedido");
        }

                
        public IActionResult RemoverCarrinho(int id)
        {
          HttpContext.Session.Remove("produto" + id);
          return RedirectToAction("Carrinho", "Pedido");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            Empresa empresa = null;

            using(EmpresaData data = new EmpresaData())
                empresa = data.GetEmpresa(User.Identity.Name);

            using(ProdutoData data = new ProdutoData())
                return View(data.Read(empresa));
        }
      
       public IActionResult ShowProduto(int id)
        {
           
            using(ProdutoData data = new ProdutoData())
                return View(data.ReadCliente(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

      [HttpPost] 
      [Authorize]
      public IActionResult Create(Produto model) 
      {

        if (model.Imagem == null){
          ModelState.AddModelError("Imagem", "Você deve enviar uma imagem!");
          return View(model);
        }

        FileStream fs = new FileStream(Path.Combine(Path.Combine(env.WebRootPath, "imagens"), model.Imagem.FileName), FileMode.Create);

        model.Imagem.CopyTo(fs);

        fs.Flush();
        fs.Close();

        Empresa empresa = null;

        using(EmpresaData data = new EmpresaData())
            empresa = data.GetEmpresa(User.Identity.Name);
            
        // VALIDAÇÃO
        if(!ModelState.IsValid)
          return View(model);

        model.NomeImagem = model.Imagem.FileName;
        model.EmpresaId = empresa.Id;
        using(ProdutoData data = new ProdutoData())
          data.Create(model);

        return RedirectToAction("Index");
      }

    [HttpGet]
    [Authorize]
    public IActionResult Update(int id)  
    {
      using(ProdutoData data = new ProdutoData())
        return View(data.Read(id));
    }

    [HttpPost]
    [Authorize]
    public IActionResult Update(Produto model) 
    {
        Produto produto = null;

        if(!ModelState.IsValid)
          return View(model);

        using(ProdutoData data = new ProdutoData())
            produto = data.Read(model.Id);  

        if (model.Imagem != null) {
          
          string fullPath = "wwwroot/imagens/" + model.NomeImagem;
        
          if (System.IO.File.Exists(fullPath))
            System.IO.File.Delete(fullPath);

          FileStream fs = new FileStream(Path.Combine(Path.Combine(env.WebRootPath, "imagens"), model.Imagem.FileName), FileMode.Create);

          model.Imagem.CopyTo(fs);

          fs.Flush();
          fs.Close();  

          model.NomeImagem = model.Imagem.FileName;
        }else{
          model.NomeImagem = produto.NomeImagem;
        }
        using(ProdutoData data = new ProdutoData())
          data.Update(model);

        return RedirectToAction("Index");
    }

  }
    
}