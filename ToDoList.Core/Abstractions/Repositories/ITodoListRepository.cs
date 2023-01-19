using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Models.Domain;

namespace ToDoList.Core.Abstractions.Repositories
{
    public interface ITodoListRepository
    {
        ValueTask CreateListAsync(TodoListModel list, CancellationToken cancellationToken);
        ValueTask UpdateToDoListAsync(TodoListModel todoList, CancellationToken cancellationToken);
    }
}
