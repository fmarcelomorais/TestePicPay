using PicPay.Application.DTO;
using PicPay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Application.Interfaces
{
    public interface ITransacaoServices
    {
        Task<TransacaoDTO> Transferir(UsuarioDTO envia, UsuarioDTO recebe, decimal valor);
        Task<UsuarioDTO> BuscarUsuarioTransacao(Guid id);
    }
}
