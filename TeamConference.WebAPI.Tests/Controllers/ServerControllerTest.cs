using Moq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using TeamConference.WebAPI.Controllers;
using TeamConference.WebAPI.Models;


namespace TeamConference.WebAPI.Tests.Controllers
{
    public class ServerControllerTest
    {
        [Fact]
        public void CanGetServerList()
        {
            var data = new List<Server>
            {
                new Server() {DisplayName = "Test 1"},
                new Server() {DisplayName = "Test 2"},
                new Server() {DisplayName = "Test 3"}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Server>>();
            mockSet.As<IQueryable<Server>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Server>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Server>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Server>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TeamConferenceContext>();
            mockContext.Setup(c => c.Servers).Returns(mockSet.Object);

            var serverController = new ServerController(mockContext.Object);
            var servers = await serverController.getAllServers();

            Assert.Equal(servers[0].)

        }
    }
}
