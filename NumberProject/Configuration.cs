using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace NumberProject
{
    public class Configuration
    {
        public int MinNumberValue;
        public int MaxNumberValue;

        public Configuration()
        {
            string appsettingsPath = Path.GetFullPath(@"..\..\..\") + "appsettings.json";

            if (File.Exists(appsettingsPath))
            {
                try
                {
                    IConfiguration config = new ConfigurationBuilder().AddJsonFile(appsettingsPath).Build();

                    MinNumberValue = int.Parse(config.GetSection("MinNumberValue").Value);
                    MaxNumberValue = int.Parse(config.GetSection("MaxNumberValue").Value);
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
            }
            else
            {
                throw new FileNotFoundException("The configuration file does't exist.");
            }
        }
    }
}
