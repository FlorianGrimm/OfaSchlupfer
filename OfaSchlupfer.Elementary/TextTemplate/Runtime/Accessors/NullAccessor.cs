
using System.Collections.Generic;
using OfaSchlupfer.TextTemplate.Parsing;

namespace OfaSchlupfer.TextTemplate.Runtime.Accessors {
    public class NullAccessor : IObjectAccessor {
        public static readonly NullAccessor Default = new NullAccessor();

        public int GetMemberCount(TemplateContext context, SourceSpan span, object target) {
            return 0;
        }

        public IEnumerable<string> GetMembers(TemplateContext context, SourceSpan span, object target) {
            yield break;
        }

        public bool HasMember(TemplateContext context, SourceSpan span, object target, string member) {
            return false;
        }

        public bool TryGetValue(TemplateContext context, SourceSpan span, object target, string member, out object value) {
            value = null;
            return false;
        }
       
        public bool TrySetValue(TemplateContext context, SourceSpan span, object target, string member, object value) {
            return false;
        }
    }
}