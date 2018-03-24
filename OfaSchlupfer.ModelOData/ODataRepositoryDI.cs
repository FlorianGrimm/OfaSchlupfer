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
    using OfaSchlupfer.ModelOData;

    public static class ODataRepositoryExtension {
        public static IODataRepositoryBuilder AddODataRepository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddODataRepository(services, _ => { });
        public static IODataRepositoryBuilder AddODataRepository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<ODataRepositoryOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(OfaSchlupfer.Model.IReferenceRepositoryModelType), typeof(ODataRepositoryModelType));
            services.AddTransient(typeof(ODataRepository), typeof(ODataRepositoryImplementation));
            return new ODataRepositoryBuilder(services);
        }
    }
}