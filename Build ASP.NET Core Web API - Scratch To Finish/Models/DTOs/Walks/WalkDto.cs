using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Walks
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double LengthInKm { get; set; }
        public string? Region_UmageUrl { get; set; }
        public Guid Difficulty_ID { get; set; }
        public Guid Region_Id { get; set; }

    }
}
