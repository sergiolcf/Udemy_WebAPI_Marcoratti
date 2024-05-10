using Api_Exec_2.Context.Interface;
using Api_Exec_2.Context.Service;
using Api_Exec_2.DependencyInjection.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api_Exec_2.DependencyInjection.Service
{
    public class DependencyInjection : IDependencyInjection
    {
        public void RegisterServices(IServiceCollection services, string mySqlConnection)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
        }
    }
}
