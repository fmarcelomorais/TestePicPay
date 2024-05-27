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
        //public async Task<ContaDTO> Cadastrar(Guid Id)
        //{
        //    var conta = new Conta(Id);
        //    await _contaRepository.Cadastrar(conta);
        //    var contaDTO = _mapper.Map<ContaDTO>(conta);
        //    return contaDTO;
        //}
        public async Task<ContaDTO> Cadastrar(ContaDTO contaDTO)
        {
            var conta = new Conta(contaDTO.UsuarioId);
            await _contaRepository.Cadastrar(conta);
            return contaDTO;
        }
        public async Task<bool> Delete(Guid id)
        {
            var sucesso = await _contaRepository.Delete(id);
            return sucesso;
        }
        public async Task<ContaDTO> Depositar(ContaDTO contaDto, decimal valor)
        {
            var conta = _mapper.Map<Conta>(contaDto);
            var contaAtualizada = await _contaRepository.Depositar(conta, valor);

            return _mapper.Map<ContaDTO>(contaAtualizada);  

        }
        public async Task<bool> Editar(Guid id, ContaDTO usuarioDto)
        {
            var usuario = _mapper.Map<Conta>(usuarioDto);
            var sucesso = await _contaRepository.Editar(usuario);
            return sucesso;
        }
        public async Task<ContaDTO> ObterPorId(Guid id)
        {
            var conta = await _contaRepository.ObterPorId(id);
            return _mapper.Map<ContaDTO>(conta);
        }
        public async Task<IEnumerable<ContaDTO>> ObterTodos()
        {
            var contas = await _contaRepository.ObterTodos();
            return _mapper.Map<IEnumerable<ContaDTO>>(contas);
        }

    }
}
