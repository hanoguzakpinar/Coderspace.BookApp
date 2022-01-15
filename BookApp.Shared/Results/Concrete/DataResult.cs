using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Shared.Results.Abstract;
using BookApp.Shared.Results.Enums;

namespace BookApp.Shared.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }
        public DataResult(ResultStatus resultStatus, string message, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
    }
}
