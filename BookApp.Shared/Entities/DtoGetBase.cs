using BookApp.Shared.Results.Enums;

namespace BookApp.Shared.Entities
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; }
    }
}
