using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.BusinessLayer.Services
{
    static public class ReadStrings
    {
        
        public static string ConnectionString()
        {      
                ConfigurationManager configuration = new();
                configuration.AddJsonFile("appsettings.json");
                return configuration.GetConnectionString("WiredRSS");
            
        }
    }
}
