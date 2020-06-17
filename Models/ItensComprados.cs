using System.ComponentModel.DataAnnotations;
using System;

namespace DeliveryApp.Models
{
    public class ItensComprados
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public float Valor { get; set; }

        public int Id_Produto { get; set; }

        public int Id_Pedido { get; set; }
        public virtual Produto Produto { get; set; }

        public virtual Pedido pedido { get; set; }

        public float valor_frete()
        {
            float vlr = Valor;
            int qtd = Quantidade;
            float valor_frete = (vlr * qtd )*12 /100 + 5;

            return valor_frete;
        }
    }
}