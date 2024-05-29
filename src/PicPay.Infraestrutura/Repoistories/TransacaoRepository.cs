using Microsoft.EntityFrameworkCore;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;
using PicPay.Infraestrutura.Context;
using PicPay.Infraestrutura.Interfaces;
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
            //HttpClient httpClient = new();

            var transacao = new Transacao();
            var usuarios = transacao.RealizarTransacao(envia, recebe, valor);

            /* Serviço autorizador */
            var request = new AutorizacaoService();
            if (!await request.Autorizacao(new HttpClient(), "https://util.devi.tools/api/v2/authorize")) throw new Exception(message: "Falha ao executar a transferencia.");           

            await SalvarTransacaoContas(usuarios[0].Conta, usuarios[1].Conta);

            var notificacacao = new NotificacaoService();
            if(!await notificacacao.EnviarNotificacao(new HttpClient(), "https://util.devi.tools/api/v1/notify")) throw new Exception(message: "Erro ao enviar notificação.");

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
