using System;
using System.Collections.Generic;

namespace BackendCore.Common.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        private static string mensajeBase = "Una o más condiciones no se han cumplido";

        public string FormatedMessages { get; set; }
        public List<string> Messages { get; set; }


        public BusinessException() :base(mensajeBase)
        {
            this.Messages = new List<string>();
        }

        public BusinessException(List<string> mensajes) : base(mensajeBase)
        {
            this.Messages = mensajes;
            this.formatMessages();
        }

        public BusinessException(string mensaje) : base(mensaje)
        {

        }

        private void formatMessages()
        {
            this.FormatedMessages = string.Empty;
            foreach (var item in Messages)
            {
                FormatedMessages += item + Environment.NewLine;
            }
        }
    }
}
