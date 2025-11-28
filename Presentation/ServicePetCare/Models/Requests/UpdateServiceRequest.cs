namespace ServicePetCare.WebApi.Models.Requests
{
    public class UpdateServiceRequest
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
