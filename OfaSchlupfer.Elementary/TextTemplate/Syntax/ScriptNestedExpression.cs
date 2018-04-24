
using System.IO;

namespace OfaSchlupfer.TextTemplate.Syntax {
    [ScriptSyntax("nested expression", "(<expression>)")]
    public class ScriptNestedExpression : ScriptExpression, IScriptVariablePath {
        public ScriptExpression Expression { get; set; }

        public override object Evaluate(TemplateContext context) {
            // A nested expression will reset the pipe arguments for the group
            context.PushPipeArguments();
            try {
                return context.GetValue(this);
            }
            finally {
                context.PopPipeArguments();
            }
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write("(");
            context.Write(Expression);
            context.Write(")");
        }

        public override string ToString() {
            return $"({Expression})";
        }

        public object GetValue(TemplateContext context) {
            return context.Evaluate(Expression);
        }

        public void SetValue(TemplateContext context, object valueToSet) {
            context.SetValue(Expression, valueToSet);
        }

        public string GetFirstPath() {
            return (Expression as IScriptVariablePath)?.GetFirstPath();
        }
    }
}