using Application.DataAccess.Contracts;
using Application.Models.Domain;
using Application.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;

namespace Application.Tests
{
    public class IndexModelTests
    {
        [Fact]
        public async Task OnGet_ShouldSetPropertiesAndSessionData_WhenSessionDataExists()
        {
            // Arrange
            var sectorRepositoryMock = new Mock<ISectorRepository>();
            
            var sessionDataRepositoryMock = new Mock<ISessionDataRepository>();
            
            var pageModel = new IndexModel(sectorRepositoryMock.Object, sessionDataRepositoryMock.Object);
            
            var httpContextMock = new Mock<HttpContext>();

            var sessionId = new Guid().ToString();
            
            httpContextMock.SetupGet(c => c.Session.Id).Returns(sessionId);
            
            pageModel.PageContext.HttpContext = httpContextMock.Object;

            var sessionData = new SessionData
            {
                Name = "Darth Vader",
                Consent = true,
                Sectors = new List<Sector> { new Sector { Code = 1010, Title = "Space Travel" } }
            };

            sessionDataRepositoryMock
                .Setup(repo => repo.GetBySessionIdAsync(sessionId))
                .ReturnsAsync(sessionData);
            
            // Act
            await pageModel.OnGet();

            // Assert
            Assert.Equal("Darth Vader", pageModel.Name);
            Assert.True(pageModel.Consent);
            Assert.Single(pageModel.SelectedSectors);
            Assert.Equal("1010", pageModel.SelectedSectors.First());
        }

        [Fact]
        public async Task OnPostAsync_ShouldAddOrUpdateSessionDataAndRedirect_WhenModelIsValid()
        {
            // Arrange
            var sectorRepositoryMock = new Mock<ISectorRepository>();
            
            var sessionDataRepositoryMock = new Mock<ISessionDataRepository>();
            
            var pageModel = new IndexModel(sectorRepositoryMock.Object, sessionDataRepositoryMock.Object)
            {
                Name = "Darth Vader",
                Consent = true,
                SelectedSectors = new List<string> { "1010" }
            };
            
            var httpContextMock = new Mock<HttpContext>();
            
            httpContextMock.SetupGet(c => c.Session.Id).Returns(new Guid().ToString);
            
            pageModel.PageContext.HttpContext = httpContextMock.Object;
            
            var allSectors = new List<Sector> { new Sector { Code = 1010, Title = "Space Travel" } };

            sectorRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(allSectors);
            
            // Act
            var result = await pageModel.OnPostAsync();
            
            // Assert
            sessionDataRepositoryMock.Verify(repo => 
                repo.AddOrUpdateAsync(It.Is<SessionData>(item => item.Name == "Darth Vader")), Times.Once);
            
            Assert.IsType<RedirectToPageResult>(result);
            
            var redirectToPageResult = (RedirectToPageResult) result;
            
            Assert.Equal("Index", redirectToPageResult.PageName);
        }
        
        [Fact]
        public async Task OnPostAsync_ShouldReturnPageResultWithErrorMessage_WhenSectorSelectionIsMissing()
        {
            // Arrange
            var sectorRepositoryMock = new Mock<ISectorRepository>();
            var sessionDataRepositoryMock = new Mock<ISessionDataRepository>();
            var pageModel = new IndexModel(sectorRepositoryMock.Object, sessionDataRepositoryMock.Object)
            {
                Name = "John Doe",
                Consent = true,
                SelectedSectors = new List<string>()
            };
            
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.SetupGet(c => c.Session.Id).Returns(new Guid().ToString);

            pageModel.PageContext = new PageContext();
            pageModel.PageContext.HttpContext = httpContextMock.Object;
            
            // Act
            var result = await pageModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);

            Assert.False(pageModel.ModelState.IsValid);
            Assert.Equal("You must select at least one sector.", pageModel.ModelState["SelectedSectors"].Errors[0].ErrorMessage);
        }
    }
}