using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Models.Domain;
using ToDoList.Core.Models.Requests;
using ToDoList.Core.Models.Results;
using Moq;
using Xunit;
using ToDoList.Core.Abstractions.Repositories;
using ToDoList.Core.Abstractions.Validators;
using ToDoList.Core.Services;
using System;
using ToDoList.Core.Abstractions.Loggers;

namespace ToDoList.Core.Tests
{
    public class TodoListService_Test
    {
        [Fact]
        public async Task CreateListAsync_ShouldReturnExpectedResult()
        {
            // Arrange
            var createValidatorMock = new Mock<ICreateListRequestValidator>();
            var addValidatorMock = new Mock<IAddTaskToListRequestValidator>();
            var repositoryMock = new Mock<ITodoListRepository>();
            var loggerMock = new Mock<ILogger<TodoListService>>();
            var cancellationToken = CancellationToken.None;

            var service = new TodoListService(createValidatorMock.Object, addValidatorMock.Object, repositoryMock.Object, loggerMock.Object);

            var createListRequest = new CreateListRequest
            {
                Title = "Test List"
            };

            var list = await service.CreateListAsync(createListRequest, cancellationToken);

            // Act
            var result = await service.CreateListAsync(createListRequest, cancellationToken);

            // Assert
            Assert.IsType<Result<TodoListModel>>(result);
            Assert.IsType<TodoListModel>(result.Value);
            Assert.NotNull(result.Value);
            createValidatorMock.Verify(x => x.Validate(createListRequest), Times.AtLeastOnce);
            addValidatorMock.Verify(x => x.Validate(null), Times.Never);
            repositoryMock.Verify(x => x.CreateListAsync(list.Value, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task CreateListAsync_ShouldThrowExceptionIfNullRequest()
        {
            // Arrange
            var createValidatorMock = new Mock<ICreateListRequestValidator>();
            var addValidatorMock = new Mock<IAddTaskToListRequestValidator>();
            var repositoryMock = new Mock<ITodoListRepository>();
            var loggerMock = new Mock<ILogger<TodoListService>>();
            var cancellationToken = CancellationToken.None;

            createValidatorMock.Setup(x => x.Validate(null)).Throws<Exception>();


            var service = new TodoListService(createValidatorMock.Object, addValidatorMock.Object, repositoryMock.Object, loggerMock.Object);

            CreateListRequest createListRequest = null;

            // Act
            void Act() => service.CreateListAsync(createListRequest, cancellationToken);

            // Assert
            var exception = Assert.Throws<Exception>(Act);
            Assert.Equal("Title can not be null.", exception.Message);

        }
    }
}

