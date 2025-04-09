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

            // Pour Location
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<CreateLocationDTO, Location>();

            // Pour Room
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<CreateRoomDTO, Room>();

            // Pour Rating
            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<CreateRatingDTO, Rating>();

            // SessionSpeaker mapping
            CreateMap<SessionSpeaker, SessionSpeakerDTO>().ReverseMap();
            CreateMap<CreateSessionSpeakerDTO, SessionSpeaker>();
        }
    }
}
