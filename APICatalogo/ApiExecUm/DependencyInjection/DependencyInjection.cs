using ApiExecUm.Context;
using ApiExecUm.Context.Interface;
using ApiExecUm.DependencyInjection.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiExecUm.DependencyInjection
{
    public class DependencyInjection : IDependencyInjection
    {
        public void RegisterServices(IServiceCollection services, string mySqlConnection)
        {
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
       options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

        }
    }
}
