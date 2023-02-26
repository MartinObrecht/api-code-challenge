using codeChallenge.Application.Models.Responses;

namespace codeChallenge.Application.Handlers.V1.Partner.Create
{
    public class CreatePartnerResponse : BaseResult<CreatePartnerResponse>
    {
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
    }
}