using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoList.DataAccess.InMemory.Repositories;
using TodoList.Infrastructure.Loggers;
using ToDoList.Core.Abstractions.Services;

// TODO: extract to an extension method (Configuration)
var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Validators.ICreateListRequestValidator, ToDoList.Core.Validators.CreateListRequestValidator>();
serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Validators.IAddTaskToListRequestValidator, ToDoList.Core.Validators.AddTaskToListRequestValidator>();
serviceCollection.AddScoped<ToDoList.Core.Abstractions.Services.ITodoListService, ToDoList.Core.Services.TodoListService>();
serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Repositories.ITodoListRepository, InMemoryTodoListRepository>();

// TODO: configure EF Core and check if it's running correctly (e.g. SqliteTodoListRepository)
// TODO: install https://learn.microsoft.com/en-us/ef/core/cli/dotnet

serviceCollection.AddSingleton(typeof(ToDoList.Core.Abstractions.Loggers.ILogger<>), typeof(TodoListLogger<>));
serviceCollection.AddLogging(cfg => cfg.AddConsole());

// TODO: extract this part to an extension method (Usage)
var serviceProvider = serviceCollection.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var logger = scope.ServiceProvider.GetRequiredService<ToDoList.Core.Abstractions.Loggers.ILogger<Program>>();

logger.Info("Starting the program...");

var todoService = scope.ServiceProvider.GetRequiredService<ITodoListService>();
var ctx = CancellationToken.None;
var creationResult = await todoService.CreateListAsync(new ToDoList.Core.Models.Requests.CreateListRequest
{
    Title = "My new list",
},
ctx);

var listResult = await todoService.GetListAsync(
    new ToDoList.Core.Models.Requests.GetListRequest { Id = creationResult.Value!.Id },
    ctx);

logger.Info("Exiting the program...");
