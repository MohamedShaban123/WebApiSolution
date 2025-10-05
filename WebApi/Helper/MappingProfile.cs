using AutoMapper;
using WebApi.Data.Models;
using WebApi.Dtos;
using WebApi.Enums;
using WebApi.Models;

namespace WebApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            CreateMap<HrIndex, HrIndexDto>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.arName, opt => opt.MapFrom(src => src.ArName))
             .ForMember(dest => dest.indexType, opt => opt.MapFrom(src => ParseIndexType(src.IndexType)))
             .ReverseMap();
            CreateMap<HrAsset, HrAssetDto>().ReverseMap();

        }

        private static IndexType ParseIndexType(string? indexType)
        {
            return Enum.TryParse<IndexType>(indexType, true, out var result) ? result : IndexType.Unknown;
        }
    }
}
