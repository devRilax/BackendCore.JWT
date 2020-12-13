using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendCore.Dal
{
    public class BaseDal
    {
        public IConfiguration _config { get; set; }

        public string ConnectionString { get; set; }

        public BaseDal(IConfiguration configuration)
        {
            this._config = configuration;
            this.ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("Sag_test").Value;
        }
    }
}
