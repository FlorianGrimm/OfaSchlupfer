namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;

    using Newtonsoft.Json;

    using OfaSchlupfer.Freezable;

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ModelSqlIndexColumn
        : ModelSqlNamedElement
        , IEquatable<ModelSqlIndexColumn> {
        [JsonIgnore]
        private ModelSqlIndex _Index;

        [JsonIgnore]
        private ModelSqlColumn _Column;

        [JsonIgnore]
        private bool _Ascending;

        [JsonIgnore]
        private bool _IncludedColumn;

        public ModelSqlIndexColumn() {
        }

        [JsonIgnore]
        public ModelSqlIndex Index {
            get => this._Index;
            set => this.SetOwnerWithChildren(ref this._Index, value, (owner) => owner.Columns);
        }

        [JsonIgnore]
        public override SqlName Name {
            get {
                if (this._Column is null) {
                    return this._Name;
                } else {
                    return this._Column.Name;
                }
            }
            set {
                this.ThrowIfFrozen();
                this._Name = SqlName.AtObjectLevel(value, ObjectLevel.Child);
            }
        }


        [JsonIgnore]
        public ModelSqlColumn Column {
            get {
                if (!(this._Index is null)
                    && (this._Column is null)
                    && !(this._Name is null)) {
                    this._Column = this._Index.Owner.Columns.GetValueOrDefault(this._Name);
                }
                return this._Column;
            }
            set {
                this.ThrowIfFrozen();
                this._Column = value;
                if (!(value is null)) {
                    this._Name = value.Name;
                }
            }
        }

        [JsonProperty]
        public bool Ascending { get => this._Ascending; set => this.SetValueProperty(ref this._Ascending, value); }

        [JsonProperty]
        public bool IncludedColumn { get => this._IncludedColumn; set => this.SetValueProperty(ref this._IncludedColumn, value); }

        public override bool Equals(object obj) {
            if (obj is ModelSqlIndexColumn other) {
                return this.Equals(other);
            }
            return false;
        }

        public bool Equals(ModelSqlIndexColumn other) {
            if (other is null) { return false; }
            if (other is null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            return (this.Name == other.Name)
                && (this._Ascending == other._Ascending)
                && (this._IncludedColumn == other._IncludedColumn)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}