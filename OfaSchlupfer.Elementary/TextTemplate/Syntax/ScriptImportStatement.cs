
using OfaSchlupfer.TextTemplate.Runtime;

namespace OfaSchlupfer.TextTemplate.Syntax {
    [ScriptSyntax("import statement", "import <expression>")]
    public class ScriptImportStatement : ScriptStatement {
        public ScriptExpression Expression { get; set; }

        public override object Evaluate(TemplateContext context) {
            var value = context.Evaluate(Expression);
            if (value is null) {
                return null;
            }
            var scriptObject = value as ScriptObject;
            if (scriptObject == null) {
                throw new ScriptRuntimeException(Expression.Span, $"Unexpected value `{value.GetType()}` for import. Expecting an plain script object {{}}");
            }

            context.CurrentGlobal.Import(scriptObject);
            return null;
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write("import").ExpectSpace();
            context.Write(Expression);
            context.ExpectEos();
        }
    }
}