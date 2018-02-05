namespace OfaSchlupfer.Elementary {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DI = Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Services
    /// </summary>
    public class DIRoot {
        public static DIRoot Instance;

        public static DIRoot GetInstance() {
            if (Instance != null) { return Instance; }
            var instance = new DIRoot();
            var old = System.Threading.Interlocked.CompareExchange(ref Instance, instance, null);
            if (old == null) {
                // TODO: add services
            } else {
                // instance.Dispose
            }
            return Instance;
        }

        /// <summary>
        /// the service collection.
        /// </summary>
        public readonly DI.IServiceCollection ServiceCollection;

        public DIRoot() {
            this.ServiceCollection = new DI.ServiceCollection();
        }
    }
}
