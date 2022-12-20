using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.DataAccesLayer.Services
{
    static class ConfigService
    {
       static public string ConnectionString
        {
            get
            {
                ConfigurationManager configuration = new();
                configuration.AddJsonFile("appsettings.json");
                return configuration.GetConnectionString("SqlServer");
            }
        }

    }
}
