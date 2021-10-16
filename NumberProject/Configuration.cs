using Microsoft.Extensions.Configuration;
using System.IO;

namespace NumberProject
{
    public class Configuration
    {
        public bool IsDefault { get; private set; }
        public int MinNumberValue { get; private set; }
        public int MaxNumberValue { get; private set; }

        public Configuration()
        {
            try
            {
                string appsettingsPath = Path.GetFullPath(@"..\..\..\") + "appsettings.json";
                IConfiguration config = new ConfigurationBuilder().AddJsonFile(appsettingsPath).Build();

                MinNumberValue = int.Parse(config.GetSection("MinNumberValue").Value);
                MaxNumberValue = int.Parse(config.GetSection("MaxNumberValue").Value);
            }
            catch
            {
                IsDefault = true;
                MinNumberValue = 0;
                MaxNumberValue = 1;
            }
        }
    }
}
