using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Models.Domain;

namespace ToDoList.Core.Abstractions.Repositories
{
    public interface ITodoListRepository
    {
        Task CreateListAsync(TodoList list, CancellationToken cancellationToken);
        Task AddTaskToListAsync(TodoList list, TodoTask task, CancellationToken cancellationToken);
    }
}
