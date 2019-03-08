using ClientReport.DAL.Interface;
using ClientReport.DAL.Repositories;
using ClientReport.Service.Interface.Mappers;
using ClientReport.Service.Interface.Processors;
using ClientReport.Service.Mappers;
using ClientReport.Service.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace ClientReport.IoC
{
    public class AppConfigurations
    {
        public AppConfigurations(IServiceCollection services)
        {
            services.AddScoped<IMonthRepository, MonthRepository>();
            services.AddScoped<IMonthProcessor, MonthProcessor>();

            services.AddSingleton<IClientMapper, ClientMapper>();
        }
    }
}
