using PicPay.Infraestrutura.Interfaces;
using System.Net.Http;

namespace PicPay.Infraestrutura.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private HttpClient _httpClient { get; set; }
        private Uri _baseAdreess {  get; set; }

        public async Task<bool> EnviarNotificacao(HttpClient httpClient, string baseAdreess)
        {
            _httpClient = httpClient;
            _baseAdreess = new Uri(baseAdreess);

            var response = await _httpClient.PostAsync(_baseAdreess, null);
            if (response.IsSuccessStatusCode) 
               return true;
            return false;           
            
        }
    }
}
