namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }  
        public string? Description { get; set; }
        public double LengthInKm { get; set; }
        public string? Region_UmageUrl { get; set; }
        public Guid Difficulty_ID { get; set; }
        public Guid Region_Id { get; set; }

        //Navigation Properties
        public Difficulty Difficulty { get; set; }
        public Ragion Ragion_Id { get; set; }

    }
}
