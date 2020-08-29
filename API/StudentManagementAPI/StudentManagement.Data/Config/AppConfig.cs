using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Data.Config
{
    public static class AppConfig
    {
        private static IConfiguration currentConfig; 
        public static void SetConfig(IConfiguration configuration)
        {
            currentConfig = configuration;
        }
        
        public static string GetConfiguration(string configKey)
        {
            string connectionString = currentConfig.GetConnectionString(configKey);
            return connectionString;
        }
    }
}
