using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }

        public int StatusPedido { get; set; }

        public float ValorFrete { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPedido { get; set; }

        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }
        public int EnderecoId { get; set; }
        
        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}