#pragma warning disable CS8618 

namespace ServicePetCare.WebApi.Models.Requests
{
    public class AddServiceRequest
    {
        public Guid ProfileId { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
