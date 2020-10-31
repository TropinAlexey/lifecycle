using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Extensions
{
   public static class ConfigurationExtension
    {
        private static IConfiguration _configuration;

        public static IConfiguration Configuration
        {
            get
            {
                _configuration ??= BuildConfiguration(new ConfigurationBuilder());
                return _configuration;
            }
        }

        #region Getters
        
        public static string GetDateFormat
        {
            get
            {
                string value = string.Empty;
                var section = Configuration.GetSection("ConfigurationLiterals");
                if (section != null)
                {
                    value = section["yyyy-MM-dd"];
                }

                return value;
            }
        }

        #endregion


        //Helpers
        public static string RootDirectoryPath
        {
            get { return Directory.GetCurrentDirectory(); }
        }

        private static IConfigurationRoot BuildConfiguration(IConfigurationBuilder builder)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return builder.SetBasePath(RootDirectoryPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}