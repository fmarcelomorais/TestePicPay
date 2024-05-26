using Microsoft.EntityFrameworkCore;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;
using PicPay.Infraestrutura.Context;

namespace PicPay.Infraestrutura.Repoistories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ApplicationContext _context;
        public TransacaoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Usuario> BuscarUsuarioTransacao(Guid id)
        {
            var usuario = await _context.Usuarios.Include(c => c.Conta).AsNoTracking().FirstOrDefaultAsync(us => us.Id == id);
            return usuario;
        }

        public async Task<Transacao> RealizarTransacao(Usuario envia, Usuario recebe, decimal valor)
        {
            var transacao = new Transacao(envia, recebe, valor);
            var usuarios = transacao.RealizarTransacao();

            await SalvarTransacaoContas(usuarios[0].Conta, usuarios[1].Conta);

            _context.Entry<Transacao>(transacao).State = EntityState.Added;
            await _context.SaveChangesAsync();

           
            return transacao;
        }

        public async Task SalvarTransacaoContas(Conta envio, Conta recebimento)
        {
            _context.Entry<Conta>(envio).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _context.Entry<Conta>(recebimento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
