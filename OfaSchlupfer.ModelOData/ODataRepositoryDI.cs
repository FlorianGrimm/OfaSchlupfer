namespace OfaSchlupfer.ModelOData {
    using Microsoft.Extensions.DependencyInjection;

    public interface IODataRepositoryBuilder {
        IServiceCollection Services { get; }
    }

    public class ODataRepositoryBuilder : IODataRepositoryBuilder {
        public ODataRepositoryBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class ODataRepositoryOptions {
        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;

    using Microsoft.Extensions.DependencyInjection.Extensions;

    using OfaSchlupfer.ModelOData;
    using OfaSchlupfer.ModelOData.Edm;

    public static class ODataRepositoryExtension {
        public static IODataRepositoryBuilder AddOfaSchlupferODataRepository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddOfaSchlupferODataRepository(services, _ => { });
        public static IODataRepositoryBuilder AddOfaSchlupferODataRepository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<ODataRepositoryOptions> configure) {
            services.Configure(configure);
            services.TryAddSingleton<OfaSchlupfer.Model.IReferencedRepositoryModelType, ODataRepositoryModelType>();
            services.TryAddTransient<ODataRepository, ODataRepositoryImplementation>();            
            services.TryAddTransient<CachedMetadataResolver, CachedMetadataResolver>();
            return new ODataRepositoryBuilder(services);
        }
    }
}