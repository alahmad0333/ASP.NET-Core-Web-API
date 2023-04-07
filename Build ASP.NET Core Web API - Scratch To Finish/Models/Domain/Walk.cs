namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }  
        public string? Description { get; set; }
        public double LengthInKm { get; set; }
        public string? Region_UmageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RagionId { get; set; }

        //Navigation Properties
        public Difficulty Difficulty { get; set; } = null!; 
        public Ragion Ragion { get; set; } = null!;

    }
}
