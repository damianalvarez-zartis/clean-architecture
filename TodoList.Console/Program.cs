using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoList.DataAccess.Database.DbContexts;
using TodoList.DataAccess.Database.Repositories;
using TodoList.Infrastructure.Loggers;
using ToDoList.Core.Abstractions.Services;
using ToDoList.Core.Extensions;

// TODO: extract to an extension method (Configuration)
var serviceCollection = new ServiceCollection();

serviceCollection.ConfigureInjection();

//serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Repositories.ITodoListRepository, InMemoryTodoListRepository>();
serviceCollection.AddSingleton<ToDoList.Core.Abstractions.Repositories.ITodoListRepository, SqliteTodoListRepository>();

serviceCollection.AddDbContext<TodoListDbContext>(
    options => options.UseSqlite("Data Source=C:\\repos\\training\\clean-architecture\\TodoList.DataAccess.Database\\LocalDatabase.db"));

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
//var creationResult = await todoService.CreateListAsync(new ToDoList.Core.Models.Requests.CreateListRequest
//{
//    Title = "My new list",
//},
//ctx);

//var listResult = await todoService.GetListAsync(
//    new ToDoList.Core.Models.Requests.GetListRequest { Id = creationResult.Value!.Id },
//    ctx);

var getResult = await todoService.GetListsAsync(CancellationToken.None);

logger.Info("Exiting the program...");
