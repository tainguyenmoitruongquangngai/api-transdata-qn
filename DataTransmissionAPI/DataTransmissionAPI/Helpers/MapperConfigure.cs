using AutoMapper;
using DataTransmissionAPI.Data;
using DataTransmissionAPI.Dto;

namespace DataTransmissionAPI.Helpers
{
    public class MapperConfigure : Profile
    {
        public MapperConfigure()
        {

            //-------------Authenticatiion--------------------

            //Users
            CreateMap<AspNetUsers, UserDto>().ReverseMap();

            //Users Info
            CreateMap<AspNetUsers, UserInfoDto>()
                .ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Roles
            CreateMap<AspNetRoles, RoleDto>()
                .ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Dashboards
            CreateMap<Dashboards, DashboardDto>()
                .ForMember(dest => dest.Functions, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Functions);
                }).ReverseMap();

            //Permissions
            CreateMap<Permissions, PermissionDto>().ReverseMap();

            //Dashboard for Roles and Users
            CreateMap<UserDashboards, UserDashboardDto>().ReverseMap();
            CreateMap<RoleDashboards, RoleDashboardDto>().ReverseMap();

            //functions
            CreateMap<Functions, FunctionDto>().ReverseMap();

            //StoragePreData
            CreateMap<StoragePreData, StoragePreDataDto>()
             .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToString("yyyyMMddHHmmss")))
             .ReverseMap()
             .ForMember(dest => dest.Time, opt => opt.MapFrom(src => DateTime.ParseExact(src.Time, "yyyyMMddHHmmss", null)));


            //-------------Other mapper--------------------

        }
    }
}
