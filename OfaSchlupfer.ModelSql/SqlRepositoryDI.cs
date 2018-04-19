namespace OfaSchlupfer.ModelSql {

    using Microsoft.Extensions.DependencyInjection;

    public interface ISqlRepositoryBuilder {
        IServiceCollection Services { get; }
    }

    public class SqlRepositoryBuilder : ISqlRepositoryBuilder {
        public SqlRepositoryBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }

    public class SqlRepositoryOptions {
        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }
    }
}

namespace Microsoft.Extensions.DependencyInjection {
    using System;
    using OfaSchlupfer.ModelSql;
    using Microsoft.Extensions.DependencyInjection;

    public static class SqlRepositoryExtension {
        public static ISqlRepositoryBuilder AddSqlRepository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddSqlRepository(services, _ => { });
        public static ISqlRepositoryBuilder AddSqlRepository(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<SqlRepositoryOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(OfaSchlupfer.Model.IReferencedRepositoryModelType), typeof(SqlRepositoryModelType));
            services.AddTransient(typeof(SqlRepositoryModel), typeof(SqlRepositoryImplementation));
            return new SqlRepositoryBuilder(services);
        }
    }
}