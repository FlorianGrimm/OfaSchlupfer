namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.Model;
    using OfaSchlupfer.SqlAccess;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class ModelSqlIndex
        : ModelSqlNamedElement
        , IEquatable<ModelSqlIndex> {
        [JsonIgnore]
        private IModelSqlObjectWithColumns _Owner;

        [JsonIgnore]
        private bool _IsPrimaryKey;

        [JsonIgnore]
        private readonly FreezeableOwnedKeyedCollection<ModelSqlIndex, SqlName, ModelSqlIndexColumn> _Columns;

        public ModelSqlIndex() {
            this._Columns = new FreezeableOwnedKeyedCollection<ModelSqlIndex, SqlName, ModelSqlIndexColumn>(
                this,
                (item) => item.Name,
                SqlNameEqualityComparer.Level1,
                (owner, item) => item.Index = owner
                );
        }

        [JsonIgnore]
        public IModelSqlObjectWithColumns Owner {
            get => this._Owner;
            set => this.SetOwnerWithChildren(ref this._Owner, value, (owner) => owner.Indexes);
        }


        [JsonProperty]
        public FreezeableOwnedKeyedCollection<ModelSqlIndex, SqlName, ModelSqlIndexColumn> Columns => this._Columns;

#warning index properties

        [JsonProperty]
        public bool IsPrimaryKey { get => this._IsPrimaryKey; set => this.SetValueProperty(ref this._IsPrimaryKey, value); }

        public override bool Equals(object obj) {
            if (obj is ModelSqlIndex other) {
                return this.Equals(other);
            }
            return false;
        }

        public bool Equals(ModelSqlIndex other) {
            if (other is null) { return false; }
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                //&& (this.ColumnId == other.ColumnId)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}