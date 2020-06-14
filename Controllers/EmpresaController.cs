using Microsoft.AspNetCore.Mvc;
using DeliveryApp.Data;
using DeliveryApp.Models;
using System.Collections.Generic;
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

    }   
}