namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// x
    /// </summary>
    public class SqlCodeScopeReference {
        /// <summary>
        /// Stack
        /// </summary>
        public readonly Stack<SqlCodeScope> Scopes;

        /// <summary>
        /// The current scope.
        /// </summary>
        public SqlCodeScope Current;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCodeScopeReference"/> class.
        /// </summary>
        public SqlCodeScopeReference() {
            this.Scopes = new Stack<SqlCodeScope>();
        }

        /// <summary>
        /// set the stack to have one element <paramref name="dbScope"/>.
        /// </summary>
        /// <param name="dbScope">the scope to set.</param>
        public void Set(SqlCodeScope dbScope) {
            this.Scopes.Clear();
            this.Scopes.Push(dbScope);
            this.Current = dbScope;
        }

        /// <summary>
        /// stack push
        /// </summary>
        /// <param name="next">the next scope</param>
        public void Push(SqlCodeScope next) {
            this.Scopes.Push(next);
            this.Current = next;
        }

        /// <summary>
        /// stack pop
        /// </summary>
        /// <returns>the poped item</returns>
        public SqlCodeScope Pop() {
            var result = this.Scopes.Pop();
            this.Current = this.Scopes.Peek();
            return result;
        }
    }
}
