using PicPay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Domain.Interfaces
{
    public interface ITransacaoRepository
    {
        Task<Transacao> RealizarTransacao(Usuario envia, Usuario recebe, decimal valor);
        Task<Usuario> BuscarUsuarioTransacao(Guid id);
    }
}
