namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// a naming scope
    /// </summary>
    public class SqlScope {
        private static SqlScope _Root;

        /// <summary>
        /// Gets the Root.
        /// </summary>
        public static SqlScope Root {
            get {
                if ((object)_Root == null) {
                    var root = new SqlScope();
                    System.Threading.Interlocked.CompareExchange(ref _Root, root, null);
                }
                return _Root;
            }
        }

        private readonly IScopeNameResolver _NameResolver;

        /// <summary>
        /// The Parent of this - can be this if root.
        /// </summary>
        public readonly SqlScope Parent;

        /// <summary>
        /// The childElement are named elements known in this scope.
        /// </summary>
        public readonly Dictionary<SqlName, object> ChildElements;

        private SqlScope() {
            this.ChildElements = new Dictionary<SqlName, object>();
            this.Parent = this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlScope"/> class.
        /// </summary>
        /// <param name="parent">the parent of this</param>
        /// <param name="nameResolver">resolve injection names/object.</param>
        public SqlScope(SqlScope parent, IScopeNameResolver nameResolver = null) {
            this.Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            this.ChildElements = new Dictionary<SqlName, object>();
            this._NameResolver = nameResolver;
        }

        /// <summary>
        /// Create a child scope.
        /// </summary>
        /// <param name="nameResolver">resolve injection names/object.</param>
        /// <returns>a child scope.</returns>
        public SqlScope CreateChildScope(IScopeNameResolver nameResolver = null) => new SqlScope(this, nameResolver);

        /// <summary>
        /// Gets a value indicating whether this is the root
        /// </summary>
        public bool IsRoot => ReferenceEquals(this, this.Parent);

        /// <summary>
        /// Add the item
        /// </summary>
        /// <param name="name">the name</param>
        /// <param name="namedElement">the item</param>
        public void Add(SqlName name, object namedElement) {
            this.ChildElements.Add(name, namedElement);
        }

        /// <summary>
        /// Resolve here (and NOT in the parents.)
        /// </summary>
        /// <param name="name">the name to search.</param>
        /// <returns>the found object or null.</returns>
        public object Get(SqlName name) {
            var result = this.ChildElements.GetValueOrDefault(name);
            if ((object)result != null) { return result; }
            if ((object)this._NameResolver != null) {
                result = this._NameResolver.ResolveObject(name);
                if ((object)result != null) { return result; }
            }
            return null;
        }

        /// <summary>
        /// Resolve here and in the parents.
        /// </summary>
        /// <param name="name">the name to search.</param>
        /// <returns>the found object or null.</returns>
        public object Resolve(SqlName name) {
            for (var that = this; !that.IsRoot; that = that.Parent) {
                var result = that.Get(name);
                if ((object)result != null) { return result; }
            }
            return null;
        }
    }
}
