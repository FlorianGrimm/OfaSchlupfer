namespace OfaSchlupfer.Service {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            bool debug = false;
            foreach (var arg in args) {
                if (string.Equals(args, "-d")) {
                    debug = true;
                }
            }
            if (debug) {

            } else {
                ServiceBase.Run(new ServiceBase[] { new OfaSWindowsService() });
            }
        }
    }
}
