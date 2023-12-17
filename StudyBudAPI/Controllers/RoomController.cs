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
		public ActionResult<PaginatedResult<RoomDto>> GetRooms([FromQuery] StudyBudQuery query)
		{
			var rooms = _service.GetRooms(query);
			return Ok(rooms);
		}

		[HttpGet("{roomId}")]
		public ActionResult<RoomDto> GetRoomById([FromQuery] int roomId)
		{
			var room = _service.GetRoomById(roomId);
			return Ok(room);
		}

		[HttpPost]
		public ActionResult CreateRoom([FromBody] CreateRoomDto dto)
		{
			var roomId = _service.CreateRoom(dto);
			return Created($"api/room/{roomId}", null);
		}

		[HttpDelete("{roomId}")]
		public ActionResult DeleteRoom([FromQuery] int roomId)
		{
			_service.DeleteRoom(roomId);
			return NoContent();
		}
    }
}
