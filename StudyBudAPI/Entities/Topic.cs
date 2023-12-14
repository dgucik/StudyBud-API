using System.ComponentModel.DataAnnotations;

namespace StudyBudAPI.Entities
{
	public class Topic
	{
		[Key]
		public string Name { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }
}
