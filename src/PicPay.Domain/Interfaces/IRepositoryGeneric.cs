using PicPay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Domain.Interfaces
{
    public interface IRepositoryGeneric<TEntit>
    {
        Task<TEntit> Cadastrar(TEntit entidade);
        Task<TEntit> Editar(TEntit entidade);
        Task<int> Delete(Guid id);
        Task<IEnumerable<TEntit>> ObterTodos();
        Task<TEntit> ObterPorId(Guid id);
    }
}
