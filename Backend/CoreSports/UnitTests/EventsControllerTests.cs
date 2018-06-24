using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreSports.Controllers;
using CoreSports.Services.Contracts;
using CoreSports.Services.Models;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using Xunit;

namespace UnitTests
{
    public class EventsControllerTests
    {
        [Fact]
        public void PassValidFile_ShouldCallMappingService()
        {
            // Arrange
            var dataMock = new Mock<IUnitOfWork>();
            var mappingServiceMock = new Mock<IMappingService>();
            var eventServiceMock = new Mock<IEventsService>();
            var formFileMock = new Mock<IFormFile>();

            var controller = new EventsController(dataMock.Object, mappingServiceMock.Object, eventServiceMock.Object);

            // Act
            var result = controller.Post(formFileMock.Object);

            // Assert
            Assert.Equal(typeof(OkResult), result.GetType());
            mappingServiceMock.Verify(m => m.MapToEvents(It.IsAny<Stream>()), Times.Once);
            eventServiceMock.Verify(e => e.Import(It.IsAny<EventCommand>()), Times.Once);
        }
    }
}
