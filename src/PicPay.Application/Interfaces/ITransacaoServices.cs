using PicPay.Application.DTO;

namespace PicPay.Application.Interfaces
{
    public interface ITransacaoServices
    {
        Task<IEnumerable<TransacaoDTO>> TodasAsTransacoes();
        Task<TransacaoDTO> Transferir(UsuarioDTO envia, UsuarioDTO recebe, decimal valor);
        Task<UsuarioDTO> BuscarUsuarioTransacao(Guid id);
    }
}
