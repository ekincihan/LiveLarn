using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLarn.Core.Type
{
    public class Response<T> : IResponse where T : new()
    {
        #region Constructor
        public Response(T value)
        {
            this.IsSuccess = true;
            this.Message = string.Empty;
            this.Value = value;
        }
        public Response()
        {
            this.IsSuccess = true;
            this.Message = string.Empty;
        }
        public Response(Exception ex = null)
        {
            Exception = ex;
            if (ex != null)
            {
                if (String.IsNullOrEmpty(ex.Message) == false)
                {
                    Message = ex.Message;
                }
            }
            Exception = null;
        }

        public Response(bool isSuccess, string message, T value)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.Value = value;
        }
        #endregion

        #region Fiels
        private bool _isSuccess;
        #endregion

        #region Properties
        public bool IsSuccess
        {
            get
            {
                return _isSuccess;
            }
            set
            {
                if (Value is Exception)
                {
                    _isSuccess = false;
                }
                else
                {
                    _isSuccess = value;
                }
            }
        }

        public T Value { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
        #endregion
    }
}
