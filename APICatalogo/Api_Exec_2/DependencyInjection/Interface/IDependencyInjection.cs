namespace Api_Exec_2.DependencyInjection.Interface
{
    public interface IDependencyInjection
    {
        void RegisterServices(IServiceCollection services, string mySqlConnection);
    }
}
