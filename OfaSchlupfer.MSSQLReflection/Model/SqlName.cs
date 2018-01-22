﻿#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Name
    /// </summary>
    public sealed class SqlName : IEquatable<SqlName> {
        private static SqlName _Root;
        private static IEqualityComparer<string> comparer = StringComparer.OrdinalIgnoreCase;

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
        /// <returns>the SqlName chain</returns>
        public static SqlName Parse(string names) {
            if (string.IsNullOrEmpty(names)) {
                return null;
            }
            SqlName result = SqlName.Root;
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
                        result = result.Child(names.Substring(start, idx - start).Trim());
                    } else if (start == stop) {
                        result = result.Child(names.Substring(start, idx - start));
                    } else {
                        // [ab].c
                        // 012345
                        //  1 3
                        result = result.Child(names.Substring(start, stop - start));
                        state = 0;
                    }
                    stop = start = idx + 1;
                    continue;
                }
            }
            return result;
        }

        private int _HashCode;
        private Dictionary<string, SqlName> _Wellknown;
        public readonly int Level;

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
        public SqlName(SqlName parent, string name) {
            if ((object)parent == null) {
                throw new ArgumentNullException(nameof(parent));
            }
            if ((object)name == null) {
                throw new ArgumentNullException(nameof(name));
            }
            this.Parent = parent;
            this.Name = name;
            this.Level = parent.Level + 1;
        }

        private SqlName(string name) {
            if ((object)name == null) {
                throw new ArgumentNullException(nameof(name));
            }
            this.Parent = this;
            this.Name = name;
            this.Level = 0;
        }

        /// <summary>
        /// Create a child
        /// </summary>
        /// <param name="name">the name of the child</param>
        /// <returns>the new child.</returns>
        public SqlName Child(string name) => new SqlName(this, name);

        /// <summary>
        /// Creates or get a child
        /// </summary>
        /// <param name="name">the name of the child</param>
        /// <returns>an old or new child.</returns>
        public SqlName ChildWellkown(string name) {
            if (this._Wellknown == null) { this._Wellknown = new Dictionary<string, SqlName>(comparer); }
            SqlName result;
            if (this._Wellknown.TryGetValue(name, out result)) {
                return result;
            } else {
                result = new SqlName(this, name);
                this._Wellknown[name] = result;
                return result;
            }
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
            if (!comparer.Equals(this.Name, other.Name)) {
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
                        ^ comparer.GetHashCode(this.Name ?? string.Empty);
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
        public override string ToString() {
            return this.Name;
        }

        /// <summary>
        /// get Q NAme
        /// </summary>
        /// <param name="mode"> null @ [</param>
        /// <returns>the q name</returns>
        public string GetQName(string mode = null) {
            if (string.IsNullOrEmpty(mode) || (string.Equals(mode, "_"))) {
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
    }
}
