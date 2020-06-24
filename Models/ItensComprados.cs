using System.ComponentModel.DataAnnotations;
using System;

namespace DeliveryApp.Models
{
    public class ItensComprados
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Double Valor { get; set; }

        public int Id_Produto { get; set; }

        public int Id_Pedido { get; set; }
        public virtual Produto Produto { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}