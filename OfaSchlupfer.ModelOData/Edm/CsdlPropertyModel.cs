﻿using System;
using Newtonsoft.Json;
using OfaSchlupfer.Freezable;
using OfaSchlupfer.Model;

namespace OfaSchlupfer.ModelOData.Edm {
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    [JsonObject]
    public class CsdlPropertyModel
        : CsdlAnnotationalModel
        , IModelScalarTypeFacade {
        // parents
        [JsonIgnore]
        private CsdlEntityTypeModel _Owner;

        [JsonIgnore]
        private string _TypeName;

        [JsonIgnore]
        private CsdlScalarTypeModel _ScalarType;

        [JsonIgnore]
        private bool? _Collection;

        [JsonIgnore]
        private string _ItemTypeName;

        [JsonIgnore]
        private IModelScalarTypeFacade _ItemType;

        [JsonIgnore]
        private string _Name;
        
        [JsonIgnore]
        private bool? _Nullable;

        [JsonIgnore]
        private short? _MaxLength;

        [JsonIgnore]
        private bool? _FixedLength;

        [JsonIgnore]
        private byte? _Precision;

        [JsonIgnore]
        private byte? _Scale;

        [JsonIgnore]
        private bool? _Unicode;

        [JsonIgnore]
        private string _Collation;

        [JsonIgnore]
        private string _SRID;

        [JsonIgnore]
        private string _DefaultValue;

        [JsonIgnore]
        private string _ConcurrencyMode;

        public CsdlPropertyModel() {
            this.Nullable = true;
            this.Unicode = true;
        }


        [JsonIgnore]
        public CsdlEntityTypeModel Owner {
            get => this._Owner;
            internal set => this.SetOwner(ref this._Owner, value);
        }

        [JsonProperty]
        public string Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                this._Name = value;
            }
        }

        [JsonIgnore]
        public string ItemTypeName {
            get {
                return this._ItemTypeName;
            }
            set {
                this.ThrowIfFrozen();
                this._ItemTypeName = value;
            }
        }

        [JsonIgnore]
        public IModelScalarTypeFacade ItemType {
            get { return this._ItemType; }
            set {
                this.ThrowIfFrozen();
                this._ItemType = value;
            }
        }

        [JsonProperty]
        public bool? Collection {
            get => this._Collection;
            set => this.SetValueProperty(ref this._Collection, value);

        }


        [JsonProperty]
        public bool? Nullable {
            get => this._Nullable;
            set => this.SetValueProperty(ref this._Nullable, value);

        }

        [JsonProperty]
        public short? MaxLength {
            get => this._MaxLength;
            set => this.SetValueProperty(ref this._MaxLength, value);

        }

        [JsonProperty]
        public bool? FixedLength {
            get => this._FixedLength;
            set => this.SetValueProperty(ref this._FixedLength, value);
        }

        [JsonProperty]
        public byte? Precision {
            get => this._Precision;
            set => this.SetValueProperty(ref this._Precision, value);
        }

        [JsonProperty]
        public byte? Scale {
            get => this._Scale;
            set => this.SetValueProperty(ref this._Scale, value);

        }

        [JsonProperty]
        public bool? Unicode {
            get => this._Unicode;
            set => this.SetValueProperty(ref this._Unicode, value);

        }
        
        [JsonProperty]
        public string Collation {
            get => this._Collation;
            set => this.SetStringProperty(ref this._Collation, value);

        }

        [JsonProperty]
        public string SRID {
            get => this._SRID;
            set => this.SetStringProperty(ref this._SRID, value);

        }


        [JsonProperty]
        public string DefaultValue {
            get => this._DefaultValue;
            set => this.SetStringProperty(ref this._DefaultValue, value);

        }

        [JsonProperty]
        public string ConcurrencyMode {
            get => this._ConcurrencyMode;
            set => this.SetStringProperty(ref this._ConcurrencyMode, value);

        }

        // TODO: Collection(Edm.DateTime)
        [JsonProperty]
        public string TypeName {
            get {
                if (this._ScalarType != null) {
                    return this._ScalarType.FullName;
                } else {
                    return this._TypeName;
                }
            }
            set {
                if (value == string.Empty) { value = null; }
                if (string.Equals(this._TypeName, value, StringComparison.Ordinal)) { return; }
                this._TypeName = value;
                this._ScalarType = null;
                if (!string.IsNullOrEmpty(value)) {
                    var collectionItemTypeName = CsdlEntityCollectionTypeModel.GetCollectionItemTypeName(value);
                    this.Collection = (collectionItemTypeName != null);
                    this.ItemTypeName = collectionItemTypeName;
                    //
                }
            }
        }

        [JsonProperty]
        public CsdlScalarTypeModel ScalarType {
            get {
                if (this._ScalarType == null) {
                    this.ResolveNames(ModelErrors.GetIgnorance());
                }
                return this._ScalarType;
            }
            set {
                this.ThrowIfFrozen();
                this._ScalarType = value;
                this._TypeName = null;
            }
        }

        [JsonProperty("ScalarType")]
        public CsdlScalarTypeModel ScalarTypePersitent {
            get {
                if (this._ScalarType == null) {
                    return null;
                }
                if (this._ScalarType.Owner != null) {
                    return null;
                }
                return this._ScalarType;
            }
            set {
                this.ThrowIfFrozen();
                this._ScalarType = value;
            }
        }

        public ModelScalarType SuggestType(MetaModelBuilder metaModelBuilder) {
            {
                var scalarType = this.ScalarType;
                if (scalarType != null) {
                    return scalarType.SuggestType(this, metaModelBuilder);
                }
            }
            return null;
        }

        public void ResolveNames(ModelErrors errors) {
            this.ResolveNamesTypeName(errors);
        }

        public void ResolveNamesTypeName(ModelErrors errors) {
            if (this._ScalarType == null && this._TypeName != null) {
                EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                if (edmxModel != null) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.TypeName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindScalarType(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                            var oldEntityTypeName = this.TypeName;
                            this.ScalarType = lstFound[0];
                            var newEntityTypeName = this.TypeName;
                            if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                            }
#else
                            this._ScalarType = lstFound[0];
#endif
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorOrThrow($"{this.TypeName} not found", this.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this.TypeName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorOrThrow($"{this.TypeName} namespace not found", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this.TypeName} namespace found #{lstNS.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
#if no
        public void ResolveNamesItemTypeName(ModelErrors errors) {
            if (this._ScalarType == null && this._TypeName != null) {
                EdmxModel edmxModel = this._Owner?.Owner?.EdmxModel;
                if (edmxModel != null) {
                    var lstNS = edmxModel.FindDataServicesWithStart(this.ItemTypeName);
                    if (lstNS.Count == 1) {
                        (var localName, var schemaFound) = lstNS[0];
                        var lstFound = schemaFound.FindScalarType(localName);
                        if (lstFound.Count == 1) {
#if DevAsserts
                            var oldEntityTypeName = this.TypeName;
                            this.ScalarType = lstFound[0];
                            var newEntityTypeName = this.TypeName;
                            if (!string.Equals(oldEntityTypeName, newEntityTypeName, StringComparison.Ordinal)) {
                                throw new Exception($"{oldEntityTypeName} != {newEntityTypeName}");
                            }
#else
                            this.ScalarType = lstFound[0];
#endif
                        } else if (lstFound.Count == 0) {
                            errors.AddErrorOrThrow($"{this.TypeName} not found", this.Name, ResolveNameNotFoundException.Factory);
                        } else {
                            errors.AddErrorOrThrow($"{this.TypeName} found #{lstFound.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                        }
                    } else if (lstNS.Count == 0) {
                        errors.AddErrorOrThrow($"{this.TypeName} namespace not found", this.Name, ResolveNameNotFoundException.Factory);
                    } else {
                        errors.AddErrorOrThrow($"{this.TypeName} namespace found #{lstNS.Count} times.", this.Name, ResolveNameNotUniqueException.Factory);
                    }
                }
            }
        }
#endif
    }
}