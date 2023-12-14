namespace StudyBudAPI.Entities
{
	public class Message
	{
		public int Id { get; set; }
        public string Body { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
