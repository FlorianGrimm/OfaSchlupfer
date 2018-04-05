namespace OfaSchlupfer.ModelOData.SPO {
    using Microsoft.Extensions.DependencyInjection;

    public interface ISharePointOnlineCredentialsBuilder {
        IServiceCollection Services { get; }
    }

    public class SharePointOnlineCredentialsBuilder : ISharePointOnlineCredentialsBuilder {
        public SharePointOnlineCredentialsBuilder(IServiceCollection services) {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }
    public class SharePointOnlineCredentialsOptions {
        public Microsoft.Extensions.Logging.ILogger Logger { get; set; }
    }
}
namespace Microsoft.Extensions.DependencyInjection {
    using System;
    using OfaSchlupfer.ModelOData.SPO;

    public static class SharePointOnlineCredentialsExtension {
        public static ISharePointOnlineCredentialsBuilder AddSharePointOnlineCredentials(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) => AddSharePointOnlineCredentials(services, _ => { });
        public static ISharePointOnlineCredentialsBuilder AddSharePointOnlineCredentials(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Action<SharePointOnlineCredentialsOptions> configure) {
            services.Configure(configure);
            services.AddSingleton(typeof(ISharePointOnlineClientFactory), typeof(SharePointOnlineFactory));
            return new SharePointOnlineCredentialsBuilder(services);
        }
    }
}