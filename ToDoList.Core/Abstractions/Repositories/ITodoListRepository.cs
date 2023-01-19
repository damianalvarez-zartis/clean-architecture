using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Models.Domain;

namespace ToDoList.Core.Abstractions.Repositories
{
    public interface ITodoListRepository
    {
        ValueTask CreateListAsync(TodoListModel list, CancellationToken cancellationToken);
        ValueTask UpdateToDoListAsync(TodoListModel todoList, CancellationToken cancellationToken);
        ValueTask<TodoListModel?> GetTodoListAsync(int id, CancellationToken cancellationToken);
        ValueTask<IList<TodoListModel>> GetTodoListsAsync(CancellationToken cancellationToken);
    }
}
