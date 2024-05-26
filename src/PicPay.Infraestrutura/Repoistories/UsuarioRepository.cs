using Microsoft.EntityFrameworkCore;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;
using PicPay.Infraestrutura.Context;
using System.Linq.Expressions;

namespace PicPay.Infraestrutura.Repoistories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationContext _context;
    public UsuarioRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Usuario> Cadastrar(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public async Task<int> Delete(Guid id)
    {
        var usuario = await _context.Usuarios.FirstAsync(x => x.Id == id);
        _context.Usuarios.Remove(usuario);
        var ok = await _context.SaveChangesAsync();
        return ok;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }

    public async Task<Usuario> Editar(Usuario usuario)
    {
        _context.Entry<Usuario>(usuario).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> ObterPorId(Guid id)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(user => user.Id == id);
        return usuario;
    }

    public async Task<IEnumerable<Usuario>> ObterTodos()
    {
        var usuarios = await _context.Usuarios.Include(c => c.Conta).ToListAsync();
        return usuarios;
    }
}
