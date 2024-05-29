using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Infraestrutura.Interfaces
{
    public interface INotificacaoService
    {
        Task<bool> EnviarNotificacao(HttpClient httpClient, string baseAdreess);
    }
}
