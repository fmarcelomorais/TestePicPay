using Microsoft.AspNetCore.Mvc;
using PicPay.Application.DTO;
using PicPay.Application.Interfaces;

namespace PicPay.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly IContaServices _contaServices;
    public ContaController(IContaServices contaServices)
    {
        _contaServices = contaServices;
    }

    [HttpPost]
    public async Task<ActionResult<ContaDTO>> Create(ContaDTO contaDTO)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);

        var conta = await _contaServices.Cadastrar(contaDTO);
        return Ok(conta);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContaDTO>>> GetAll()
    {
        var contas = await _contaServices.ObterTodos();
        return Ok(contas);
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<ContaDTO>> GetById(Guid id)
    {
        var conta = await _contaServices.ObterPorId(id);
        return Ok(conta);
    }
    
    [HttpPatch("{id:Guid}")]
    public async Task<ActionResult> Edit(Guid id, ContaDTO contaDTO)
    {
        var sucesso = await _contaServices.Editar(id, contaDTO);
        if(sucesso)
            return Ok(sucesso);
        return BadRequest(sucesso);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var sucesso = await _contaServices.Delete(id);
        if(sucesso)
            return Ok(sucesso);
        return BadRequest(sucesso);
    }
    
    [HttpPost("depositar/{id:Guid}")]
    public async Task<ActionResult<ContaDTO>> Deposit(Guid id, decimal valor)
    {
        var contaDTO = await _contaServices.ObterPorId(id);
        var conta = await _contaServices.Depositar(contaDTO, valor);
        return Ok(conta);
    }
}
