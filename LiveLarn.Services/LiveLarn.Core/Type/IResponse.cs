using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLarn.Core.Type
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        Exception Exception { get; set; }
    }
}
