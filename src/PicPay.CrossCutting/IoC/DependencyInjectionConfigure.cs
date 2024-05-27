using Microsoft.Extensions.DependencyInjection;
using PicPay.Domain.Interfaces;
using PicPay.Infraestrutura.Repoistories;
using PicPay.Application.Mapper;
using PicPay.Application.Interfaces;
using PicPay.Application.Services;
using PicPay.Infraestrutura.Context;

namespace PicPay.CrossCutting.IoC
{
    public static class DependencyInjectionConfigure
    {
        public static IServiceCollection AddDependenyInjection(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(ServiceLifetime.Scoped);
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IContaServices, ContaServices>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<ITransacaoServices, TransacaoService>();

            services.AddAutoMapper(typeof(MapperConfigureProfile));

            return services;
        }
    }
}
