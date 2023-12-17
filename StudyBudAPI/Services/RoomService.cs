using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyBudAPI.Entities;
using StudyBudAPI.Models;

namespace StudyBudAPI.Services
{
	public interface IRoomService
	{
		int CreateRoom(CreateRoomDto dto);
		void DeleteRoom(int roomId);
		RoomDto GetRoomById(int roomId);
		IEnumerable<RoomDto> GetRooms();
	}

	public class RoomService : IRoomService
	{
		private readonly StudyBudDbContext _dbContext;
		private readonly IMapper _mapper;

		public RoomService(StudyBudDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<RoomDto> GetRooms()
		{
			var rooms = _dbContext.Rooms
				.Include(x => x.Messages)
				.ToList();

			var roomsDtos = _mapper.Map<List<RoomDto>>(rooms);

			return roomsDtos;
		}

		public RoomDto GetRoomById(int roomId)
		{
			var room = _dbContext.Rooms
				.FirstOrDefault(r => r.Id == roomId);

			if(room == null)
			{
				throw new Exception("Room not found");
			}

			var roomDto = _mapper.Map<RoomDto>(room);

			return roomDto;
		}

		public int CreateRoom(CreateRoomDto dto)
		{
			var newRoom = _mapper.Map<Room>(dto);
			newRoom.Created = DateTime.Now;

			var topic = _dbContext.Topics
				.FirstOrDefault(t => t.Name == newRoom.TopicName);

			if (topic == null)
			{
				topic = new Topic { Name = newRoom.TopicName };
			}

			newRoom.Topic = topic;

			_dbContext.Add(newRoom);
			_dbContext.SaveChanges();

			return newRoom.Id;
		}

		public void DeleteRoom(int roomId)
		{
			var room = _dbContext.Rooms
				.FirstOrDefault(r => r.Id  == roomId);

			if(room == null)
			{
				throw new Exception("Room not found");
			}

			_dbContext.Rooms.Remove(room);
			_dbContext.SaveChanges();
		}
	}
}
