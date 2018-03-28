namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EdmxModel {
        public EdmxModel() {
            this.DataServices = new List<EdmxDataService>();
            this.References = new List<string>();
        }

        public string Version;

        public readonly List<string> References;

        public string DataServiceVersion;

        public readonly List<EdmxDataService> DataServices;
    }
}
