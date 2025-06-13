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

    }
}
