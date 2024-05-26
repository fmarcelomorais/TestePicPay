using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Domain.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public string? NumeroTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public bool StatusTransacao { get; set;}
        public decimal ValorTransacao { get; set; }
        public List<Usuario> UsuariosTransacao { get; set; }   

        public Transacao()
        {
            Id = Guid.NewGuid(); 
            UsuariosTransacao = [];

        }
        public Transacao(Usuario envia, Usuario recebe, decimal valor)
        {
            Id = Guid.NewGuid();
            UsuariosTransacao = [];
            UsuariosTransacao.Add(envia);
            UsuariosTransacao.Add(recebe);
            ValorTransacao = valor;

        }

        public List<Usuario> RealizarTransacao(/*Usuario envia, Usuario recebe, decimal valor*/)
        {
            //UsuariosTransacao[0] = envia;
            //UsuariosTransacao[1] = recebe;
            NumeroTransacao = Id.ToString().Replace("-", "").Trim();
            DataTransacao = DateTime.Now;
           // ValorTransacao = valor;
            StatusTransacao = false;
            
            if (UsuariosTransacao[0].TipoUsuario == 2) throw new Exception();

            if (UsuariosTransacao[0].Conta.VerificarPossibilidadeDeTransferencia(ValorTransacao))
            {
                UsuariosTransacao[0].Conta.EnviarValor(UsuariosTransacao[0].Conta, ValorTransacao);
                UsuariosTransacao[1].Conta.ReceberValor(UsuariosTransacao[1].Conta, ValorTransacao);

                StatusTransacao = true;
                return UsuariosTransacao;
            }

            return UsuariosTransacao;
        }

    }
}
