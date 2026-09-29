using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapB1WebApiDemo.Models;
using SapB1WebApiDemo.Services;

namespace SapB1WebApiDemo.Controllers
{
    [Route("api/business-partners")]
    [ApiController]
    public class BusinessPartnerController : ControllerBase
    {
        private readonly IBusinessPartnertService _businessPartnerService;

        public BusinessPartnerController(IBusinessPartnertService businessPartnertService)
        {
            _businessPartnerService = businessPartnertService;
        }

        [HttpGet("{cardcode}")] //GET /api/business-partners/C0001
        public async Task<ActionResult<BusinessPartnerDto>> GetByCardCode(string cardcode)
        {
            var businessPartner = await _businessPartnerService.GetByCardCodeAsync(cardcode);

            return Ok(businessPartner);
        }

        [HttpPost]
        public async Task<ActionResult<BusinessPartnerDto>> Create(CreateBusinessPartnerRequest request)
        {
            var businessPartner = await _businessPartnerService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetByCardCode), 
                new {cardcode = businessPartner.CardCode}, 
                businessPartner
            );
        }

    }
}
