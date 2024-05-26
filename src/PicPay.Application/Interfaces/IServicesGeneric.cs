using System.Linq.Expressions;

namespace PicPay.Application.Interfaces;

public interface IServicesGeneric<TEntity>
{
    Task<TEntity> Cadastrar(TEntity entidade);
    Task<TEntity> Editar(Guid id, TEntity entidade);
    Task<int> Delete(Guid id);
    Task<IEnumerable<TEntity>> ObterTodos();
    Task<TEntity> ObterPorId(Guid id);
}
