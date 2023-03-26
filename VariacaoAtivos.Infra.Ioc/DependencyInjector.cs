using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VariacaoAtivos.Infra.Data.DataConfig;
using VariacaoAtivos.Utility.Helpers;

namespace VariacaoAtivos.Infra.Ioc
{
    public class DependencyInjector
    {
        public static void Registrar(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var domain = AppDomain.CurrentDomain;

            var namespaces = new List<NamespaceTypeHelper.NamespaceInfo>()
            {
                new NamespaceTypeHelper.NamespaceInfo("VariacaoAtivos.Infra.Data","VariacaoAtivos.Infra.Data.Repository"),
                new NamespaceTypeHelper.NamespaceInfo("VariacaoAtivos.Infra.Data","VariacaoAtivos.Infra.Data.ExternalData"),
                new NamespaceTypeHelper.NamespaceInfo("VariacaoAtivos.Domain","VariacaoAtivos.Domain.Services"),
                new NamespaceTypeHelper.NamespaceInfo("VariacaoAtivos.Application","VariacaoAtivos.Application.Services"),
           };

            foreach (var ns in namespaces)
            {
                var listTypes = NamespaceTypeHelper
                    .ObtemTypesQueFacamParteDoNamespaceInformado(ns)
                    .Where(t => t.GetInterfaces().Any()).ToList();
                foreach (var typeImplementation in listTypes)
                {
                    var interfaceType = typeImplementation.GetInterface($"I{typeImplementation.Name}");
                    if (interfaceType != null)
                        serviceCollection.AddScoped(interfaceType, typeImplementation);
                }
            }

            #region Objetos de Configuração

            CreateSigletonFromConfigurationSection<YahooFinanceApiConfig>(serviceCollection, configuration, nameof(YahooFinanceApiConfig));

            #endregion
        }

        private static void CreateSigletonFromConfigurationSection<TSectionConfig>(IServiceCollection serviceCollection, IConfiguration configuration, string nameSection) where TSectionConfig : class
        {
            var sectionConfigClass = Activator.CreateInstance<TSectionConfig>();
            configuration.GetSection(nameSection).Bind(sectionConfigClass);
            serviceCollection.AddSingleton(sectionConfigClass);
        }
    }
}
