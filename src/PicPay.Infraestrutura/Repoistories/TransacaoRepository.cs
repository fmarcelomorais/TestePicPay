using Microsoft.EntityFrameworkCore;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;
using PicPay.Infraestrutura.Context;
using PicPay.Infraestrutura.Services;

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
            HttpClient httpClient = new();

            var transacao = new Transacao(envia, recebe, valor);
            var usuarios = transacao.RealizarTransacao();

            /* Serviço autorizador */
            var request = new AutorizacaoService(httpClient, "https://util.devi.tools/api/v2/authorize");
            if (!await request.Autorizacao()) throw new Exception(message: "Falha ao executar a transferencia.");           

            await SalvarTransacaoContas(usuarios[0].Conta, usuarios[1].Conta);

            var notificacacao = new NotificacaoService(httpClient, "https://util.devi.tools/api/v1/notify");
            await notificacacao.EnviarNotificacao();

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

        public async Task<IEnumerable<Transacao>> TodasAsTransacoes()
        {
            var transacoes = await _context.Transacoes.AsNoTracking().ToListAsync();
            return transacoes;
        }
    }
}
