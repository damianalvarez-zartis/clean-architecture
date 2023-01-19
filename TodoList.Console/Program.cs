using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoList.DataAccess.InMemory.Repositories;
using TodoList.Infrastructure.Loggers;
using ToDoList.Core.Abstractions.Services;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Validators.ICreateListRequestValidator, ToDoList.Core.Validators.CreateListRequestValidator>();
serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Validators.IAddTaskToListRequestValidator, ToDoList.Core.Validators.AddTaskToListRequestValidator>();
serviceCollection.AddScoped<ToDoList.Core.Abstractions.Services.ITodoListService, ToDoList.Core.Services.TodoListService>();
serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Repositories.ITodoListRepository, InMemoryTodoListRepository>();

serviceCollection.AddSingleton(typeof(ToDoList.Core.Abstractions.Loggers.ILogger<>), typeof(TodoListLogger<>));
serviceCollection.AddLogging(cfg => cfg.AddConsole());

var serviceProvider = serviceCollection.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var todoService = scope.ServiceProvider.GetRequiredService<ITodoListService>();

var creationResult = await todoService.CreateListAsync(new ToDoList.Core.Models.Requests.CreateListRequest
{
    Title = "My new list",
},
CancellationToken.None);