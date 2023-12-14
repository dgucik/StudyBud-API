namespace StudyBudAPI.Entities
{
	public class Room
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public string TopicName { get; set; }
		public virtual Topic Topic { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
