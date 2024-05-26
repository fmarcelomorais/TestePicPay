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
        var conta = await _contaServices.Cadastrar(contaDTO);
        return Ok(contaDTO);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContaDTO>>> GetAll()
    {
        var contas = await _contaServices.ObterTodos();
        return Ok(contas);
    }

}
