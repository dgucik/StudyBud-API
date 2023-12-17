using StudyBudAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudyBudAPI.Models
{
	public class CreateRoomDto
	{
		[Required]
		public string Name { get; set; }
		public string? Description { get; set; }
		[Required]
		public string TopicName { get; set; }
	}
}
