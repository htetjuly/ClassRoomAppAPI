using ClassRoomApp.Data.Repositories;
using ClassRoomApp.Services.Models;
using ClassRoomApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomService _classRoomService;
        public ClassRoomController(IClassRoomService classRoomService) { 
            
            _classRoomService = classRoomService;
        }
        [HttpGet]
        public async Task<List<ClassRoomDTO>> GetAll()
        {
            var classRooms = await _classRoomService.GetAllClassromAsync();
            return classRooms;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ClassRoomDTO dto)
        {
            await _classRoomService.CreateCLassroomAsync(dto);
            return Ok(new { message = "Classroom created successfully" });
        }
    }
}
