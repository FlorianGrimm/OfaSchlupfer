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

        /// <summary>
        /// The Parent of this - can be this if root.
        /// </summary>
        public readonly SqlScope Parent;

        private SqlScope() {
            this.Parent = this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlScope"/> class.
        /// </summary>
        /// <param name="parent">the parent of this</param>
        public SqlScope(SqlScope parent) {
            this.Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>
        /// Gets a value indicating whether this is the root
        /// </summary>
        public bool IsRoot => ReferenceEquals(this, this.Parent);

        public void Add(SqlName name, object namedElement) { }

        public object Get(SqlName name) => null;

        public object Resolve(SqlName name, object namedElement) => null;
    }
}
