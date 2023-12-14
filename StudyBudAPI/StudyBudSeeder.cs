using Microsoft.EntityFrameworkCore;
using StudyBudAPI.Entities;

namespace StudyBudAPI
{
	public class StudyBudSeeder
	{
		private readonly StudyBudDbContext _dbContext;

		public StudyBudSeeder(StudyBudDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Seed()
		{
			if (_dbContext.Database.CanConnect())
			{
				var pendingMigrations = _dbContext.Database.GetPendingMigrations();
				if(pendingMigrations != null && pendingMigrations.Any())
				{
					_dbContext.Database.Migrate();
				}

				if (!_dbContext.Topics.Any())
				{
					var topics = GetTopics();
					_dbContext.Topics.AddRange(topics);
					_dbContext.SaveChanges();
				}
			}
		}

		private List<Topic> GetTopics()
		{
			return new List<Topic> {
				new Topic()
				{
					Name = "Sport"
				},
				new Topic()
				{
					Name = "Politics"
				},
				new Topic()
				{
					Name = "Films"
				}
			};
		}
	}
}
