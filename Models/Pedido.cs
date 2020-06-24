using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryApp.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public int Status_Pedido { get; set; }
        public Double Valor_Frete { get; set; }
        public float Valor_Troco { get; set; }
        public int Tipo_Pagamento { get; set; }

        public Double Valor_Total { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_Pedido { get; set; }

        public int Id_Cliente { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Endereco { get; set; }

        public int Id_Produto { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual ItensComprados itenscomprados { get; set; }

        
    }
}