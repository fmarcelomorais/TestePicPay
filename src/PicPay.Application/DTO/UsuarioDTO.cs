using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PicPay.Application.DTO
{
    public class UsuarioDTO
    {
        //[JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ser vazio.")]
        public string? FullName { get; set; }
        public string? Documento { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        [JsonIgnore]
        public int TipoUsuario { get; set; }
        [JsonIgnore]
        public ContaDTO? Conta { get; set; }

    }
}
