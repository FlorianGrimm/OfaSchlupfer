
using System.Collections.Generic;
using OfaSchlupfer.TextTemplate.Parsing;

namespace OfaSchlupfer.TextTemplate.Runtime.Accessors {
    public class ScriptObjectAccessor : IObjectAccessor {
        public static readonly IObjectAccessor Default = new ScriptObjectAccessor();

        public int GetMemberCount(TemplateContext context, SourceSpan span, object target) {
            return ((IScriptObject) target).Count;
        }

        public IEnumerable<string> GetMembers(TemplateContext context, SourceSpan span, object target) {
            return ((IScriptObject) target).GetMembers();
        }

        public bool HasMember(TemplateContext context, SourceSpan span, object target, string member) {
            return ((IScriptObject)target).Contains(member);
        }

        public bool TryGetValue(TemplateContext context, SourceSpan span, object target, string member, out object value) {
            return ((IScriptObject)target).TryGetValue(context, span, member, out value);
        }

        public bool TrySetValue(TemplateContext context, SourceSpan span, object target, string member, object value) {
            return ((IScriptObject)target).TrySetValue(member, value, false);
        }
    }
}