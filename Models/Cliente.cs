using System.ComponentModel.DataAnnotations;
using System;

namespace DeliveryApp.Models
{
    public class Cliente
    {
        public Guid Id {get; set;}
        
        [Required(ErrorMessage="Campo obrigatório.")] 
        [MinLength(3, ErrorMessage="O campo Nome deve conter no mínimo 3 caracteres.")]
        [MaxLength(15)]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        [MinLength(3, ErrorMessage="O campo Sobrenome deve conter no mínimo 3 caracteres.")]
        [MaxLength(80)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        public string Email { get; set; }

        [Required(ErrorMessage="Campo Obrigatório.")]
        public string DataNascimento {get; set;}

        [Required(ErrorMessage="Campo Obrigatório.")]
        public string Cpf {get; set;}

        [Required(ErrorMessage="Campo Obrigatório.")]
        public string Telefone {get; set;}
    }
}