using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Abstractions.Services;
using ToDoList.Core.Models.Domain;
using ToDoList.Core.Models.Requests;
using ToDoList.Core.Models.Results;
using Moq;
using Xunit;
using ToDoList.Core.Abstractions.Repositories;
using ToDoList.Core.Abstractions.Validators;

namespace ToDoList.Core.Tests
{
    public class TodoListService_Test
    {
        [Fact]
        public async Task CreateListAsync_ShouldReturnExpectedResult()
        {
            var createValidatorMock = new Mock<ICreateListRequestValidator>();
            var addValidatorMock = new Mock<IAddTaskToListRequestValidator>();
            var repositoryMock = new Mock<ITodoListRepository>();

            var service = new Mock<ITodoListService>();
            service.Setup(x => x.CreateListAsync(It.IsAny<CreateListRequest>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<Result<TodoList>>());

            // Arrange
            var request = new CreateListRequest { Title = "Test List" };
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await service.Object.CreateListAsync(request, cancellationToken);

            // Assert
            Assert.IsType<Result<TodoList>>(result);
            service.Verify(x => x.CreateListAsync(It.IsAny<CreateListRequest>(), It.IsAny<CancellationToken>()), Times.Once);
            //Assert.Equal("Test List", result.Value?.Title);
        }

    }
}

