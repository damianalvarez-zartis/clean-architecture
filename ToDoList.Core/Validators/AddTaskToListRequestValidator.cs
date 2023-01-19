using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core.Abstractions.Validators;
using ToDoList.Core.Models.Requests;
using ToDoList.Core.Models.Results;

namespace ToDoList.Core.Validators
{
    public class AddTaskToListRequestValidator : IAddTaskToListRequestValidator
    {
        public Result Validate(AddTaskToListRequest request)
        {
            if (request == null)
            {
                throw new Exception("AddTaskToListRequest cannot be null");
            }

            if (request.Task == null)
            {
                throw new Exception("Task cannot be null");
            }

            if (request.Task.Description == null)
            {
                throw new Exception("Task description cannot be null");
            }
            
            if (request.TodoList == null)
            {
                throw new Exception("List cannot be null");
            }

            return Result.Success();
        }
    }
}
