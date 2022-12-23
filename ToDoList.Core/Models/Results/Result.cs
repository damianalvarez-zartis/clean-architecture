using System;

namespace ToDoList.Core.Models.Results
{
    public struct Result
    {
        public Exception? Error { get; }
        public bool HasError => Error != null;

        private Result(Exception? error)
        {
            Error = error;
        }

        public static Result Success() => new Result(error: null);
        public static Result Failure(Exception error) => new Result(error);

        public static implicit operator Result(Exception error) => Failure(error);
    }

    public struct Result<T> 
        where T : class
    {
        public T? Value { get; }
        public Exception? Error { get; }
        public bool HasError => Error != null;
        public bool HasValue => Value != null;

        public Result(T? value, Exception? error)
        {
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) => new Result<T>(value, error: null);
        public static Result<T> Failure(Exception error) => new Result<T>(value: null, error);

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(Exception error) => Failure(error);
        public static implicit operator Result<T>(Result result)
        {
            if (result.HasError)
            {
                Failure(result.Error!);
            }

            throw new Exception("Can not convert result without an error.");
        }
    }
}
