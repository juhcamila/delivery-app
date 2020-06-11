using System.ComponentModel.DataAnnotations;
using System;

namespace DeliveryApp.Models
{
    public class Produto
    {
       public Guid Id { get; set; }

      [Required(ErrorMessage="Campo obrigatório.")] 
      [MaxLength(20)]
      public string Nome { get; set; } 


      [Required(ErrorMessage="Campo obrigatório.")] 
      [MaxLength(20)]
      public string Descricao { get; set; } 

      public float Valor { get; set; }

      public byte[] Imagem { get; set; }

      public int EmpresaId { get; set; }
        
      public virtual Empresa Empresa { get; set; }


    }
}