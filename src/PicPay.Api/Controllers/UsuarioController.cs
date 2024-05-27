using Microsoft.AspNetCore.Mvc;
using PicPay.Application.DTO;
using PicPay.Application.Interfaces;
using PicPay.Domain.Models;

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
        if(!ModelState.IsValid) return BadRequest();

        var novo = await _services.Cadastrar(usuario);
        return Ok(novo);
    }

    [HttpPatch("{id:Guid}")]
    public async Task<ActionResult> Edit(Guid id, UsuarioDTO usuarioDTO) 
    {
        if (id != usuarioDTO.Id) return BadRequest();

        var sucesso = await _services.Editar(id, usuarioDTO);

        return Ok(sucesso);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id) 
    {
        var sucesso = await _services.Delete(id);
        if(sucesso) 
            return Ok();
        return BadRequest(sucesso);       
    }
}
