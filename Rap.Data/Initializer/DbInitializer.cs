using Microsoft.Extensions.Options;

namespace Rap.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private ApplicationDbContext _ctx;
        private string _rootPath;

        public DbInitializer(ApplicationDbContext ctx, IOptionsMonitor<InitializerOptions> options)
        {
            _ctx = ctx;
            _rootPath = options.CurrentValue.RootPath;
        }

        public void Initialize()
        {
        }
    }
}
