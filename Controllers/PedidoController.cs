using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using System;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [Authorize]
        public IActionResult IndexEmpresa()
        {
            Empresa empresa = null;

            using(EmpresaData data = new EmpresaData())
                empresa = data.GetEmpresa(User.Identity.Name);

            using(PedidoData data = new PedidoData())
                return View(data.Read(empresa));
        }

        [Authorize]
        public IActionResult ShowEmpresa(int? id)
        {
            using(ItensCompradosData data = new ItensCompradosData())
                return View(data.Read(Convert.ToInt32(id)));
        }

         // atributo // annotations
        public IActionResult Create(int id) 
        {
Console.WriteLine(id);
            DateTime thisDay = DateTime.Today;
            Pedido pedido = new Pedido();   
            Produto produto = null;
            Cliente cliente = null;
            

            using(ClienteData data = new ClienteData())
                cliente = data.GetCliente(User.Identity.Name);
                Console.WriteLine(cliente.Id);

            pedido.Id_Endereco = cliente.EnderecoId;
            pedido.Valor_Frete = 6.99;
            pedido.Id_Cliente = cliente.Id;
            pedido.Tipo_Pagamento = 1;
            pedido.Data_Pedido = thisDay;
            pedido.Id_Empresa = id;
            using (PedidoData data = new PedidoData())
                pedido = data.Create(pedido);

            IEnumerable<string> sessions = HttpContext.Session.Keys;
            foreach(string item in sessions){
                int Id_Produto = Convert.ToInt32(HttpContext.Session.GetInt32(item));
                using(ProdutoData data = new ProdutoData())
                    produto = data.Read(Id_Produto);
                ItensComprados itens = new ItensComprados();
                 itens.Quantidade = 1;
                 itens.Valor = produto.Valor;
                 itens.Id_Produto = produto.Id;
                 itens.Id_Pedido = pedido.Id;
                using(ItensCompradosData data = new ItensCompradosData())
                    data.Create(itens);
            }    
            
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Empresa");
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