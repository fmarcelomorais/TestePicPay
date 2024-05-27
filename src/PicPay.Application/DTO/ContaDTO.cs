using PicPay.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PicPay.Application.DTO
{
    public class ContaDTO
    {

        public Guid Id { get; set; }
        public string? NumeroConta { get; set; }
        public decimal Saldo { get; set; }
        public UsuarioDTO? Usuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório para criação da conta.")]
        public Guid UsuarioId { get; set; }

    }
}
