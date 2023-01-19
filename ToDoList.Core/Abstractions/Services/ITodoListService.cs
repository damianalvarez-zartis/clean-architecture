﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Core.Models.Domain;
using ToDoList.Core.Models.Requests;
using ToDoList.Core.Models.Results;

namespace ToDoList.Core.Abstractions.Services
{
    public interface ITodoListService
    {
        ValueTask<Result> AddTaskToListAsync(AddTaskToListRequest request, CancellationToken cancellationToken);
        ValueTask<Result<TodoListModel>> CreateListAsync(CreateListRequest request, CancellationToken cancellationToken);
        ValueTask<Result<TodoListModel>> GetListAsync(GetListRequest request, CancellationToken cancellationToken);
        ValueTask<Result<IList<TodoListModel>>> GetListsAsync(CancellationToken cancellationToken);
    }
}