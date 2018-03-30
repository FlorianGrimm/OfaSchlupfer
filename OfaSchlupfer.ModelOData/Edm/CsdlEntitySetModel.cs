using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class CsdlEntitySetModel : CsdlAnnotationalModel {
        private string _EntityTypeName;
        private CsdlEntityTypeModel _EntityTypeModelObject;
        public string Name;

        public CsdlEntityContainerModel EntityContainer;

        public CsdlEntitySetModel() {
        }

        [System.Diagnostics.DebuggerHidden]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CsdlSchemaModel SchemaModel { get; internal set; }

        public string EntityTypeName {
            get {
                if (this._EntityTypeModelObject == null) {
                    return this._EntityTypeName;
                } else {
                    return this._EntityTypeModelObject.Name;
                }
            }
            set {
                if (string.Equals(this._EntityTypeName, value, StringComparison.OrdinalIgnoreCase)) { return; }
                this._EntityTypeName = value;
                this._EntityTypeModelObject = null;
            }
        }
        public CsdlEntityTypeModel EntityTypeModelObject {
            get {
                if (this._EntityTypeModelObject == null && this._EntityTypeName != null) {
                    var entityContainer = this.EntityContainer;
                    var schema = entityContainer?.SchemaModel;
                    var edmxModel = schema?.EdmxModel;
                    if (edmxModel != null) {
                        try {
                            this.ResolveNames(edmxModel, schema, entityContainer, null);
                        } catch {
                        }
                    }

                }
                return this._EntityTypeModelObject;
            }
            set {
                this._EntityTypeModelObject = value;
                this._EntityTypeName = null;
            }
        }

        public void ResolveNames(EdmxModel edmxModel, CsdlSchemaModel schema, CsdlEntityContainerModel entityContainer, List<string> errors) {
            var lstNS = edmxModel.FindStart(this.EntityTypeName);
            if (lstNS.Count == 1) {
                (var localName, var schemaFound) = lstNS[0];
                var lstFound = schemaFound.FindEntityType(localName);
                if (lstFound.Count == 1) {
                    this.EntityTypeModelObject = lstFound[0];
                } else if (lstFound.Count == 0) {
                    EdmReader.AddError(errors, $"{this._EntityTypeName} not found");
                } else {
                    EdmReader.AddError(errors, $"{this._EntityTypeName} found #{lstFound.Count} times.");
                }
            } else if (lstNS.Count == 0) {
                EdmReader.AddError(errors, $"{this._EntityTypeName} namespace not found");
            } else {
                EdmReader.AddError(errors, $"{this._EntityTypeName} namespace found #{lstNS.Count} times.");
            }
        }
    }
}