using StudyBudAPI.Entities;

namespace StudyBudAPI.Models
{
	public class RoomDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }
		public string TopicName { get; set; }
		//public List<Message> Messages { get; set; }
	}
}
