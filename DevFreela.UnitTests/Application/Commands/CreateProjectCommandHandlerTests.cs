using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOK_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepository = new Mock<IProjectRepository>();
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Teste 01",
                Description = "Um descrição",
                TotalCost = 504521,
                IdCliente = 1,
                IdFreelance = 2
            };
            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

            // Act 
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);
            projectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
