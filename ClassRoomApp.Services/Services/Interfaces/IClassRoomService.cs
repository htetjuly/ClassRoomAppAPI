using ClassRoomApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomApp.Services
{
    public interface IClassRoomService
    {
        Task<List<ClassRoomDTO>> GetAllClassromAsync();
        Task<ClassRoomDTO> GetClassroomByIdAsync(int id);
        Task CreateCLassroomAsync(ClassRoomDTO classroom);
        Task UpdateClassroomAsync(ClassRoomDTO classroom, int id);
        Task DeleteCLassroomAsync(int id);
    }
}
