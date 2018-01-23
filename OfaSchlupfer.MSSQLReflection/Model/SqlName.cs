﻿#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1131

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Name
    /// </summary>
    public sealed class SqlName : IEquatable<SqlName> {
        private static SqlName _Root;
        private static IEqualityComparer<NameLevel> nameLevelComparer = new NameLevelEqualityComparer();
        private static IEqualityComparer<string> stringComparer = StringComparer.OrdinalIgnoreCase;

        /// <summary>
        /// Gets the Root.
        /// </summary>
        public static SqlName Root {
            get {
                if ((object)_Root == null) {
                    var root = new SqlName("%");
                    System.Threading.Interlocked.CompareExchange(ref _Root, root, null);
                }
                return _Root;
            }
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="names">the names</param>
        /// <param name="objectLevel">target objectlevel.</param>
        /// <returns>the SqlName chain</returns>
        public static SqlName Parse(string names, ObjectLevel objectLevel) {
            if (string.IsNullOrEmpty(names)) {
                return null;
            }
            var parts = new List<string>();
            int state = 0;
            int start = 0;
            int stop = 0;
            for (int idx = 0, l = names.Length; idx <= l; idx++) {
                bool eos = (idx >= l);
                char c;
                if (eos) {
                    c = '\0';
                } else {
                    c = names[idx];
                }
                if (c == '[') {
                    state = 1;
                    stop = start = idx + 1;
                    continue;
                }
                if (c == ']') {
                    if (state == 1) {
                        stop = idx;
                        state = 2;
                    }
                    continue;
                }
                if (((c == '.') && ((state == 0) || (state == 2))) || eos) {
                    if (state == 0) {
                        // ab.c
                        // 012345
                        // 0 2
                        parts.Add(names.Substring(start, idx - start).Trim());
                    } else if (start == stop) {
                        parts.Add(names.Substring(start, idx - start));
                    } else {
                        // [ab].c
                        // 012345
                        //  1 3
                        parts.Add(names.Substring(start, stop - start));
                        state = 0;
                    }
                    stop = start = idx + 1;
                    continue;
                }
            }
            if (parts.Count == 0) {
                return null;
            } else {
                if (objectLevel == ObjectLevel.Unknown) {
                    SqlName result = null;
                    for (int idx = 0; idx < parts.Count; idx++) {
                        result = new SqlName(result, parts[idx], ObjectLevel.Unknown);
                    }
                    return result;
                } else {
                    SqlName result = null;
                    for (int idx = 0; idx < parts.Count; idx++) {
                        var ol = (int)objectLevel - idx + parts.Count - 1;
                        var validol = ((((int)ObjectLevel.Column) <= ol) && (ol <= ((int)ObjectLevel.Server)))
                                ? ((ObjectLevel)ol)
                                : ObjectLevel.Unknown;
                        result = new SqlName(result, parts[idx], validol);
                    }
                    return result;
                }
            }
        }

        private int _HashCode;
        private Dictionary<NameLevel, SqlName> _Wellknown;
        public readonly int Level;
        public readonly ObjectLevel ObjectLevel;

        /// <summary>
        /// Gets the name.
        /// </summary>
        public SqlName Parent { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlName"/> class.
        /// </summary>
        /// <param name="parent">parent Name</param>
        /// <param name="name">the name</param>
        /// <param name="objectLevel">the ObjectLevel.</param>
        public SqlName(SqlName parent, string name, ObjectLevel objectLevel) {
            if ((object)name == null) {
                throw new ArgumentNullException(nameof(name));
            }
            this.Parent = parent ?? SqlName.Root;
            this.Name = name;
            this.Level = (parent == null) ? 1 : (parent.Level + 1);
            this.ObjectLevel = objectLevel;
        }

        private SqlName(string name) {
            if ((object)name == null) {
                throw new ArgumentNullException(nameof(name));
            }
            this.Parent = this;
            this.Name = name;
            this.Level = 0;
            this.ObjectLevel = ObjectLevel.Unknown;
        }

        /// <summary>
        /// Create a child
        /// </summary>
        /// <param name="name">the name of the child</param>
        /// <returns>the new child.</returns>
        public SqlName Child(string name) {
            ObjectLevel nextLevel = ObjectLevel.Unknown;
            switch (this.ObjectLevel) {
                case ObjectLevel.Object:
                    nextLevel = ObjectLevel.Column;
                    break;
                case ObjectLevel.Schema:
                    nextLevel = ObjectLevel.Object;
                    break;
                case ObjectLevel.Database:
                    nextLevel = ObjectLevel.Schema;
                    break;
                case ObjectLevel.Server:
                    nextLevel = ObjectLevel.Database;
                    break;
                default:
                    nextLevel = ObjectLevel.Unknown;
                    break;
            }
            return new SqlName(this, name, nextLevel);
        }

        /// <summary>
        /// Create a child
        /// </summary>
        /// <param name="name">the name of the child</param>
        /// <param name="objectLevel">the new object level,</param>
        /// <returns>the new child.</returns>
        public SqlName Child(string name, ObjectLevel objectLevel) => new SqlName(this, name, objectLevel);

        /// <summary>
        /// Creates or get a child
        /// </summary>
        /// <param name="name">the name of the child</param>
        /// <returns>an old or new child.</returns>
        public SqlName ChildWellkown(string name) {
            ObjectLevel nextLevel = ObjectLevel.Unknown;
            switch (this.ObjectLevel) {
                case ObjectLevel.Object:
                    nextLevel = ObjectLevel.Column;
                    break;
                case ObjectLevel.Schema:
                    nextLevel = ObjectLevel.Object;
                    break;
                case ObjectLevel.Database:
                    nextLevel = ObjectLevel.Schema;
                    break;
                case ObjectLevel.Server:
                    nextLevel = ObjectLevel.Database;
                    break;
                default:
                    nextLevel = ObjectLevel.Unknown;
                    break;
            }
            return this.ChildWellkown(name, nextLevel);
        }

        /// <summary>
        /// Creates or get a child
        /// </summary>
        /// <param name="name">the name of the child</param>
        /// <param name="objectLevel">the level.</param>
        /// <returns>an old or new child.</returns>
        public SqlName ChildWellkown(string name, ObjectLevel objectLevel) {
            if (this.IsRoot) { return new SqlName(this, name, objectLevel); }
            if (this._Wellknown == null) { this._Wellknown = new Dictionary<NameLevel, SqlName>(nameLevelComparer); }
            SqlName result;
            var key = new NameLevel { Name = name, ObjectLevel = objectLevel };
            if (this._Wellknown.TryGetValue(key, out result)) {
                return result;
            } else {
                result = new SqlName(this, name, objectLevel);
                this._Wellknown[key] = result;
                return result;
            }
        }

        /// <summary>
        /// Ensure the objectlevel - creates a new name if needed..
        /// </summary>
        /// <param name="sqlName">the name</param>
        /// <param name="requiredObjectLevel">the objectLevel</param>
        /// <returns>a object</returns>
        public static SqlName AtObjectLevel(SqlName sqlName, ObjectLevel requiredObjectLevel) {
            if ((object)sqlName == null) { return null; }
            if (sqlName.ObjectLevel == requiredObjectLevel) {
                return sqlName;
            }
            var result = sqlName.Parent.ChildWellkown(sqlName.Name, requiredObjectLevel);
            return result;
        }

        /// <summary>
        /// Gets a value indicating whether this is the root
        /// </summary>
        public bool IsRoot => ReferenceEquals(this.Parent, null) || ReferenceEquals(this.Parent, this);

        public static bool operator ==(SqlName a, SqlName b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        public static bool operator !=(SqlName a, SqlName b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        public override bool Equals(object obj) {
            return this.Equals(obj as SqlName);
        }

        /// <inheritdoc/>
        public bool Equals(SqlName other) {
            if ((object)other == null) { return false; }
            if (ReferenceEquals(this, other)) { return true; }
            var tpn = ((object)this.Parent == null);
            var opn = ((object)other.Parent == null);
            if (tpn && opn) { return true; }
            if (tpn || opn) { return false; }
            if (!stringComparer.Equals(this.Name, other.Name)) {
                return false;
            }
            return (ReferenceEquals(this.Parent, other.Parent)) || (this.Parent.Equals(other.Parent));
        }

        /// <inheritdoc/>
        public override int GetHashCode() {
            if (this._HashCode == 0) {
                unchecked {
                    var hashCode =
                        ((ReferenceEquals(this.Parent, this) || ReferenceEquals(this.Parent, null))
                            ? 0
                            : this.Parent.GetHashCode() << 7)
                        ^ stringComparer.GetHashCode(this.Name ?? string.Empty);
                    if (hashCode == 0) { hashCode = 1; }
                    this._HashCode = hashCode;
                    return hashCode;
                }
            } else {
                return this._HashCode;
            }
        }

        /// <summary>
        /// the name.
        /// </summary>
        /// <returns>Name</returns>
        public override string ToString() => (this.Name + "-" + this.ObjectLevel.ToString());

        /// <summary>
        /// get Q NAme
        /// </summary>
        /// <param name="mode"> null @ [</param>
        /// <returns>the q name</returns>
        public string GetQName(string mode = null) {
            if (string.IsNullOrWhiteSpace(mode) || (string.Equals(mode, "_"))) {
                return this.Name;
            }
            if (string.Equals(mode, "@")) {
                return "@" + this.Name;
            }
            if (string.Equals(mode, "[")) {
                return "[" + this.Name + "]";
            }
            if (string.Equals(mode, "\"")) {
                return "\"" + this.Name + "\"";
            }
            return this.Name;
        }

        /// <summary>
        /// Get quoted full name
        /// </summary>
        /// <param name="mode"> null @ [</param>
        /// <param name="levels">maximum levels</param>
        /// <returns>the quoted full name</returns>
        public string GetQFullName(string mode = null, int levels = 0) {
            var this_Level = this.Level;
            if (this_Level == 1) {
                return this.GetQName(mode);
            } else if (this_Level == 2 && ((levels >= 2) || (levels == 0))) {
                return this.Parent.GetQName(mode) + "." + this.GetQName(mode);
            } else if (this_Level == 3 && ((levels >= 3) || (levels == 0))) {
                return this.Parent.Parent.GetQName(mode) + "." + this.Parent.GetQName(mode) + "." + this.GetQName(mode);
            } else {
                var currentLevel = (levels <= 0 || this_Level < levels) ? this_Level : levels;
                var items = new string[currentLevel];
                var current = this;
                while ((!ReferenceEquals(current, null)) && (!ReferenceEquals(current, current.Parent))) {
                    currentLevel--;
                    items[currentLevel] = current.GetQName(mode);
                    current = current.Parent;
                    if (currentLevel <= 0) { break; }
                }
                return string.Join(".", items);
            }
        }

        private struct NameLevel { public string Name; public ObjectLevel ObjectLevel; }

        private class NameLevelEqualityComparer : IEqualityComparer<NameLevel> {
            public bool Equals(NameLevel x, NameLevel y) => stringComparer.Equals(x.Name, y.Name) && (x.ObjectLevel == y.ObjectLevel);

            public int GetHashCode(NameLevel obj) => stringComparer.GetHashCode(obj.Name);
        }
    }
}
