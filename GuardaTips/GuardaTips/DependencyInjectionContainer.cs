using Domain;
using Entities;
using GuardaTips.ViewModels;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuardaTips
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services
            )
        {
            services.AddScoped(typeof(IDomain<>), typeof(TipDomain<>));
            services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));
            return services;
        }

        public static IServiceCollection ConfigureViewModels(
            this IServiceCollection services)
        {
            services.AddTransient<TipsViewModel>();
            services.AddTransient<CrearEditarTipViewModel>();
            services.AddTransient<VerTipViewModel>();
            return services;
        }
    }
}
