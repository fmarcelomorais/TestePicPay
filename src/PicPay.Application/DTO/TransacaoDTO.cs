using PicPay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Application.DTO
{
    public class TransacaoDTO
    {
        public string NumeroTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public bool StatusTransacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public List<UsuarioDTO>? UsuariosTransacao { get; set; }

        public TransacaoDTO()
        {
            UsuariosTransacao = new List<UsuarioDTO>();
        }
    }

    


}
