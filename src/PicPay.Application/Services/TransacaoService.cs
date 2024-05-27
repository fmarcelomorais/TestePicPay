using AutoMapper;
using PicPay.Application.DTO;
using PicPay.Application.Interfaces;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;

namespace PicPay.Application.Services
{
    public class TransacaoService : ITransacaoServices
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IMapper _mapper;
        public TransacaoService(ITransacaoRepository transacaoRepository, IMapper mapper)
        {
            _transacaoRepository = transacaoRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> BuscarUsuarioTransacao(Guid id)
        {
            var usuario = await _transacaoRepository.BuscarUsuarioTransacao(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<IEnumerable<TransacaoDTO>> TodasAsTransacoes()
        {
            var transacoes = await _transacaoRepository.TodasAsTransacoes();
            var transacoesDTO = _mapper.Map<IEnumerable<TransacaoDTO>>(transacoes);

            return transacoesDTO;
        }

        public async Task<TransacaoDTO> Transferir(UsuarioDTO enviaDTO, UsuarioDTO recebeDTO, decimal valor)
        {
            var envia = _mapper.Map<Usuario>(enviaDTO);
            var recebe = _mapper.Map<Usuario>(recebeDTO);

            var transacao = await _transacaoRepository.RealizarTransacao(envia, recebe, valor);

            return _mapper.Map<TransacaoDTO>(transacao);
        }
    }
}
