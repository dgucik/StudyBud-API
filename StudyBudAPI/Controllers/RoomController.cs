using Microsoft.AspNetCore.Mvc;
using StudyBudAPI.Models;
using StudyBudAPI.Services;

namespace StudyBudAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoomController : ControllerBase
	{
		private readonly IRoomService _service;

		public RoomController(IRoomService service)
        {
			_service = service;
        }

		[HttpGet]
		public ActionResult<IEnumerable<RoomDto>> GetRooms()
		{
			var rooms = _service.GetRooms();
			return Ok(rooms);
		}

		[HttpGet("{roomId}")]
		public ActionResult<RoomDto> GetRoomById(int roomId)
		{
			var room = _service.GetRoomById(roomId);
			return Ok(room);
		}

		[HttpPost]
		public ActionResult CreateRoom(CreateRoomDto dto)
		{
			var roomId = _service.CreateRoom(dto);
			return Created($"api/room/{roomId}", null);
		}

		[HttpDelete("{roomId}")]
		public ActionResult DeleteRoom(int roomId)
		{
			_service.DeleteRoom(roomId);
			return NoContent();
		}
    }
}
