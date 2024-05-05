using ApiExecUm.Context.Interface;
using ApiExecUm.Context.Services;
using ApiExecUm.DependencyInjection.Interface;
using ApiExecUm.Model;
using ApiExecUm.Repositories.Interface;
using ApiExecUm.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiExecUm.DependencyInjection
{
    public class DependencyInjection : IDependencyInjection
    {
        public void RegisterServices(IServiceCollection services, string mySqlConnection)
        {
            //     services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            //options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)).LogTo(Console.WriteLine, LogLevel.Information));

            services.AddScoped(typeof(IRepositoryServices<>), typeof(RepositoryServices<>));
            services.AddScoped<IRepositoryConta<Conta>, RepositoryConta<Conta>>();
            services.AddScoped<IRepositoryContato<Contato>, RepositoryContato<Contato>>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

        }
    }
}
