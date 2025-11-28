namespace ServicePetCare.WebApi.Models.Requests
{
    public class UpdateDogWalkingRequest
    {
        public Guid Id { get; set; }
        public int? MaxDogs { get; set; }
        public int? WalkDurationMinutes { get; set; }
    }
}
