using System;
using ToDoList.Core.Abstractions.Validators;
using ToDoList.Core.Models.Requests;
using ToDoList.Core.Models.Results;

namespace ToDoList.Core.Validators
{
    public class CreateListRequestValidator : ICreateListRequestValidator
    {
        public Result Validate(CreateListRequest request)
        {
            if (request.Title is null)
            {
                return new Exception("Title can not be null.");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return new Exception("Title must not be empty.");
            }

            return Result.Success();
        }
    }
}
