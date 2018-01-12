namespace OfaSchlupfer.Elementary {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class EquatableUtility {
        public static bool SafeEquals<T>(this IEquatable<T> a, IEquatable<T> b) {
            var an = ((object)a == null);
            var bn = ((object)b == null);
            if (an && bn) { return true; }
            if (an || bn) { return false; }
            return an.Equals(bn);
        }
    }
}
