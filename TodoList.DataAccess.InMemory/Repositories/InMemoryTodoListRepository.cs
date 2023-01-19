using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.DataAccess.InMemory.Extensions;
using ToDoList.Core.Abstractions.Repositories;
using ToDoList.Core.Models.Domain;

namespace TodoList.DataAccess.InMemory.Repositories
{
    public class InMemoryTodoListRepository : ITodoListRepository
    {
        private readonly ConcurrentDictionary<int, TodoListModel> _cache;
        private int _todoListIdCounter = 0;
        private int _todoListItemIdCounter = 0;

        public InMemoryTodoListRepository()
        {
            _cache = new ConcurrentDictionary<int, TodoListModel>();
        }

        public ValueTask CreateListAsync(TodoListModel list, CancellationToken cancellationToken)
        {
            var newId = Interlocked.Increment(ref _todoListIdCounter);

            list.SetId(newId);

            if (!_cache.TryAdd(newId, list))
            {
                throw new Exception("Something went wrong.");
            }

            return new ValueTask();
        }

        public ValueTask UpdateToDoListAsync(TodoListModel todoList, CancellationToken cancellationToken)
        {
            foreach (var task in todoList.Tasks)
            {
                if (task.Id == 0)
                {
                    var newId = Interlocked.Increment(ref _todoListItemIdCounter);
                    task.SetId(newId);
                }
            }

            return new ValueTask();
        }

        public ValueTask<TodoListModel?> GetTodoListAsync(int id, CancellationToken cancellationToken)
        {
            var result = _cache.GetValueOrDefault(id);

            return new ValueTask<TodoListModel?>(result);
        }

        public ValueTask<IList<TodoListModel>> GetTodoListsAsync(CancellationToken cancellationToken)
        {
            var result = _cache.Values.ToList();

            return new ValueTask<IList<TodoListModel>>(result);
        }
    }
}
