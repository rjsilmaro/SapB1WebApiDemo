using B1SLayer;
using SapB1WebApiDemo.Models;

namespace SapB1WebApiDemo.Services
{
    public class BusinessPartnerService : IBusinessPartnertService
    {
        private readonly SLConnection _serviceLayer;

        public BusinessPartnerService(SLConnection serviceLayer)
        {
            _serviceLayer = serviceLayer;
        }

        public async Task<BusinessPartnerDto> GetByCardCodeAsync(string cardcode)
        {
            return await _serviceLayer.Request("BusinessPartners", cardcode).GetAsync<BusinessPartnerDto>(); //GET /b1s/v1/BusinessPartners('cardcode')
        }

        public async Task<BusinessPartnerDto> CreateAsync(CreateBusinessPartnerRequest request)
        {
            var sapPayload = new
            {
                request.CardCode,
                request.CardName,
                request.CardType,
                request.Phone1,
                request.EmailAddress
            };

            return await _serviceLayer.Request("BusinessPartners").PostAsync<BusinessPartnerDto>(sapPayload); //POST /b1s/v1/BusinessPartners
        }

    }
}
