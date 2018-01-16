namespace OfaSchlupfer.AST {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class TSqlFragmentExtension {
        public static void Accept<T>(this List<T> that, TSqlFragmentVisitor visitor)
            where T : TSqlFragment {
            if (that != null) {
                for (int i = 0, count = that.Count; i < count; i++) {
                    that[i].Accept(visitor);
                }
            }
        }
    }
}
