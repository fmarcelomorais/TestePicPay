namespace PicPay.Infraestrutura.Services
{
    public class NotificacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseAdreess;
        public NotificacaoService(HttpClient httpClient, string baseAdreess)
        {
            _httpClient = httpClient;
            _baseAdreess = new Uri(baseAdreess);
            
        }

        public async Task EnviarNotificacao()
        {            
            var response = await _httpClient.PostAsync(_baseAdreess, null);
            if (!response.IsSuccessStatusCode) throw new Exception(message: "Erro ao enviar notificação.");
            response.EnsureSuccessStatusCode();           
            
        }
    }
}
