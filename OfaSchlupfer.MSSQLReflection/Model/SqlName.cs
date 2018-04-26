#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1131

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using OfaSchlupfer.Freezable;
    using OfaSchlupfer.MSSQLReflection.AST;

    /// <summary>
    /// Name
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{Name}-{ObjectLevel}")]
    [JsonObject(
        IsReference = true,
        ItemConverterType = typeof(SqlNameJsonConverter),
        MemberSerialization = MemberSerialization.OptIn)]
    public sealed class SqlName
        : FreezeableObject
        , IEquatable<SqlName> {
        private static IEqualityComparer<NameLevel> nameLevelComparer = new NameLevelEqualityComparer();
        private static IEqualityComparer<string> stringComparer = StringComparer.OrdinalIgnoreCase;

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
                        var validol = ((((int)ObjectLevel.Child) <= ol) && (ol <= ((int)ObjectLevel.Server)))
                                ? ((ObjectLevel)ol)
                                : ObjectLevel.Unknown;
                        result = new SqlName(result, parts[idx], validol);
                    }
                    return result;
                }
            }
        }

        /// <summary>
        /// Creates a schema - name.
        /// </summary>
        /// <param name="name">the name of the schema</param>
        /// <returns>A new name.</returns>
        [System.Diagnostics.DebuggerStepThrough]
        public static SqlName Schema(string name) => new SqlName(null, name, ObjectLevel.Schema);

        /// <summary>
        /// Creates a object - name.
        /// </summary>
        /// <param name="schema">the name of the schema</param>
        /// <param name="name">the name of the object</param>
        /// <returns>A new name.</returns>
        [System.Diagnostics.DebuggerStepThrough]
        public static SqlName Object(string schema, string name)
            => new SqlName(
                ((string.IsNullOrEmpty(schema))
                    ? null
                    : new SqlName(null, schema, ObjectLevel.Schema)),
                name,
                ObjectLevel.Object);

        /// <summary>
        /// Creates a object name.
        /// </summary>
        /// <param name="schema">the schema</param>
        /// <param name="name">the name</param>
        /// <returns>a new name</returns>
        public static SqlName Object(SqlName schema, string name) => new SqlName(schema, name, ObjectLevel.Object);

        /// <summary>
        /// Create a SqlName from a schemaObjectname.
        /// </summary>
        /// <param name="name">the name to convert</param>
        /// <returns>a SqlName or null</returns>
        public static SqlName From(SchemaObjectName name) {
            if (name is null) { return null; }
            SqlName result = null;
            if (name.ServerIdentifier != null) { result = new SqlName(result, name.ServerIdentifier.Value, ObjectLevel.Server); }
            if ((name.DatabaseIdentifier != null) || (result != null)) { result = new SqlName(result, (name.DatabaseIdentifier?.Value) ?? string.Empty, ObjectLevel.Database); }
            if ((name.SchemaIdentifier != null) || (result != null)) { result = new SqlName(result, (name.SchemaIdentifier?.Value) ?? string.Empty, ObjectLevel.Schema); }
            if ((name.BaseIdentifier != null) || (result != null)) { result = new SqlName(result, (name.BaseIdentifier?.Value) ?? string.Empty, ObjectLevel.Object); }
            return result;
        }

        /// <summary>
        /// Create a SqlName from a ChildObjectName.
        /// </summary>
        /// <param name="name">the name to convert</param>
        /// <returns>a SqlName or null</returns>
        public static SqlName From(ChildObjectName name) {
            if (name is null) { return null; }
            SqlName result = null;
            if (name.ServerIdentifier != null) { result = new SqlName(result, name.ServerIdentifier.Value, ObjectLevel.Server); }
            if ((name.DatabaseIdentifier != null) || (result != null)) { result = new SqlName(result, (name.DatabaseIdentifier?.Value) ?? string.Empty, ObjectLevel.Database); }
            if ((name.SchemaIdentifier != null) || (result != null)) { result = new SqlName(result, (name.SchemaIdentifier?.Value) ?? string.Empty, ObjectLevel.Schema); }
            if ((name.BaseIdentifier != null) || (result != null)) { result = new SqlName(result, (name.BaseIdentifier?.Value) ?? string.Empty, ObjectLevel.Object); }
            if ((name.ChildIdentifier != null) || (result != null)) { result = new SqlName(result, (name.ChildIdentifier?.Value) ?? string.Empty, ObjectLevel.Child); }
            return result;
        }

        private int _HashCode;
        private Dictionary<NameLevel, SqlName> _Wellknown;

        private SqlName _Parent;
        private string _Name;
        private int _LevelCount;
        private ObjectLevel _ObjectLevel;

        /// <summary>
        /// Gets the name.
        /// </summary>
        [JsonProperty]
        public SqlName Parent {
            get => this._Parent;
            set {
                if (this.SetRefPropertyOnce(ref this._Parent, value)) {
                    if (value is null) {
                        this._LevelCount = 1;
                    } else {
                        this._LevelCount = value._LevelCount + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [JsonProperty]
        public string Name {
            get => this._Name;
            set => this.SetStringProperty(ref this._Name, value);
        }

        [JsonProperty]
        public int LevelCount {
            get => this._LevelCount;
            set => this.SetValueProperty(ref this._LevelCount, value);
        }

        [JsonProperty]
        public ObjectLevel ObjectLevel {
            get => this._ObjectLevel;
            set => this.SetValueProperty(ref this._ObjectLevel, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlName"/> class.
        /// </summary>
        /// <param name="parent">parent Name</param>
        /// <param name="name">the name</param>
        /// <param name="objectLevel">the ObjectLevel.</param>
        [System.Diagnostics.DebuggerStepThrough]
        public SqlName(SqlName parent, string name, ObjectLevel objectLevel) {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Parent = parent;
            this.LevelCount = (parent == null) ? 1 : (parent.LevelCount + 1);
            this.ObjectLevel = objectLevel;
        }

        /// <summary>
        /// Create a child
        /// </summary>
        /// <param name="name">the name of the child</param>
        /// <returns>the new child.</returns>
        [System.Diagnostics.DebuggerStepThrough]
        public SqlName Child(string name) {
            ObjectLevel nextLevel = ObjectLevel.Unknown;
            switch (this.ObjectLevel) {
                case ObjectLevel.Object:
                    nextLevel = ObjectLevel.Child;
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
        [System.Diagnostics.DebuggerStepThrough]
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
                    nextLevel = ObjectLevel.Child;
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
        /// Get the this, the parent or any ancestor thats ObjectLevel is equal or greater than the <paramref name="objectLevel"/>.
        /// </summary>
        /// <param name="objectLevel">the minimum objectlevel.</param>
        /// <returns>the found instance or null.</returns>
        public SqlName GetAncestorAtLevel(ObjectLevel objectLevel) {
            var that = this;
            while (((object)that != null)
                && (that.ObjectLevel < objectLevel)) {
                that = that.Parent;
            }
            return that;
        }

        /// <summary>
        /// Gets a value indicating whether this is the root
        /// </summary>
        public bool IsRoot => ReferenceEquals(this.Parent, null) || ReferenceEquals(this.Parent, this);

        /// <summary>
        /// test if equal
        /// </summary>
        /// <param name="a">one instance</param>
        /// <param name="b">another instance</param>
        /// <returns>true if equal</returns>
        public static bool operator ==(SqlName a, SqlName b) => ((object)a == null) ? ((object)b == null) : a.Equals(b);

        /// <summary>
        /// test if equal
        /// </summary>
        /// <param name="a">one instance</param>
        /// <param name="b">another instance</param>
        /// <returns>true if false</returns>
        public static bool operator !=(SqlName a, SqlName b) => !(((object)a == null) ? ((object)b == null) : a.Equals(b));

        /// <summary>
        /// test if equal
        /// </summary>
        /// <param name="obj">another instance</param>
        /// <returns>true if equal</returns>
        public override bool Equals(object obj) {
            if (obj is SqlName other) {
                return this.Equals(other);
            }
            return false;
        }

        /// <inheritdoc/>
        public bool Equals(SqlName other) {
            if (other is null) { return false; }
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
            var this_Level = this.LevelCount;
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
