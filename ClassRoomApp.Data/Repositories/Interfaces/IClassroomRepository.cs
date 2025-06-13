using ClassRoomApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomApp.Data.Repositories
{
    public interface IClassroomRepository
    {
        Task<IEnumerable<ClassRoom>> GetAllClassroomsAsync();
        Task<ClassRoom> GetClassroomByIdAsync(int id);
        Task AddClassroomAsync(ClassRoom classroom);
        Task DeleteClassroomAsync(int id);
        Task UpdateClassroomAsync(ClassRoom classRoom);
    }
}
