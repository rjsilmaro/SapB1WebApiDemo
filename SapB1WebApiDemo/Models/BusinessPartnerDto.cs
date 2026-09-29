namespace SapB1WebApiDemo.Models
{
    public class BusinessPartnerDto
    {
        public string CardCode { get; set; } = string.Empty;
        public string CardName { get; set; } = string.Empty;
        public string Cardtype { get; set; } = string.Empty;
        public string? Phone1 { get; set; }
        public string? EmailAddress { get; set; }
    }
}
