using System.ComponentModel.DataAnnotations;
using System;

namespace DeliveryApp.Models
{
    public class Usuario
    {
        public Guid Id {get; set;}
        
        [Required(ErrorMessage="Campo obrigatório.")] 
        public string Email { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        [MinLength(6, ErrorMessage="O campo Senha deve conter no mínimo 6 caracteres.")]
        [MaxLength(10)]
        public string Senha { get; set; }

        public int Tipo { get; set; }
    }
}