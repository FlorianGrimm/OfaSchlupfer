﻿namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;
    using OfaSchlupfer.Entity;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;

    [JsonObject]
    public class EdmxModel
        : CsdlAnnotationalModel {
        [JsonIgnore]
        private readonly FreezableOwnedKeyedCollection<EdmxModel, string, CsdlSchemaModel> _DataServices;

        public EdmxModel() {
            this._DataServices = new FreezableOwnedKeyedCollection<EdmxModel, string, CsdlSchemaModel>(
                this,
                (item) => item.Namespace,
                StringComparer.OrdinalIgnoreCase,
                (owner, item) => { item.EdmxModel = owner; });
            this.References = new List<string>();
        }

        public string Version;

        public readonly List<string> References;

        public string DataServiceVersion;

        public FreezableOwnedKeyedCollection<EdmxModel, string, CsdlSchemaModel> DataServices => this._DataServices;

        public void AddCoreSchemaIfNeeded(ModelErrors errors) {
            if (this.FindDataServices("Edm").Count == 0) {
                this.AddCoreSchema(errors);
            }
        }

        public void AddCoreSchema(ModelErrors errors) {
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
                errors.AddErrorOrThrow($"Unknown Version '{this.Version}'.", string.Empty, ModelException.Factory);
            }
        }

        public List<CsdlSchemaModel> FindDataServices(string @namespace) => this._DataServices.FindByKey(@namespace);

        public List<Tuple<string, CsdlSchemaModel>> FindDataServicesWithStart(string name) {
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

        public void ResolveNames(ModelErrors errors) {
            if (this.FindDataServices("Edm").Count == 0) {
                this.AddCoreSchemaIfNeeded(errors);
            }
            foreach (var schema in this.DataServices) {
                schema.ResolveNames(errors);
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._DataServices.Freeze();
            }
            return result;
        }
    }
}
