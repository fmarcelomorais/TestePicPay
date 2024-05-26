using AutoMapper;
using PicPay.Application.DTO;
using PicPay.Domain.Models;

namespace PicPay.Application.Mapper;

public class MapperConfigureProfile : Profile
{
    public MapperConfigureProfile()
    {
        CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        CreateMap<Conta, ContaDTO>().ReverseMap();
        CreateMap<Transacao ,TransacaoDTO>().ReverseMap(); 
    }
}
