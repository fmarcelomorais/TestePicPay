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

    public async Task<bool> Delete(Guid id)
    {
        var conta = await _context.Contas.FindAsync(id);
        _context.Remove(conta);
        var sucesso = await _context.SaveChangesAsync();
        return sucesso == 1 ? true : false;
    }

    public async Task<Conta> Depositar(Conta conta, decimal valor)
    {
        conta.Depositar(conta, valor);

        _context.Update(conta);
        await _context.SaveChangesAsync();
        return conta;
    }

    public async Task<bool> Editar(Conta entidade)
    {
        _context.Update(entidade);
        var sucesso = await _context.SaveChangesAsync();
        return sucesso == 1 ? true : false;
    }

    public async Task<Conta> ObterPorId(Guid id)
    {
        var conta = await _context.Contas.Include(c => c.Usuario).AsNoTracking().FirstOrDefaultAsync(conta => conta.Id == id);
        return conta;
    }

    public async Task<IEnumerable<Conta>> ObterTodos()
    {
        var contas = await _context.Contas.Include(u => u.Usuario).ToListAsync();
        return contas;
    }
    
}
