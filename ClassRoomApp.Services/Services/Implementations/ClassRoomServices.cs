using ClassRoomApp.Data.Domain;
using ClassRoomApp.Data.Repositories;
using ClassRoomApp.Services.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//test git test git test git test git
namespace ClassRoomApp.Services
{
    public class ClassRoomServices : IClassRoomService
    {
        private readonly IClassroomRepository _classRoomRepositories;

        public ClassRoomServices(IClassroomRepository classRoomRepositories) 
            {
            _classRoomRepositories = classRoomRepositories;
            }

        public async Task<List<ClassRoomDTO>> GetAllClassromAsync()
        {
            var classRoomsEntities = await _classRoomRepositories.GetAllClassroomsAsync();
            var list = classRoomsEntities.Select(entity => new ClassRoomDTO { 
                Id = entity.Id,
                Name = entity.Name,
                ClassCode = entity.ClassCode,
                Description = entity.Description,        
            }).ToList();

            return list;
        }

        public async Task<ClassRoomDTO> GetClassroomByIdAsync(int id)
        {
            var classRoomEntity = await _classRoomRepositories.GetClassroomByIdAsync(id);
            if (classRoomEntity == null)
            {
                return null;
            }
            var classRoomDto = new ClassRoomDTO
            {
                Id = classRoomEntity.Id,
                Name = classRoomEntity.Name,
                ClassCode = classRoomEntity.ClassCode,
                Description = classRoomEntity.Description
            };
            return classRoomDto;
        }
        
        public async Task CreateCLassroomAsync(ClassRoomDTO classroom)
        {
            var clsroom = new ClassRoom
            {
                Name = classroom.Name,
                Description = classroom.Description,
                ClassCode = classroom.ClassCode
            };

            await _classRoomRepositories.AddClassroomAsync(clsroom);
        }

        public Task DeleteCLassroomAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClassroomAsync(ClassRoomDTO classroom, int id)
        {
            throw new NotImplementedException();
        }
    }
}
