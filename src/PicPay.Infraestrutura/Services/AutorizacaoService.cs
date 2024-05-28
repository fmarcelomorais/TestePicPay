using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace PicPay.Infraestrutura.Services
{
    public class AutorizacaoService 
    {
        private readonly HttpClient _httpClient;
        private Uri _baseAdreess { get; set; }
        public AutorizacaoService(HttpClient httpClient, string baseAdreess)
        {
            _httpClient = httpClient;
            _baseAdreess = new Uri(baseAdreess);
        }

        public async Task<bool> Autorizacao()
        {
            _httpClient.BaseAddress = _baseAdreess;
            var response = await _httpClient.GetAsync("");
            
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if(jsonResponse.Contains("success"))
                return true;
            return false;
        }
    }
}
