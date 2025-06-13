using ClassRoomApp.Services;
using ClassRoomApp.Services.Models;
using ClassRoomApp.WebAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassRoomApp.Tests.WebAPI
{
    public class ClassRoomControllerTest
    {
        private readonly IClassRoomService _service;
        private readonly ClassRoomController _controller; 

        public ClassRoomControllerTest()
        {
            var mockService = new Mock<IClassRoomService>();
            _service = mockService.Object;
            _controller = new ClassRoomController(_service);
        }

        [Fact]
        public async Task GetAll_ReturnListOfClassRooms()
        {
            //Arrange 
            var expectedClassRooms = new List<ClassRoomDTO>
            { new ClassRoomDTO {Id = 1,Name = "Class A"},
             new ClassRoomDTO {Id = 1,Name = "Class B"}
            };
            var mockService = new Mock<IClassRoomService>(); 
            mockService.Setup(s=>s.GetAllClassromAsync()).ReturnsAsync(expectedClassRooms);
            var controller = new ClassRoomController(mockService.Object);

            //Act 
            var result = await controller.GetAll(); 

            //Assert 

            Assert.NotEmpty(result);
            Assert.Equal(expectedClassRooms.Count, result.Count);
            //Assert.Equal(ex)
        }
    }
}
