using ClassRoomApp.Data.Domain;
using ClassRoomApp.Data.Repositories;
using ClassRoomApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassRoomApp.Tests.Services
{
    public class ClassRoomServiceTest
    {
        private readonly ClassRoomServices _service; 
        private readonly Mock<IClassroomRepository> _repoMock;

        public ClassRoomServiceTest()
        {
            _repoMock = new Mock<IClassroomRepository>();
            _service = new ClassRoomServices(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllClassRoomAsync_ShouldReturnListOfClassRoomDTOs()
        {
            // Arrange 
            var classRooms = new List<ClassRoom>
            {
                   new ClassRoom {Id =1, Name = "Math", ClassCode="M101",Description ="Math" },
                   new ClassRoom {Id =1, Name = "Eng", ClassCode="S101",Description ="Eng" },
            };
            _repoMock.Setup(repo => repo.GetAllClassroomsAsync()).ReturnsAsync(classRooms);

            //Act 
            var result = await _service.GetAllClassromAsync();

            //Assert 

            Assert.NotNull(result);
            Assert.Equal(2,result.Count);
            //Assert.Equal("Math", result[0].Name);
            //Assert.Equal("Eng", result[1].Name);

        }
    }
}
