namespace OfaSchlupfer.ODataV3 {

    using Microsoft.Extensions.DependencyInjection;

    public interface IODataV3RepositoryBuilder {
        IServiceCollection Services { get; }
    }

    public class ODataV3RepositoryBuilder : IODataV3RepositoryBuilder {
        public ODataV3RepositoryBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class ODataV3RepositoryOptions {
        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;
    using OfaSchlupfer.ODataV3;
    using Microsoft.Extensions.DependencyInjection;

    public static class ODataV3RepositoryExtension {
        public static IODataV3RepositoryBuilder AddODataV3Repository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddODataV3Repository(services, _ => { });
        public static IODataV3RepositoryBuilder AddODataV3Repository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<ODataV3RepositoryOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(OfaSchlupfer.Model.IReferenceRepositoryModelType), typeof(ODataV3RepositoryModelType));
            services.AddTransient(typeof(ODataV3RepositoryModel), typeof(ODataV3RepositoryImplementation));
            return new ODataV3RepositoryBuilder(services);
        }
    }
}