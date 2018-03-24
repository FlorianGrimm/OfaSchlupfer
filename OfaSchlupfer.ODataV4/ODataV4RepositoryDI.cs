namespace OfaSchlupfer.ODataV4 {

    using Microsoft.Extensions.DependencyInjection;

    public interface IODataV4RepositoryBuilder {
        IServiceCollection Services { get; }
    }

    public class ODataV4RepositoryBuilder : IODataV4RepositoryBuilder {
        public ODataV4RepositoryBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class ODataV4RepositoryOptions {
        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;
    using OfaSchlupfer.ODataV4;
    using Microsoft.Extensions.DependencyInjection;

    public static class ODataV4RepositoryExtension {
        public static IODataV4RepositoryBuilder AddODataV4Repository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddODataV4Repository(services, _ => { });
        public static IODataV4RepositoryBuilder AddODataV4Repository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<ODataV4RepositoryOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(OfaSchlupfer.Model.IReferenceRepositoryModelType), typeof(ODataV4RepositoryModelType));
            services.AddTransient(typeof(ODataV4RepositoryModel), typeof(ODataV4RepositoryImplementation));
            return new ODataV4RepositoryBuilder(services);
        }
    }
}