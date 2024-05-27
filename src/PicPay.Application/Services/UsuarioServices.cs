using AutoMapper;
using PicPay.Application.DTO;
using PicPay.Application.Interfaces;
using PicPay.Domain.Interfaces;
using PicPay.Domain.Models;

namespace PicPay.Application.Services;

public class UsuarioServices: IUsuarioServices
{
    private readonly IUsuarioRepository _repository;
    private readonly IMapper _mapper;
    public UsuarioServices(IUsuarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }

    public async Task<UsuarioDTO> Cadastrar(UsuarioDTO usuarioDto)
    {
       
        var usuario = new Usuario(usuarioDto.FullName, usuarioDto.Documento, usuarioDto.Email, usuarioDto.Senha);
        await _repository.Cadastrar(usuario);

        return usuarioDto;
    }

    public async Task<bool> Delete(Guid id)
    {
        var sucesso = await _repository.Delete(id);
        return sucesso;
    }

    public async Task<bool> Editar(Guid id, UsuarioDTO usuarioDto)
    {        

        if (UsuarioExiste(id))
        {           
            var usuarioEdit = _mapper.Map<Usuario>(usuarioDto);
            var sucesso = await _repository.Editar(usuarioEdit);
           
            return sucesso;
        }

        return false;

    }

    public async Task<UsuarioDTO> ObterPorId(Guid id)
    {
        var usuario = await _repository.ObterPorId(id);
        return _mapper.Map<UsuarioDTO>(usuario);

       // return new UsuarioDTO(usuario.Id, usuario.FullName, usuario.Documento, usuario.Email, usuario.Senha, usuario.TipoUsuario);
    }

    public async Task<IEnumerable<UsuarioDTO>> ObterTodos()
    {

        var usuarios = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);  
    }

    private bool UsuarioExiste(Guid id)
    {
        var usuario = _repository.ObterPorId(id);

        if (usuario == null) return false;
        return true;
    }

}
