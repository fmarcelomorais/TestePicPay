using AutoMapper;
using PicPay.Application.DTO;
using PicPay.Application.Interfaces;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;

namespace PicPay.Application.Services
{
    public class ContaServices : IContaServices
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;
        public ContaServices(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }
       
        public async Task<ContaDTO> Cadastrar(Guid usuarioId)
        {
            var conta = new Conta(usuarioId);
            await _contaRepository.Cadastrar(conta);
            var contaDTO = _mapper.Map<ContaDTO>(conta);
            return contaDTO;
        }
        public async Task<ContaDTO> Cadastrar(ContaDTO contaDTO)
        {
            var conta = new Conta(contaDTO.UsuarioId);
            await _contaRepository.Cadastrar(conta);
            return contaDTO;
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContaDTO> Editar(Guid id, ContaDTO usuarioDto)
        {
            throw new NotImplementedException();
        }

        public Task<ContaDTO> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContaDTO>> ObterTodos()
        {
            var contas = await _contaRepository.ObterTodos();
            return _mapper.Map<IEnumerable<ContaDTO>>(contas);
        }

    }
}
