using ToDoList.Core.Models.Requests;
using ToDoList.Core.Models.Results;

namespace ToDoList.Core.Abstractions.Validators
{
  public interface ICreateListRequestValidator
  {
    Result Validate(CreateListRequest request);
  }
}