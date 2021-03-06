﻿namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;

    public interface IMappingNamedObject<TKey> {
        TKey GetName();
    }

    [JsonObject]
    public abstract class MappingModelObject<TThisKey, TMappingKey, TMappingValue>
        : FreezableObject
        , IMappingNamedObject<TThisKey>
        , IContainerNamedReferences
        where TMappingKey : class
        where TMappingValue : class, IMappingNamedObject<TMappingKey> {

        public static TThisKey GetName(MappingModelObject<TThisKey, TMappingKey, TMappingValue> that) => that.Name;

        [JsonIgnore]
        protected TMappingKey _SourceName;

        [JsonIgnore]
        protected TMappingValue _Source;

        [JsonIgnore]
        protected TMappingKey _TargetName;

        [JsonIgnore]
        protected TMappingValue _Target;

        [JsonIgnore]
        protected TThisKey _Name;

        [JsonIgnore]
        protected bool _Enabled;

        //[JsonIgnore]
        //protected bool _Disabled;

        [JsonIgnore]
        private bool _Generated;

        [JsonIgnore]
        private string _Comment;

        protected MappingModelObject() { }

        [JsonProperty]
        public virtual TMappingKey SourceName {
            get {
                if ((object)this._Source != null) {
                    return this._Source.GetName();
                } else {
                    return this._SourceName;
                }
            }
            set {
                this.ThrowIfFrozen();
                if (this.AreSourceNamesEqual(this._SourceName, ref value)) { return; }
                this._SourceName = value;
            }
        }

        protected virtual bool AreSourceNamesEqual(TMappingKey sourceName, ref TMappingKey value) => false;

        [JsonProperty]
        public virtual TMappingKey TargetName {
            get {
                if ((object)this._Target != null) {
                    return this._Target.GetName();
                } else {
                    return this._TargetName;
                }
            }
            set {
                this.ThrowIfFrozen();
                if (this.AreTargetNamesEqual(this._TargetName, ref value)) { return; }
                this._TargetName = value;
            }
        }

        protected virtual bool AreTargetNamesEqual(TMappingKey targetName, ref TMappingKey value) => false;
        
        [JsonIgnore]
        public virtual TMappingValue Source {
            get {
                if (((object)this._Source == null)
                    && ((object)this._SourceName != null)) {
                    this.ResolveNameSource(ModelErrors.GetIgnorance());
                }
                return this._Source;
            }
            set {
                this.ThrowIfFrozen();
                if (ReferenceEquals(this._Source, value)) { return; }
                this._Source = value;
                this._SourceName = null;
            }
        }

        //public virtual void ResolveNameSource(ModelErrors errors) { }
        public abstract void ResolveNameSource(ModelErrors errors);

        protected void ResolveNameSourceHelper<T>(T owner, Func<T, TMappingKey, List<TMappingValue>> findByKey, ModelErrors errors)
            where T : class {
            if (owner is null) { return; }
            if (((object)this._Source == null) && ((object)this._SourceName != null)) {
                var lstFound = findByKey(owner, this._SourceName);
                if (lstFound.Count == 1) {
                    this._Source = lstFound[0];
                    this._SourceName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Source {this._SourceName} not found", this.Name?.ToString(), ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Source {this._SourceName} found #{lstFound.Count} times.", this.Name?.ToString(), ResolveNameNotUniqueException.Factory);
                }
            }
        }


        [JsonIgnore]
        public virtual TMappingValue Target {
            get {
                if (((object)this._Target == null)
                    && ((object)this._TargetName != null)) {
                    this.ResolveNameTarget(ModelErrors.GetIgnorance());
                }
                return this._Target;
            }
            set {
                this.ThrowIfFrozen();
                if (ReferenceEquals(this._Target, value)) { return; }
                this._Target = value;
            }
        }

        //public virtual void ResolveNameTarget(ModelErrors errors) { }
        public abstract void ResolveNameTarget(ModelErrors errors);
        
        protected void ResolveNameTargetHelper<T>(T owner, Func<T, TMappingKey, List<TMappingValue>> findByKey, ModelErrors errors)
            where T : class {
            if (owner is null) { return; }
            if (((object)this._Target == null) && ((object)this._TargetName != null)) {
                var lstFound = findByKey(owner, this._TargetName);
                if (lstFound.Count == 1) {
                    this._Target = lstFound[0];
                    this._TargetName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Target {this._TargetName} not found", this.Name?.ToString(), ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Target {this._TargetName} found #{lstFound.Count} times.", this.Name?.ToString(), ResolveNameNotUniqueException.Factory);
                }
            }
        }

        [JsonProperty(Order = 1)]
        public virtual TThisKey Name {
            get {
                return this._Name;
            }
            set {
                this.ThrowIfFrozen();
                if (this.AreThisNamesEqual(this._Name, ref value)) { return; }
                this._Name = value;
            }
        }

        //protected virtual bool AreThisNamesEqual(TThisKey thisName, ref TThisKey value) => false;
        protected abstract bool AreThisNamesEqual(TThisKey thisName, ref TThisKey value);

        public TThisKey GetName() => this._Name;
        
        [JsonProperty(Order = 2)]
        public bool Enabled {
            get => this._Enabled;
            set => this.SetValueProperty(ref this._Enabled, value);
        }
        
        //[JsonProperty(Order = 3)]
        //public bool Disabled {
        //    get => this._Disabled;
        //    set => this.SetValueProperty(ref this._Disabled, value);
        //}

        [JsonProperty(Order = 4)]
        public bool Generated {
            get => this._Generated;
            set => this.SetValueProperty(ref this._Generated, value);
        }

        [JsonProperty(Order = 5)]
        public string Comment {
            get => this._Comment;
            set => this.SetStringProperty(ref this._Comment, value);
        }
        
        public virtual void ResolveNamedReferences(ModelErrors errors) {
            this.ResolveNameSource(errors);
            this.ResolveNameTarget(errors);
        }
    }

    [JsonObject]
    public abstract class MappingObjectString<TOwner, TValue>
        : MappingModelObject<string, string, TValue>
        where TOwner : class
        where TValue : class, IMappingNamedObject<string> {
        [JsonIgnore]
        protected TOwner _Owner;

        protected MappingObjectString() { }

        [JsonIgnore]
        public virtual TOwner Owner {
            get => this._Owner;
            set => this.SetOwner(ref this._Owner, value);
        }

        protected override bool AreSourceNamesEqual(string sourceName, ref string value)
            => MappingObjectHelper.AreNamesEqual(sourceName, ref value);

        protected override bool AreTargetNamesEqual(string targetName, ref string value)
            => MappingObjectHelper.AreNamesEqual(targetName, ref value);

        protected override bool AreThisNamesEqual(string thisName, ref string value)
            => MappingObjectHelper.AreNamesEqual(thisName, ref value);


        //protected void ResolveHelper(ref TValue thisST, ref string thisSTKey, Func<TOwner, string, FreezedList<TValue>> findByKey, ModelErrors errors) {
        //    if (((object)this._Owner != null) && ((object)this._Source == null) && ((object)this._SourceName != null)) {
        //        var lstFound = findByKey(this.Owner, this._SourceName);
        //        if (lstFound.Count == 1) {
        //            this._Source = lstFound[0];
        //            this._SourceName = null;
        //        } else if (lstFound.Count == 0) {
        //            errors.AddErrorOrThrow($"Source {this._SourceName} not found", this.Name?.ToString(), ResolveNameNotFoundException.Factory);
        //        } else {
        //            errors.AddErrorOrThrow($"Source {this._SourceName} found #{lstFound.Count} times.", this.Name?.ToString(), ResolveNameNotUniqueException.Factory);
        //        }
        //    }
        //}
    }

    public static class MappingObjectHelper {
        public static bool AreNamesEqual(string thisName, ref string value) {
            if (value == string.Empty) { value = null; }
            return (string.Equals(thisName, value, StringComparison.Ordinal));
        }

        public static bool AreNamesEqual(ModelEntityName thisName, ref ModelEntityName value) {
            return ModelUtility.Instance.ModelEntityNameEqualityComparer.Equals(thisName, value);
        }
    }
}