using PicPay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Domain.Interfaces
{
    public interface IContaRepository : IRepositoryGeneric<Conta>
    {
        Task<Conta> Depositar(Conta conta, decimal valor);
    }
}
