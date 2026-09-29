using System.ComponentModel.DataAnnotations;

namespace SapB1WebApiDemo.Models
{
    public class CreateBusinessPartnerRequest
    {
        [Required]
        public string CardCode { get; set; } = string.Empty;
        [Required]
        public string CardName { get; set; } = string.Empty;
        [Required]
        public string CardType { get; set; } = string.Empty;
        public string? Phone1 { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
