using System.ComponentModel.DataAnnotations;
using System;

namespace DeliveryApp.Models
{
    public class Endereco
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        [MinLength(2, ErrorMessage="O campo Rua deve conter no mínimo 3 caracteres.")]
        [MaxLength(50)]
        public string Rua { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        [MinLength(2, ErrorMessage="O campo Bairro deve conter no mínimo 3 caracteres.")]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required(ErrorMessage="Campo Obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        public string Cep { get; set; }

        [Required(ErrorMessage="Campo obrigatório.")] 
        [MaxLength(80)]
        public string Cidade { get; set; }
    }
}