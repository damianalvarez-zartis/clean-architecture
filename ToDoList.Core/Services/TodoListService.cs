using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Abstractions.Repositories;
using ToDoList.Core.Abstractions.Services;
using ToDoList.Core.Abstractions.Validators;
using ToDoList.Core.Models.Domain;
using ToDoList.Core.Models.Requests;
using ToDoList.Core.Models.Results;

namespace ToDoList.Core.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ICreateListRequestValidator _createValidator;
        private readonly IAddTaskToListRequestValidator _addTaskValidator;
        private readonly ITodoListRepository _repository;

        public TodoListService(
            ICreateListRequestValidator createValidator,
            IAddTaskToListRequestValidator addTaskValidator,
            ITodoListRepository repository)
        {
            _createValidator = createValidator;
            _addTaskValidator = addTaskValidator;
            _repository = repository;
        }

        public async ValueTask<Result<TodoList>> CreateListAsync(CreateListRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _createValidator.Validate(request);
            if (validationResult.HasError)
            {
                return validationResult;
            }

            var todoList = new TodoList(request.Title!);

            await _repository.CreateListAsync(todoList, cancellationToken).ConfigureAwait(false);

            return todoList;
        }

        public async ValueTask<Result> AddTaskToListAsync(AddTaskToListRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _addTaskValidator.Validate(request);
            if (validationResult.HasError)
            {
                return validationResult;
            }

            var newTask = new TodoTask(request.Task!.Description!, request.Task.IsDone, request.TodoList!);

            await _repository.AddTaskToListAsync(request.TodoList!, newTask, cancellationToken).ConfigureAwait(false);

            return Result.Success();
        }
    }
}
