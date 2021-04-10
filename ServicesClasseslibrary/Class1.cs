using DataRepository.DataRepositoryEntities.DataRepoistoryEntityOperationsClasses;
using DataRepository.Interface.DataRepoistoryEntityOperationsInterface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesClasseslibrary
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddinterfacesonWhichServiceClassLibraryDepend(this IServiceCollection services)
        {
            services.AddSingleton<SystemSettingsOperationsInterface, SystemSettingsOperationsClass>();
            services.AddSingleton<VaccinationTypesOperationsInterface, VaccinationTypesOperationsClass>();
            services.AddSingleton<RegistrarsOperationsInterface, RegistrarsOperationsClass>();
           
            return services;
        }
    }
}
