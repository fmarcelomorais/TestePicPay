namespace PicPay.Application.DTO
{
    public class TrasnferDTO
    {
        public Guid Payer {  get; set; }
        public Guid Payee {  get; set; }
        public decimal value {  get; set; }
    }
}
