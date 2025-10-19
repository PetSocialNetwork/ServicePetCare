namespace ServicePetCare.WebApi.Models.Responses
{
    public class ServiceResponse
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
