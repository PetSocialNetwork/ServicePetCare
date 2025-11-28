namespace ServicePetCare.WebApi.Models.Responses
{
    public class DogWalkingServiceResponse
    {
        public Guid Id { get; init; }
        public Guid ServiceId { get; set; }
        public int? MaxDogs { get; set; }
        public int? WalkDurationMinutes { get; set; }
    }
}
