using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendCore.Business
{
    public class BaseBL
    {
        public IConfiguration _config { get; set; }

        public BaseBL(IConfiguration config)
        {
            this._config = config;
        }

       
    }
}
