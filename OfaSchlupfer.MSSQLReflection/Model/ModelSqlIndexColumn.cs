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

        public ModelSqlIndexColumn() {
        }

        [JsonIgnore]
        public ModelSqlIndex Index {
            get => this._Index;
            set => this.SetOwnerWithChildren(ref this._Index, value, (owner) => owner.Columns);
        }

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
                //&& (this.ColumnId == other.ColumnId)
                ;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => this.Name.ToString();
    }
}