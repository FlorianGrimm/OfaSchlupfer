namespace OfaSchlupfer.PS {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.Get, "OfaSInformationPool")]
    public class GetOfaSInformationPool
        : System.Management.Automation.PSCmdlet {
        [System.Management.Automation.Parameter(Mandatory = false)]
        public string FileName { get; set; }

        protected override void ProcessRecord() {
            this.WriteObject("Hello World");
            base.ProcessRecord();
        }

        //GetOfaSMSSQLReflection -Database
        public string ConnectionString { get; set; }
    }
}
