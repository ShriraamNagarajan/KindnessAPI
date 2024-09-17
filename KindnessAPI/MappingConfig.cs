using AutoMapper;
using KindnessAPI.Models;
using KindnessAPI.Models.Dto;

namespace KindnessAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Act, ActCreateDto>().ReverseMap();
            CreateMap<Act, ActUpdateDto>().ReverseMap();
            CreateMap<Act, ActDto>().ReverseMap();
        }


    }
}
