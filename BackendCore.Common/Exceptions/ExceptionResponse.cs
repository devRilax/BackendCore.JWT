using System;
using System.Collections.Generic;
using System.Text;

namespace BackendCore.Common.Exceptions
{
    [Serializable]
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public List<string> Messages { get; set; }

        public ExceptionResponse(string message)
        {
            this.Message = message;
            this.Messages = new List<string>();
        }
    }
}
