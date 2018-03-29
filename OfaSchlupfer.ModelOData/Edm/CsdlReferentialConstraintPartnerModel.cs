namespace OfaSchlupfer.ModelOData.Edm {
    using System.Collections.Generic;

    [System.Diagnostics.DebuggerDisplay("{Role}")]
    public class CsdlReferentialConstraintPartnerModel : CsdlAnnotationalModel {
        public readonly CsdlCollection<CsdlPropertyRefModel> PropertyRef;
        public string Role;
        private CsdlSchemaModel _SchemaModel;

        public CsdlReferentialConstraintPartnerModel() {
            this.PropertyRef = new CsdlCollection<CsdlPropertyRefModel>((item) => { item.SchemaModel = this.SchemaModel; });
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel {
            get {
                return this._SchemaModel;
            }
            internal set {
                if (ReferenceEquals(this._SchemaModel, value)) { return; }
                this._SchemaModel = value;
                if ((object)value != null) {
                    this.PropertyRef.Broadcast();
                }
            }
        }

        public void ResolveNames(CsdlNameResolver nameResolver) {
            foreach (var propertyRef in this.PropertyRef) {
                propertyRef.ResolveNames(nameResolver);
            }
        }
    }
}