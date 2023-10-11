using AutoMapper;
using BackendSchedule.Application.DTOs;
using BackendSchedule.Domain.Entities;

namespace Catalogo.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Appointment, AppointmentDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
            .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Customer.Phone))
            .ReverseMap()
            .ForPath(src => src.Customer.Name, opt => opt.MapFrom(dest => dest.CustomerName))
            .ForPath(src => src.Customer.Email, opt => opt.MapFrom(dest => dest.CustomerEmail))
            .ForPath(src => src.Customer.Phone, opt => opt.MapFrom(dest => dest.CustomerPhone));

            CreateMap<Scheduling, SchedulingDTO>()
                .ForMember(dest => dest.StartMorning, opt => opt.MapFrom(src => src.TimePeriods.StartMorning))
                .ForMember(dest => dest.EndMorning, opt => opt.MapFrom(src => src.TimePeriods.EndMorning))
                .ForMember(dest => dest.StartAfternoon, opt => opt.MapFrom(src => src.TimePeriods.StartAfternoon))
                .ForMember(dest => dest.EndAfternoon, opt => opt.MapFrom(src => src.TimePeriods.EndAfternoon))
                .ForMember(dest => dest.StartNight, opt => opt.MapFrom(src => src.TimePeriods.StartNight))
                .ForMember(dest => dest.EndNight, opt => opt.MapFrom(src => src.TimePeriods.EndNight))
                .ReverseMap()
                .ForPath(src => src.TimePeriods.StartMorning, opt => opt.MapFrom(dest => dest.StartMorning))
                .ForPath(src => src.TimePeriods.EndMorning, opt => opt.MapFrom(dest => dest.EndMorning))
                .ForPath(src => src.TimePeriods.StartAfternoon, opt => opt.MapFrom(dest => dest.StartAfternoon))
                .ForPath(src => src.TimePeriods.EndAfternoon, opt => opt.MapFrom(dest => dest.EndAfternoon))
                .ForPath(src => src.TimePeriods.StartNight, opt => opt.MapFrom(dest => dest.StartNight))
                .ForPath(src => src.TimePeriods.EndNight, opt => opt.MapFrom(dest => dest.EndNight));

            CreateMap<Professional, ProfessionalDTO>().ReverseMap();

            CreateMap<Work, WorkDTO>()
                .ForMember(dest => dest.ProfessionalId, opt => opt.MapFrom(src => src.Professional.Id))
                .ReverseMap()
                .ForMember(dest => dest.Professional, opt => opt.Ignore())
                .ForMember(dest => dest.ProfessionalId, opt => opt.MapFrom(src => src.ProfessionalId));
        }
    }
}

