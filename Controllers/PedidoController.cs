using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using System;

namespace DeliveryApp.Controllers
{
    public class PedidoController : Controller
    {

        public IActionResult Carrinho()
        {
            List<Produto> lista = new List<Produto>();

            IEnumerable<string> sessions = HttpContext.Session.Keys;
            foreach(string item in sessions){
                int id = Convert.ToInt32(HttpContext.Session.GetInt32(item));
                using(ProdutoData data = new ProdutoData())
                    lista.Add(data.Read(id));
            }

           return View(lista);
        }
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

            Pedido pedido = null;   
            Endereco endereco = null;
            Produto produto = null;

            using(EnderecoData data = new EnderecoData())
                endereco = data.Create(model.Endereco);    

            model.Id_Endereco = endereco.Id;
            model.Valor_Frete = 6.99;
            using (PedidoData data = new PedidoData())
                pedido = data.Create(model);

            IEnumerable<string> sessions = HttpContext.Session.Keys;
            foreach(string item in sessions){
                int id = Convert.ToInt32(HttpContext.Session.GetInt32(item));
                using(ProdutoData data = new ProdutoData())
                    produto = data.Read(id);
                ItensComprados itens = new ItensComprados();
                 itens.Quantidade = 1;
                 itens.Valor = produto.Valor;
                 itens.Id_Produto = produto.Id;
                 itens.Id_Pedido = pedido.Id;
                using(ItensCompradosData data = new ItensCompradosData())
                    data.Create(itens);
            }    

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            using (PedidoData data = new PedidoData())
                data.Delete(id);

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