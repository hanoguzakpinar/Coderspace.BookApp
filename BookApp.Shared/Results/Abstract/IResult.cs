using BookApp.Shared.Results.Enums;
using System;

namespace BookApp.Shared.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
