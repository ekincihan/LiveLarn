using LiveLarn.Core.Infrastructure.Base;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LiveLarn.Core.Configuration
{
    public class AppConfiguration : SingletonBase<AppConfiguration>
    {
        private IConfiguration _configuration;
        public IConfiguration Configuration { get { return _configuration; } set { _configuration = value; } }
        public AppConfiguration()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            Configuration = new ConfigurationBuilder().AddJsonFile(file, false).Build();
        }
    }
}
