namespace Api.Models
{
    public enum PetitionStatus
    {
        PendingVerification = 0,
        Open = 1,
        Passed = 2,
        Failed = 3
    }
    public class Petition : Post
    {
        public int SignatureCount { get; set; }
        public PetitionStatus Status { get; set; }

        public required List<PetitionSignature> Signatures { get; set; } = new();  
    }
}