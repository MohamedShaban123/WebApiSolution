using AutoMapper;
using WebApi.Data.Models;
using WebApi.Dtos;
using WebApi.Enums;

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
            CreateMap<HrIndex, HrIndexDtoPost>()
            .ForMember(dest => dest.arName, opt => opt.MapFrom(src => src.ArName))
            .ForMember(dest => dest.indexType, opt => opt.MapFrom(src => ParseIndexType(src.IndexType)))
            .ReverseMap();



            CreateMap<HrAsset, HrAssetDto>().ReverseMap();
            CreateMap<HrAsset, HrAssetDtoPost>().ReverseMap();





            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch != null ? src.Branch.Name : null))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.ArName : null))
                .ForMember(dest => dest.JobName, opt => opt.MapFrom(src => src.Job != null ? src.Job.ArName : null))
                .ForMember(dest => dest.NationalityName, opt => opt.MapFrom(src => src.Nationality != null ? src.Nationality.ArName : null))
                .ForMember(dest => dest.MaritalStatusName, opt => opt.MapFrom(src => src.MaritalStatus != null ? src.MaritalStatus.ArName : null))
                .ForMember(dest => dest.BloodTypeName, opt => opt.MapFrom(src => src.BloodType != null ? src.BloodType.ArName : null))
                .ForMember(dest => dest.FacultyName, opt => opt.MapFrom(src => src.Faculty != null ? src.Faculty.ArName : null))
                .ForMember(dest => dest.SectorName, opt => opt.MapFrom(src => src.Sector != null ? src.Sector.ArName : null))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City != null ? src.City.ArName : null))
                .ReverseMap();

    


        }

        private static IndexType ParseIndexType(string? indexType)
        {
            return Enum.TryParse<IndexType>(indexType, true, out var result) ? result : IndexType.Unknown;
        }
    }
}
