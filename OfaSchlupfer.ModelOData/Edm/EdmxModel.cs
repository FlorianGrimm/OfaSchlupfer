namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EdmxModel : CsdlAnnotationalModel {
        public EdmxModel() {
            this.DataServices = new List<CsdlSchemaModel>();
            this.References = new List<string>();
        }

        public string Version;

        public readonly List<string> References;

        public string DataServiceVersion;

        public readonly List<CsdlSchemaModel> DataServices;
    }
}
