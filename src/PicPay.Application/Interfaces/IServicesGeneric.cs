using System.Linq.Expressions;

namespace PicPay.Application.Interfaces;

public interface IServicesGeneric<TEntity>
{
    Task<TEntity> Cadastrar(TEntity entidade);
    Task<bool> Editar(Guid id, TEntity entidade);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<TEntity>> ObterTodos();
    Task<TEntity> ObterPorId(Guid id);
}
