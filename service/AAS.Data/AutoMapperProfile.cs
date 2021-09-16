using AutoMapper;
using AAS.Data.DTOs;
using AAS.Data.Models;

namespace AAS.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Group, GroupDto>();
            CreateMap<User, UserDto>();
            CreateMap<Business, BusinessDto>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<Schedule, ScheduleDto>();
        }
    }
}
