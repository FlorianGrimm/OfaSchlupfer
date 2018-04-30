namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    /// <summary>
    /// Elements with annotations.
    /// </summary>
    [JsonObject]
    public class CsdlAnnotationalModel
        : FreezableObject {
        private Dictionary<string, string> _Annotations;

        public CsdlAnnotationalModel() { }

        internal void AddAnnotation(XAttribute attr) {
            var name = (XNamespace.Get(attr.Name.NamespaceName) + attr.Name.LocalName).ToString();
            this.GetAnnotations(true)[name] = attr.Value;
        }

        /// <summary>
        /// Get the annotations dictionary.
        /// </summary>
        /// <param name="createIfNeeded">create the dict if needed - ignored if frozen.</param>
        /// <returns>the dictionary or null - if frozen and not created null will be returned.</returns>
        public Dictionary<string, string> GetAnnotations(bool createIfNeeded = false) {
            if (createIfNeeded) {
                if ((object)this._Annotations != null) {
                    return this._Annotations;
                } else {
                    if (this.IsFrozen()) { return null; }
                    this._Annotations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    return this._Annotations;
                }
            } else {
                return this._Annotations;
            }
        }
    }
}