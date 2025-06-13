using ClassRoomApp.Data.Domain;
using ClassRoomApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomApp.Data.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly ApplicationDbContext _context;
        public ClassroomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddClassroomAsync(ClassRoom classroom)
        {
            await _context.ClassRooms.AddAsync(classroom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassroomAsync(int id)
        {
            var classroom = await _context.ClassRooms.FindAsync(id);
            if (classroom != null)
            {
                _context.ClassRooms.Remove(classroom);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ClassRoom>> GetAllClassroomsAsync()
        {
            return await _context.ClassRooms.ToListAsync();
        }

        public async Task<ClassRoom> GetClassroomByIdAsync(int id)
        {
            return await _context.ClassRooms
                                 .FirstAsync(c => c.Id == id);
        }

        public Task UpdateClassroomAsync(ClassRoom classRoom)
        {
            if (classRoom == null)
            {
                throw new ArgumentNullException(nameof(classRoom), "Classroom cannot be null");
            }
            _context.ClassRooms.Update(classRoom);
            return _context.SaveChangesAsync();
        }
    }
}
