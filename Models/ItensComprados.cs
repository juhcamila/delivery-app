using System.ComponentModel.DataAnnotations;
using System;

namespace DeliveryApp.ItensComprados
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public int Quantidade { get; set; }
    [Required(ErrorMessage = "Campo obrigatório.")]
    public float Valor { get; set; }
}