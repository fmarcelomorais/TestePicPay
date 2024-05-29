using System.Drawing;

namespace PicPay.Domain.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public string? NumeroTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public bool StatusTransacao { get; set;}
        public decimal ValorTransacao { get; set; } 
        public Usuario UsuarioEnvia { get; set;}
        public Usuario UsuarioRecebe { get; set;}
        public Transacao()
        {
            Id = Guid.NewGuid(); 
        }

        public List<Usuario> RealizarTransacao(Usuario envia, Usuario recebe, decimal valor)
        {
            List<Usuario> usuarios = [UsuarioEnvia, UsuarioRecebe];
            UsuarioEnvia = envia;
            UsuarioRecebe = recebe;
            ValorTransacao = valor;
            NumeroTransacao = Id.ToString().Replace("-", "").Trim();
            DataTransacao = DateTime.Now;
            StatusTransacao = false;
            
            if (UsuarioEnvia.TipoUsuario == 2) throw new Exception(message: "Logistas não podem realizar transferências.");

            if (UsuarioEnvia.Conta.VerificarPossibilidadeDeTransferencia(ValorTransacao))
            {
                UsuarioEnvia.Conta.EnviarValor(UsuarioEnvia.Conta, ValorTransacao);
                UsuarioRecebe.Conta.ReceberValor(UsuarioRecebe.Conta, ValorTransacao);

                StatusTransacao = true;

                usuarios = [UsuarioEnvia, UsuarioRecebe];
                return usuarios;
            }

            return usuarios;
        }

    }
}
