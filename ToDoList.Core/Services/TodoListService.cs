using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Abstractions.Loggers;
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
        private readonly ILogger<TodoListService> _logger;

        public TodoListService(
            ICreateListRequestValidator createValidator,
            IAddTaskToListRequestValidator addTaskValidator,
            ITodoListRepository repository,
            ILogger<TodoListService> logger)
        {
            _createValidator = createValidator;
            _addTaskValidator = addTaskValidator;
            _repository = repository;
            _logger = logger;
        }

        public async ValueTask<Result<TodoListModel>> CreateListAsync(CreateListRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _createValidator.Validate(request);
            if (validationResult.HasError)
            {
                return validationResult;
            }

            var todoList = new TodoListModel(request.Title!);

            await _repository.CreateListAsync(todoList, cancellationToken).ConfigureAwait(false);
            _logger.Info("TodoList created {Id}", todoList.Id);

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
            request.TodoList!.TodoTasks.Add(newTask);

            await _repository.UpdateToDoListAsync(request.TodoList!, cancellationToken).ConfigureAwait(false);

            return Result.Success();
        }

        public async ValueTask<Result<TodoListModel>> GetListAsync(GetListRequest request, CancellationToken cancellationToken)
        {
            var toDoList = await _repository.GetTodoListAsync(request.Id, cancellationToken).ConfigureAwait(false);
            if (toDoList is null)
            {
                return new Exception($"List with Id: {request.Id} was not found");
            }

            return toDoList;
        }

        public async ValueTask<Result<IList<TodoListModel>>> GetListsAsync(CancellationToken cancellationToken)
        {
            var lists = await _repository.GetTodoListsAsync(cancellationToken);

            return Result < IList<TodoListModel>>.Success(lists);
        }
    }
}
