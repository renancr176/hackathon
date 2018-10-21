using Microsoft.Extensions.DependencyInjection;
using Extensao.Infra.Data.DataContexts;
using Extensao.Infra.Data.Transactions;
using Extensao.Domain.Repositories;
using Extensao.Infra.Data.Repositories;

namespace Extensao.Infra.CrossCuting.IoC
{
	public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IUow, Uow>();

            #region Estados
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            #endregion

            #region Municipios
            services.AddTransient<IMunicipioRepository, MunicipioRepository>();
            #endregion

            #region RankingEscolas
            services.AddTransient<IRankingEscolaRepository, RankingEscolaRepository> ();
            #endregion


        }
    }
}
