namespace PicPay.Domain.Models;

public class Conta 
{
    public Guid Id { get; private set; }
    public string NumeroConta { get; private set; }
    public decimal Saldo { get; set; }
    public Usuario Usuario { get; private set; }
    public Guid UsuarioId { get; private set; }

    public Conta(Guid usuarioId)
    {
        Id = Guid.NewGuid();
        UsuarioId = usuarioId;
        Saldo = 0;
        CriaNumeroConta();
    }
    private void CriaNumeroConta()
    {
        var numero = Id.ToString().Substring(0,8).Trim();
        NumeroConta = numero;
    }
    public decimal VerificarSaldo()
    {
        return Saldo;
    }
    public bool EnviarValor(Conta conta, decimal valor)
    {

        /* Somente contas Pessoa Física pode fazer e receber transferências. */
        if (conta.Usuario.TipoUsuario != 1)
        {
            throw new Exception(message: "Logistas não podem realizar transferências.");
        }

        if (VerificarPossibilidadeDeTransferencia(valor))
        {
            conta.Saldo -= valor;
            
            return true;
        }
        return false;

    }
    public Conta ReceberValor(Conta conta, decimal valorAEnviar)
    {
        conta.Saldo += valorAEnviar;

        return conta;
    }
    public bool VerificarPossibilidadeDeTransferencia(decimal valor)
    {
        
        if (Saldo > valor)
        {
            return true;
        }

        return false;
    }
    public bool Depositar(Conta conta, decimal valor)
    {
        if (VerificaSeValorEstaCorreto(valor))
        {
            conta.Saldo += valor;
            return true;
        }
        return false;
    }
    private bool VerificaSeValorEstaCorreto(decimal valor)
    {
        if (valor < 0) 
            return false;        
        return true;
    }

}
