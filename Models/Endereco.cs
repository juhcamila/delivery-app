using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]        
        [MaxLength(50)]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório.")]
        public int Numero { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(9)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(80)]
        public string Cidade { get; set; }
       
    }
}