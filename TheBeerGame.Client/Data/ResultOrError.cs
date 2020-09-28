using System;

namespace TheBeerGame.Client.Data
{
    public class ResultOrError<T>
    {
        public ResultOrError(T result)
        {
            Result = result;
            IsResult = true;
        }

        public ResultOrError(Exception error)
        {
            Error = error;
            IsResult = false;
        }

        public bool IsResult { get; }

        public T Result { get; }
        public Exception Error { get; }
    }
}