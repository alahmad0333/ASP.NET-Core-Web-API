namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Reagion
{
    public class UpdateRegionDto
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Region_UmageUrl { get; set; }
        public DateTime? DateTime { get; set; } 
    }
}
