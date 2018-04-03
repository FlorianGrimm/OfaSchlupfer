namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EdmxModel : CsdlAnnotationalModel {
        public EdmxModel() {
            this.DataServices = new CsdlCollection<CsdlSchemaModel>((schemaModel) => { schemaModel.EdmxModel = this; });
            this.References = new List<string>();
        }

        public string Version;

        public readonly List<string> References;

        public string DataServiceVersion;

        public readonly CsdlCollection<CsdlSchemaModel> DataServices;

        public void AddCoreSchema(CsdlErrors errors) {
            if (string.Equals(this.Version, "1.0", StringComparison.InvariantCulture)) {
                CsdlSchemaModel.AddCoreV3(this, errors);
            } else if (string.Equals(this.Version, "1.1", StringComparison.InvariantCulture)) {
                CsdlSchemaModel.AddCoreV3(this, errors);
            } else if (string.Equals(this.Version, "1.2", StringComparison.InvariantCulture)) {
                CsdlSchemaModel.AddCoreV3(this, errors);
            } else if (string.Equals(this.Version, "2.0", StringComparison.InvariantCulture)) {
                CsdlSchemaModel.AddCoreV3(this, errors);
            } else if (string.Equals(this.Version, "3.0", StringComparison.InvariantCulture)) {
                CsdlSchemaModel.AddCoreV3(this, errors);
            } else if (string.Equals(this.Version, "4.0", StringComparison.InvariantCulture)) {
                CsdlSchemaModel.AddCoreV4(this, errors);
            } else if (string.Equals(this.Version, "4.01", StringComparison.InvariantCulture)) {
                CsdlSchemaModel.AddCoreV4(this, errors);
            } else {
                errors.AddError($"Unknown Version '{this.Version}'.");
            }
        }


        public List<CsdlSchemaModel> Find(string name) {
            var result = new List<CsdlSchemaModel>();
            foreach (var schema in this.DataServices) {
                if (string.Equals(schema.Namespace, name, StringComparison.OrdinalIgnoreCase)) {
                    result.Add(schema);
                    continue;
                }
            }
            return result;
        }

        public List<Tuple<string, CsdlSchemaModel>> FindStart(string name) {
            var result = new List<Tuple<string, CsdlSchemaModel>>();
            foreach (var schema in this.DataServices) {
                var val = schema.Namespace;
                var len = val.Length;
                if (name.StartsWith(val)) {
                    if (name.Length == len) {
                        result.Add(Tuple.Create<string, CsdlSchemaModel>(string.Empty, schema));
                    } else if (name[len] == '.') {
                        result.Add(Tuple.Create<string, CsdlSchemaModel>(name.Substring(len + 1), schema));
                    }
                }
            }
            return result;
        }

        public void ResolveNames(CsdlErrors errors) {
            if (this.Find("Edm").Count==0) {
                this.AddCoreSchema(errors);
            }
            foreach (var schema in this.DataServices) {
                schema.ResolveNames(errors);
            }
        }
    }
}
