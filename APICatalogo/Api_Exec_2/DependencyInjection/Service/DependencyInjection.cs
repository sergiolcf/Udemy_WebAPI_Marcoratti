using Api_Exec_2.Context.Interface;
using Api_Exec_2.Context.Service;
using Api_Exec_2.DependencyInjection.Interface;
using Api_Exec_2.Model;
using Api_Exec_2.Repositories.Interface;
using Api_Exec_2.Repositories.Service;
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

            services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryServices<>));
            services.AddScoped<IRepositoryConta<Conta>, RepositoryConta<Conta>>();
            services.AddScoped<IRepositoryContato<Contato>, RepositoryContato<Contato>>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}