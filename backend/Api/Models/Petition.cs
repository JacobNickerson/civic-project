namespace Api.Models
{
    public enum PetitionStatus
    {
        Open = 0,
        Passed = 1,
        Failed = 2
    }
    public class Petition : Post
    {
        public required int SignatureCount { get; set; }
        public required PetitionStatus Status { get; set; }

        public required List<PetitionSignature> Signatures { get; set; } = new();  
    }
}