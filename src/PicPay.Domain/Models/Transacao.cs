namespace PicPay.Domain.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public string? NumeroTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public bool StatusTransacao { get; set;}
        public decimal ValorTransacao { get; set; }
        //public List<Usuario> UsuariosTransacao { get; set; }   
        public Usuario UsuarioEnvia { get; set;}
        public Usuario UsuarioRecebe { get; set;}
        public Transacao()
        {
            Id = Guid.NewGuid(); 
           // UsuariosTransacao = [];

        }
        public Transacao(Usuario envia, Usuario recebe, decimal valor)
        {
            Id = Guid.NewGuid();
            //UsuariosTransacao = [];
            //UsuariosTransacao.Add(envia);
            //UsuariosTransacao.Add(recebe);
            UsuarioEnvia = envia;
            UsuarioRecebe = recebe;
            ValorTransacao = valor;

        }

        public List<Usuario> RealizarTransacao()
        {
            List<Usuario> usuarios = [UsuarioEnvia, UsuarioRecebe];
            NumeroTransacao = Id.ToString().Replace("-", "").Trim();
            DataTransacao = DateTime.Now;
            StatusTransacao = false;
            
            if (UsuarioEnvia.TipoUsuario == 2) throw new Exception();

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
