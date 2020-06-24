using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DeliveryApp.Models
{
    public class Produto
    {
       public int Id { get; set; }

      [Required(ErrorMessage="Campo obrigatório.")] 
      [MaxLength(20)]
      public string Nome { get; set; } 


      [Required(ErrorMessage="Campo obrigatório.")] 
      [MaxLength(20)]
      public string Descricao { get; set; } 

      public string NomeImagem { get; set; }

      [DataType(DataType.Upload)]
      public Double Valor { get; set; }

      public IFormFile Imagem { get; set; }

      public int EmpresaId { get; set; }
        
      public virtual Empresa Empresa { get; set; }

    }
}