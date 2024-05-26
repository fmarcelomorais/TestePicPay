using PicPay.Application.DTO;
using PicPay.Domain.Models;

namespace PicPay.Application.Interfaces;

public interface IContaServices : IServicesGeneric<ContaDTO>
{
    Task<ContaDTO> Cadastrar(Guid usuarioId);
  
}
