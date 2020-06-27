using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Cliente
    {
        public int Id {get; set;}
        
        [Required(ErrorMessage="Campo obrigatório.")] 
        [MinLength(3, ErrorMessage="O campo Nome deve conter no mínimo 3 caracteres.")]
        [MaxLength(15)]
        public string Nome { get; set; }

        public string Cpf {get; set;}

        [Required(ErrorMessage="Campo Obrigatório.")]
        public string Celular {get; set;}
        public int EnderecoId { get; set; }     

        public virtual Endereco Endereco { get; set; }
        public int UsuarioId { get; set;}
        public virtual Usuario Usuario { get; set; }
       
        public Cliente (){
            Usuario = new Usuario();
            Endereco = new Endereco();

        }
    }
}