namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class CsdlAnnotationalModel {
        private Dictionary<string, string> _Annotations;
        public CsdlAnnotationalModel() {
        }

        internal void AddAnnotation(XAttribute attr) {
            var name = (XNamespace.Get(attr.Name.NamespaceName) + attr.Name.LocalName).ToString();
            this.GetAnnotations(true)[name] = attr.Value;
        }

        public Dictionary<string, string> GetAnnotations(bool createIfNeeded = false) {
            if (createIfNeeded) {
                return this._Annotations ?? (this._Annotations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            } else {
                return this._Annotations;
            }
        }
    }
}