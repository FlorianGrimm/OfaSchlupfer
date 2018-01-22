namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// SqlName comparer
    /// </summary>
    public sealed class SqlNameEqualityComparer
        : IEqualityComparer<SqlName> {
        private static SqlNameEqualityComparer _Instance1;
        private static SqlNameEqualityComparer _Instance2;
        private static SqlNameEqualityComparer _Instance3;
        private static SqlNameEqualityComparer _Instance4;
        private static SqlNameEqualityComparer _Instance5;

        /// <summary>
        /// Gets a shared SqlNameEqualityComparer of one level.
        /// </summary>
        public static SqlNameEqualityComparer Instance1 => _Instance1 ?? (_Instance1 = new SqlNameEqualityComparer(1, null));

        /// <summary>
        /// Gets a shared SqlNameEqualityComparer of one level.
        /// </summary>
        public static SqlNameEqualityComparer Instance2 => _Instance2 ?? (_Instance2 = new SqlNameEqualityComparer(1, null));

        /// <summary>
        /// Gets a shared SqlNameEqualityComparer of one level.
        /// </summary>
        public static SqlNameEqualityComparer Instance3 => _Instance3 ?? (_Instance3 = new SqlNameEqualityComparer(1, null));

        /// <summary>
        /// Gets a shared SqlNameEqualityComparer of one level.
        /// </summary>
        public static SqlNameEqualityComparer Instance4 => _Instance4 ?? (_Instance4 = new SqlNameEqualityComparer(1, null));

        /// <summary>
        /// Gets a shared SqlNameEqualityComparer of one level.
        /// </summary>
        public static SqlNameEqualityComparer Instance5 => _Instance5 ?? (_Instance5 = new SqlNameEqualityComparer(1, null));

        /// <summary>
        /// Number of levels to check
        /// </summary>
        public readonly int Level;

        /// <summary>
        /// The name comparer.
        /// </summary>
        public readonly IEqualityComparer<string> NameEqualityComparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlNameEqualityComparer"/> class.
        /// </summary>
        /// <param name="level">number of level to check.</param>
        /// <param name="nameEqualityComparer">the comparer for names.</param>
        public SqlNameEqualityComparer(int level, IEqualityComparer<string> nameEqualityComparer) {
            this.Level = level;
            this.NameEqualityComparer = nameEqualityComparer ?? StringComparer.OrdinalIgnoreCase;
        }

        /// <summary>
        /// y.Name == x.Name
        /// </summary>
        /// <param name="x">a instance to test.</param>
        /// <param name="y">another instance to test.</param>
        /// <returns>true if the names are the same - ignoring the rest.</returns>
        public bool Equals(SqlName x, SqlName y) {
            if (ReferenceEquals(x, y)) { return true; }
            if (ReferenceEquals(x, null)) { return false; }
            if (ReferenceEquals(y, null)) { return false; }
            if (this.Level >= 5) {
                if (!this.NameEqualityComparer.Equals(x.Parent.Parent.Parent.Parent.Name, y.Parent.Parent.Parent.Parent.Name)) {
                    return false;
                }
            }
            if (this.Level >= 4) {
                if (!this.NameEqualityComparer.Equals(x.Parent.Parent.Parent.Name, y.Parent.Parent.Parent.Name)) {
                    return false;
                }
            }
            if (this.Level >= 3) {
                if (!this.NameEqualityComparer.Equals(x.Parent.Parent.Name, y.Parent.Parent.Name)) {
                    return false;
                }
            }
            if (this.Level >= 2) {
                if (!this.NameEqualityComparer.Equals(x.Parent.Name, y.Parent.Name)) {
                    return false;
                }
            }
            return this.NameEqualityComparer.Equals(x.Name, y.Name);
        }

        /// <summary>
        /// Get the hashcode of the name.
        /// </summary>
        /// <param name="obj">the object to get the hascode from</param>
        /// <returns>the hashcode of the name.</returns>
        public int GetHashCode(SqlName obj) {
            unchecked {
                int result = this.NameEqualityComparer.GetHashCode(obj.Name);
                if (this.Level >= 2) {
                    result = result ^ (this.NameEqualityComparer.GetHashCode(obj.Parent.Name) << 6);
                }
                if (this.Level >= 3) {
                    result = result ^ (this.NameEqualityComparer.GetHashCode(obj.Parent.Parent.Name) << 12);
                }
                if (this.Level >= 4) {
                    result = result ^ (this.NameEqualityComparer.GetHashCode(obj.Parent.Parent.Parent.Name) << 18);
                }
                if (this.Level >= 5) {
                    result = result ^ (this.NameEqualityComparer.GetHashCode(obj.Parent.Parent.Parent.Parent.Name) << 24);
                }
                return result;
            }
        }
    }
}
