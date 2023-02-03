using Microsoft.EntityFrameworkCore;
using TodoList.DataAccess.Database.DbContexts;
using ToDoList.Core.Abstractions.Repositories;
using ToDoList.Core.Models.Domain;

namespace TodoList.DataAccess.Database.Repositories
{
    public class SqliteTodoListRepository : ITodoListRepository
    {
        private readonly TodoListDbContext _context;

        public SqliteTodoListRepository(TodoListDbContext context)
        {
            _context = context;
        }

        public async ValueTask CreateListAsync(TodoListModel list, CancellationToken cancellationToken)
        {
            await _context.TodoLists.AddAsync(list, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask UpdateToDoListAsync(TodoListModel todoList, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask<TodoListModel?> GetTodoListAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async ValueTask<IList<TodoListModel>> GetTodoListsAsync(CancellationToken cancellationToken)
        {
            return await _context.TodoLists.ToListAsync(cancellationToken);
        }
    }
}
