using AutoMapper;
using EventManagementAPI.Data.Models;
using EventManagementAPI.DTOs;

namespace EventManagementAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Event Mapping
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<CreateEventDTO, Event>();

            // Participant mapping
            CreateMap<Participant, ParticipantDTO>().ReverseMap();
            CreateMap<CreateParticipantDTO, Participant>();

            // Session mapping
            CreateMap<Session, SessionDTO>().ReverseMap();
            CreateMap<CreateSessionDTO, Session>();

            // Speaker mapping
            CreateMap<Speaker, SpeakerDTO>().ReverseMap();
            CreateMap<CreateSpeakerDTO, Speaker>();
        }
    }
}
