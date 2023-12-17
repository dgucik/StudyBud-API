using Microsoft.AspNetCore.Mvc;
using StudyBudAPI.Entities;
using StudyBudAPI.Models;
using StudyBudAPI.Services;

namespace StudyBudAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TopicController : ControllerBase
	{
		private readonly ITopicService _service;

		public TopicController(ITopicService service)
		{
			_service = service;
		}

		[HttpGet]
		public ActionResult<IEnumerable<TopicDto>> GetAllTopics()
		{
			var topics = _service.GetTopics();
			return Ok(topics);
		}

		[HttpPost]
		public ActionResult CreateTopic([FromBody] CreateTopicDto dto)
		{
			var topicName = _service.CreateTopic(dto);
			return Created($"/api/topic/{topicName}", null);
		}

		[HttpGet("{topicName}")]
		public ActionResult<TopicDto> GetByName([FromRoute] string topicName) 
		{
			var topic = _service.GetByName(topicName);
			return Ok(topic);
		}
	}
}
