using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping From HrIndex to HrIndexDto
            CreateMap<HrIndex, HrIndexDto>().ForMember(dest=>dest.arName,option=>option.MapFrom(source=>source.ArName))
                                            .ForMember(dest=>dest.enName,option=>option.MapFrom(source=>source.EnName));
        }
    }
}
