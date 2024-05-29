using PicPay.Infraestrutura.Interfaces;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace PicPay.Infraestrutura.Services
{
    public class AutorizacaoService  : IAutorizacaoService
    {
        private HttpClient _httpClient { get; set; }
        private Uri _baseAdreess { get; set; }

        public async Task<bool> Autorizacao(HttpClient httpClient, string baseAdreess)
        {
            _httpClient = httpClient;
            _baseAdreess = new Uri(baseAdreess);
            _httpClient.BaseAddress = _baseAdreess;
            var response = await _httpClient.GetAsync("");
            
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if(jsonResponse.Contains("success"))
                return true;
            return false;
        }
    }
}
