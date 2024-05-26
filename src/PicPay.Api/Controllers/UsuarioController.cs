using Microsoft.AspNetCore.Mvc;
using PicPay.Application.DTO;
using PicPay.Application.Interfaces;

namespace PicPay.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioServices _services;
    public UsuarioController(IUsuarioServices services)
    {
        _services = services;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
    {
        var usuarios = await _services.ObterTodos();

        return Ok(usuarios);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<UsuarioDTO>> GetUserId(Guid id)
    {
        var usuario = await _services.ObterPorId(id);
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult> Create(UsuarioDTO usuario)
    {
        var novo = await _services.Cadastrar(usuario);
        return Ok(novo);

    }

}
