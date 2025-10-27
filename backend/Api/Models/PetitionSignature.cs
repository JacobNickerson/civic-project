namespace Api.Models
{
    public class PetitionSignature
    {
        public required int PetitionId { get; set; }
        public required int UserId { get; set; }

        public required Petition Petition{ get; set; }
        public required User User { get; set; }
    }
}