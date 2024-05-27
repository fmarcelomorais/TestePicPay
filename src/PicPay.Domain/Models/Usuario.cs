namespace PicPay.Domain.Models;

public class Usuario
{
    public Guid Id { get; set; }
    public string? FullName { get; private set; }
    public string Documento { get; private set; }
    public string? Email { get; private set; }
    public string? Senha { get; private set; }
    public int TipoUsuario { get; private set; }
    public Conta Conta { get; private set; }
    public List<Transacao> Transacoes { get; private set; }
    
    public Usuario() { }
    public Usuario(string fullName, string documento, string email, string senha)
    {
        FullName = fullName;
        Documento = documento;
        Email = email;
        Senha = senha;
        VerificaTipoUsuario();
    }
    public Usuario(Guid id, string fullName, string documento, string email, string senha)
    {
        Id = id;
        FullName = fullName;
        Documento = documento;
        Email = email;
        Senha = senha;
        VerificaTipoUsuario();
    }

    private void VerificaTipoUsuario()
    {
        TipoUsuario = Documento.Length > 11 ? 2 : 1;
    }


}
