
using OfaSchlupfer.TextTemplate.Runtime;

namespace OfaSchlupfer.TextTemplate.Syntax {
    [ScriptSyntax("with statement", "with <variable> ... end")]
    public class ScriptWithStatement : ScriptStatement {
        public ScriptExpression Name { get; set; }

        public ScriptBlockStatement Body { get; set; }

        public override object Evaluate(TemplateContext context) {
            var target = context.GetValue(Name);
            if (!(target is IScriptObject)) {
                var targetName = target?.GetType().Name ?? "null";
                throw new ScriptRuntimeException(Name.Span, $"Invalid target property `{Name}` used for [with] statement. Must be a ScriptObject instead of `{targetName}`");
            }

            context.PushGlobal((IScriptObject)target);
            try {
                var result = context.Evaluate(Body);
                return result;
            }
            finally {
                context.PopGlobal();
            }
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write("with").ExpectSpace();
            context.Write(Name);
            context.ExpectEos();
            context.Write(Body);
            context.ExpectEnd();
        }

        public override string ToString() {
            return $"with {Name} <...> end";
        }
    }
}