using AutoMapper;
using StudyBudAPI.Entities;
using StudyBudAPI.Models;

namespace StudyBudAPI
{
	public class StudyBudMappingProfile : Profile
	{
        public StudyBudMappingProfile()
        {
            CreateMap<Topic, TopicDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Replace("-", " ")));
                
            CreateMap<CreateTopicDto, Topic>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Replace(" ", "-")));

            CreateMap<Room, RoomDto>()
				.ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.TopicName.Replace("-", " ")));

            CreateMap<CreateRoomDto, Room>()
                .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.TopicName.Replace(" ", "-")));
        }
    }
}
