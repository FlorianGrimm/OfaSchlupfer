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
        public SqlScope(SqlScope parent = null, IScopeNameResolver nameResolver = null) {
            this.Parent = parent;
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
        /// Add the item
        /// </summary>
        /// <param name="name">the name</param>
        /// <param name="namedElement">the item</param>
        public void Add(SqlName name, object namedElement) {
            this.ChildElements[name] = namedElement;
        }

        /// <summary>
        /// Resolve the name.
        /// </summary>
        /// <param name="name">the name to find the item thats called name</param>
        /// <param name="context">the resolver context.</param>
        /// <returns>the named object or null.</returns>
        public object ResolveObject(SqlName name, IScopeNameResolverContext context) {
            for (var that = this; (that != null); that = that.Parent) {
                {
                    var result = that.ChildElements.GetValueOrDefault(name);
                    if ((object)result != null) { return result; }
                }
                if ((object)that._NameResolver != null) {
                    var result = that._NameResolver.ResolveObject(name, context);
                    if ((object)result != null) { return result; }
                }
            }
            return null;
        }
    }
}
