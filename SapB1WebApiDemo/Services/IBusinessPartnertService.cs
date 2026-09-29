using SapB1WebApiDemo.Models;

namespace SapB1WebApiDemo.Services
{
    public interface IBusinessPartnertService
    {
        Task<BusinessPartnerDto> GetByCardCodeAsync(string cardCode);

        Task<BusinessPartnerDto> CreateAsync(CreateBusinessPartnerRequest request);
    }
}
