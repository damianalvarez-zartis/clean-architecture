using Microsoft.Extensions.DependencyInjection;
using ToDoList.Core.Abstractions.Services;

namespace ToDoList.Core.Extensions
{
    public static class TodoListServiceColectionExtension
    {
        public static ServiceCollection ConfigureInjection(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Abstractions.Validators.ICreateListRequestValidator, Validators.CreateListRequestValidator>();
            serviceCollection.AddSingleton<Abstractions.Validators.IAddTaskToListRequestValidator, Validators.AddTaskToListRequestValidator>();
            serviceCollection.AddScoped<ITodoListService, Services.TodoListService>();

            return serviceCollection;
        }
    }
}
