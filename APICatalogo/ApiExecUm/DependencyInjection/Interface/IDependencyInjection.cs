namespace ApiExecUm.DependencyInjection.Interface
{
    public interface IDependencyInjection
    {
         void RegisterServices(IServiceCollection services, string mySqlConnection);
    }
}