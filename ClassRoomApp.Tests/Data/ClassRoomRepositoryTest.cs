using ClassRoomApp.Data.Domain;
using ClassRoomApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit; // Required for [Fact] and Assert

namespace ClassRoomApp.Tests.Data
{
    public class ClassRoomRepositoryTest
    {

        private ApplicationDbContext GetInMemoryDbContext()
        {
            // Set up the in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_ClassroomDb" + System.Guid.NewGuid())
            .Options;
            return new ApplicationDbContext(options);

        }

        private readonly ClassroomRepository _classroomRepository;

        public ClassRoomRepositoryTest() { 
            var classRoomDbContext = GetInMemoryDbContext();
            _classroomRepository = new ClassroomRepository(classRoomDbContext);
        }

        [Fact]
        public async Task GetAllClassRoomAsync_ShouldReturnEmptyList_WhenNoClassRoomsExist()
        {
            //Arrange 
            var expectedCount = 0;
            //Act 
            var result = await _classroomRepository.GetAllClassroomsAsync();

            //Assert 
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.Equal(expectedCount, result.Count());

        }
        [Fact]
        public async Task GetAllClassRoomsAsync_ReturnsAllClassRooms()
        {
            //Arrange 
            var context = GetInMemoryDbContext();
            context.ClassRooms.AddRange(
                new ClassRoom { Id = 1,Name="Room A"},
                new ClassRoom { Id=2, Name = "Room B"}
                );

            await context.SaveChangesAsync();

            var repository = new ClassroomRepository(context);

            //Act 
            var result = await repository.GetAllClassroomsAsync();

            //Assert 
            Assert.NotNull(result );
            Assert.Equal(2,result.Count());
            Assert.Contains(result, r => r.Name == "Room A");
            Assert.Contains(result, r => r.Name == "Room B");

        }
        // Update Test
        [Fact]
        public async Task UpdateClassroomAsync_ShouldUpdateClassroomName()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var classroom = new ClassRoom { Id = 1, Name = "Original Name" };
            context.ClassRooms.Add(classroom);
            await context.SaveChangesAsync();

            var repository = new ClassroomRepository(context);

            // Modify the name
            classroom.Name = "Updated Name";

            // Act
            await repository.UpdateClassroomAsync(classroom);
            var updatedClassroom = await context.ClassRooms.FindAsync(1);

            // Assert
            Assert.NotNull(updatedClassroom);
            Assert.Equal("Updated Name", updatedClassroom.Name);
        }

    }
}
