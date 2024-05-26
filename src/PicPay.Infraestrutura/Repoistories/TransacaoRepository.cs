using Microsoft.EntityFrameworkCore;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;
using PicPay.Infraestrutura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var usuario = _context.Usuarios.Include(c => c.Conta).FirstOrDefault(us => us.Id == id);
            return usuario;
        }

        public async Task<Transacao> RealizarTransacao(Usuario envia, Usuario recebe, decimal valor)
        {
            var transacao = new Transacao(envia, recebe, valor);
            transacao.RealizarTransacao();
            _context.Entry<Usuario>(envia).State = EntityState.Modified;
             await _context.SaveChangesAsync();
            //_context.Entry<Usuario>(recebe).State = EntityState.Detached;

            //_context.Usuarios.Update(recebe);
            //await _context.SaveChangesAsync();

            _context.Entry<Transacao>(transacao).State = EntityState.Added;
            await _context.SaveChangesAsync();



            return transacao;
        }
    }
}
