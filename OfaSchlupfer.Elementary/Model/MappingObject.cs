﻿namespace OfaSchlupfer.Model {
    using System;
    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;

    public interface IMappingNamedObject<TKey> {
        TKey GetName();
    }

    [JsonObject]
    public class MappingObject<TThisKey, TMappingKey, TMappingValue>
        : FreezeableObject
        , IMappingNamedObject<TThisKey>
        where TMappingKey : class
        where TMappingValue : class, IMappingNamedObject<TMappingKey> {

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

        public MappingObject() { }

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
                    this.ResolveNameSource();
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

        public virtual void ResolveNameSource() { }

        [JsonIgnore]
        public virtual TMappingValue Target {
            get {
                if (((object)this._Target == null)
                    && ((object)this._TargetName != null)) {
                    this.ResolveNameTarget();
                }
                return this._Target;
            }
            set {
                this.ThrowIfFrozen();
                if (ReferenceEquals(this._Target, value)) { return; }
                this._Target = value;
            }
        }

        public virtual void ResolveNameTarget() { }


        [JsonProperty]
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

        protected virtual bool AreThisNamesEqual(TThisKey thisName, ref TThisKey value) => false;

        public TThisKey GetName() => this._Name;
    }

    [JsonObject]
    public class MappingObjectString<TValue>
        : MappingObject<string, string, TValue>
        where TValue : class, IMappingNamedObject<string> {
        protected override bool AreSourceNamesEqual(string sourceName, ref string value)
            => MappingObjectHelper.AreNamesEqual(sourceName, ref value);

        protected override bool AreTargetNamesEqual(string targetName, ref string value)
            => MappingObjectHelper.AreNamesEqual(targetName, ref value);

        protected override bool AreThisNamesEqual(string thisName, ref string value)
            => MappingObjectHelper.AreNamesEqual(thisName, ref value);
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