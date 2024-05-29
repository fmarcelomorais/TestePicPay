using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Infraestrutura.Interfaces
{
    public interface IAutorizacaoService
    {
        Task<bool> Autorizacao(HttpClient httpClient, string baseAdreess);
    }
}
