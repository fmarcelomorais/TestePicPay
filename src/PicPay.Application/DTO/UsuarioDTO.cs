using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PicPay.Application.DTO
{
    public class UsuarioDTO
    {
        //[JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ser vazio.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ser vazio.")]
        [MaxLength(14, ErrorMessage = "O campo {0} deve ter no max 14 caracteres}")]
        public string? Documento { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ser vazio.")]
        [EmailAddress(ErrorMessage = "Campo {0} está inválido")]
        public string? Email { get; set; }
        public string? Senha { get; set; }
        [JsonIgnore]
        public int TipoUsuario { get; set; }
        [JsonIgnore]
        public ContaDTO? Conta { get; set; }

    }
}
