namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Region_UmageUrl { get; set; }
    }
}
