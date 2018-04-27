
using System.Reflection;
using System.Text;

namespace OfaSchlupfer.TextTemplate.Runtime {
    /// <summary>
    /// The standard rename make a camel/pascalcase name changed by `_` and lowercase. e.g `ThisIsAnExample` becomes `this_is_an_example`.
    /// </summary>
    public sealed class StandardMemberRenamer {
        public static readonly MemberRenamerDelegate Default = Noop;

        public static string Noop(MemberInfo member) => member.Name;

        /// <summary>
        /// Renames a camel/pascalcase member to a lowercase and `_` name. e.g `ThisIsAnExample` becomes `this_is_an_example`.
        /// </summary>
        /// <param name="member">The member to rename</param>
        /// <returns>The member name renamed</returns>
        public static string Rename(MemberInfo member) {
            string name = member.Name;
            var builder = new StringBuilder();
            bool previousUpper = false;
            for (int i = 0; i < name.Length; i++) {
                var c = name[i];
                if (char.IsUpper(c)) {
                    if (i > 0 && !previousUpper) {
                        builder.Append("_");
                    }
                    builder.Append(char.ToLowerInvariant(c));
                    previousUpper = true;
                } else {
                    builder.Append(c);
                    previousUpper = false;
                }
            }
            return builder.ToString();
        }
    }
}