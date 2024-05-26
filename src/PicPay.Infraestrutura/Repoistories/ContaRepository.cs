using Microsoft.EntityFrameworkCore;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;
using PicPay.Infraestrutura.Context;

namespace PicPay.Infraestrutura.Repoistories;

public class ContaRepository : IContaRepository
{
    private readonly ApplicationContext _context;
    public ContaRepository(ApplicationContext context)
    {
        _context = context;
    }
 
    public async Task<Conta> Cadastrar(Conta conta)
    {
         await _context.Contas.AddAsync(conta);
        _context.SaveChanges();
        return conta;
    }

    public Task<int> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Conta> Editar(Conta entidade)
    {
        throw new NotImplementedException();
    }

    public Task<Conta> ObterPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Conta>> ObterTodos()
    {
        var contas = await _context.Contas.Include(u => u.Usuario).ToListAsync();
        return contas;
    }
    
}
