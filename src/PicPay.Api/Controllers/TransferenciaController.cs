﻿using Microsoft.AspNetCore.Mvc;
using PicPay.Application.DTO;
using PicPay.Application.Interfaces;

namespace PicPay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransacaoServices _transacao;
        public TransferenciaController(ITransacaoServices transacao)
        {
            _transacao = transacao;
        }

        [HttpPost]
        public async Task<ActionResult> Transferir(TrasnferDTO transfer)
        {
            var usuarioEnvia = await _transacao.BuscarUsuarioTransacao(transfer.Payer);
            var usuarioRecebe = await _transacao.BuscarUsuarioTransacao(transfer.Payee);
            var transacao = await _transacao.Transferir(usuarioEnvia, usuarioRecebe, transfer.value);

            return Ok(transacao);
        }
    }
}