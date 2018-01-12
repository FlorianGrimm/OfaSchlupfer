namespace OfaSchlupfer.Service {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;

    public partial class OfaSWindowsService : ServiceBase {
        public OfaSWindowsService() {
            this.InitializeComponent();
        }

        protected override void OnStart(string[] args) {
        }

        protected override void OnStop() {
        }
    }
}
