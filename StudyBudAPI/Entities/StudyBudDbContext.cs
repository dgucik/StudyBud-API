using Microsoft.EntityFrameworkCore;

namespace StudyBudAPI.Entities
{
	public class StudyBudDbContext : DbContext
	{
        public StudyBudDbContext(DbContextOptions<StudyBudDbContext> options) : base(options)
        {
            
        }

        public DbSet<Topic> Topics { get; set; }

		public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Topic>()
				.HasKey(t => t.Name);

			modelBuilder.Entity<Room>()
				.HasKey(r => r.Id);

			modelBuilder.Entity<Room>()
				.HasOne(r => r.Topic)
				.WithMany(t => t.Rooms)
				.HasForeignKey(r => r.TopicName);

			modelBuilder.Entity<Message>()
				.HasKey(m => m.Id);

			modelBuilder.Entity<Message>()
				.HasOne(m => m.Room)
				.WithMany(r => r.Messages)
				.HasForeignKey(m => m.RoomId);
		}
	}
}
