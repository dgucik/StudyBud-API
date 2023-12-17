using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyBudAPI.Entities;
using StudyBudAPI.Models;

namespace StudyBudAPI.Services
{
	public interface ITopicService
	{
		string CreateTopic(CreateTopicDto dto);
		TopicDto GetByName(string topicName);
		public IEnumerable<TopicDto> GetTopics();
	}

	public class TopicService : ITopicService
	{
		private readonly StudyBudDbContext _dbContext;
		private readonly IMapper _mapper;

		public TopicService(StudyBudDbContext dbContext, IMapper mapper)
        {
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<TopicDto> GetTopics()
		{
			var topics = _dbContext.Topics.ToList();
			var topicsDtos = _mapper.Map<List<TopicDto>>(topics);
			return topicsDtos;
		}

		public string CreateTopic(CreateTopicDto dto)
		{
			var topic = _mapper.Map<Topic>(dto);
			_dbContext.Add(topic);
			_dbContext.SaveChanges();
			return topic.Name;
		}

		public TopicDto GetByName(string topicName)
		{
			var topic = _dbContext.Topics
				.Include(x => x.Rooms)
				.FirstOrDefault(x => x.Name == topicName);

			if(topic == null)
			{
				throw new Exception("Topic not found");
			}

			var topicDto = _mapper.Map<TopicDto>(topic);

			return topicDto;
		}
	}
}
