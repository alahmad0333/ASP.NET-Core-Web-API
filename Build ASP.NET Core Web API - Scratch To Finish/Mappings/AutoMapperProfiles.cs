using AutoMapper;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Reagion;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Walks;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Ragion, RegionDto>().ReverseMap();
            CreateMap<AddRegionDto, Ragion>().ReverseMap();
            CreateMap<UpdateRegionDto, Ragion>().ReverseMap();
            CreateMap<AddWalksDto,Walk>().ReverseMap();
            CreateMap<Walk,WalkDto>().ReverseMap();
        }
    }
}
