using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Shared.Results.Enums
{
    public enum ResultStatus
    {
        Success,
        Error,
        Warning,
        Info,
        ValidationError,
        NotFound
    }
}
