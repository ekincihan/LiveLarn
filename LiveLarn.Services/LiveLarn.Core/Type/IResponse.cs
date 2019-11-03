using System;

namespace LiveLarn.Core.Type
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        Exception Exception { get; set; }
    }
}
