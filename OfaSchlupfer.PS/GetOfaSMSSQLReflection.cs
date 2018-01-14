namespace OfaSchlupfer.PS {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.Get, "OfaSMSSQLReflection")]
    public class GetOfaSMSSQLReflection : System.Management.Automation.PSCmdlet {
        [System.Management.Automation.Parameter(Mandatory = false)]
        public string ConnectionString { get; set; }

        protected override void ProcessRecord() {
            var utility = new OfaSchlupfer.MSSQLReflection.Utility();
            utility.ConnectionString = this.ConnectionString;
            this.WriteObject(utility);
            base.ProcessRecord();
        }

        // GetOfaSMSSQLReflection -Database
    }
}
