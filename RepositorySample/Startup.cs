using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RepositorySample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            CreateInitialDatabase();

            services.AddTransient<DataContext>();
            services.AddTransient<IRepository<SimpleClassObject>, SimpleRepository>();
        }

        public void CreateInitialDatabase()
        {
            using (var context = new DataContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var item = new SimpleClassObject { Name = "Simple Object Name", Value = 0 };

                var simpleRepository = new SimpleRepository(context);

                simpleRepository.AddItem(item);

                simpleRepository.Save();
            }
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}