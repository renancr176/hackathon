using Microsoft.Extensions.DependencyInjection;
using Extensao.Infra.Data.DataContexts;
using Extensao.Infra.Data.Transactions;

namespace Extensao.Infra.CrossCuting.IoC
{
	public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IUow, Uow>();
            

            

        }
    }
}
