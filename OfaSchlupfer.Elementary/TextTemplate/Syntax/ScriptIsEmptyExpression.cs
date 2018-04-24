
using OfaSchlupfer.TextTemplate.Runtime;

namespace OfaSchlupfer.TextTemplate.Syntax {
    [ScriptSyntax("empty expression", "<expression>.empty?")]
    public class ScriptIsEmptyExpression: ScriptExpression, IScriptVariablePath {
        public ScriptExpression Target { get; set; }

        public override object Evaluate(TemplateContext context) {
            return context.GetValue(this);
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write(Target);
            context.Write(".empty?");
        }

        public override bool CanHaveLeadingTrivia() {
            return false;
        }

        public object GetValue(TemplateContext context) {
            var targetObject = GetTargetObject(context, false);
            return context.IsEmpty(Span, targetObject);
        }

        public void SetValue(TemplateContext context, object valueToSet) {
            throw new ScriptRuntimeException(Span, $"The `.empty?` property cannot be set");
        }

        public string GetFirstPath() {
            return (Target as IScriptVariablePath)?.GetFirstPath();
        }

        private object GetTargetObject(TemplateContext context, bool isSet) {
            var targetObject = context.GetValue(Target);

            if (targetObject == null) {
                if (isSet || !context.EnableRelaxedMemberAccess) {
                    throw new ScriptRuntimeException(this.Span, $"Object `{this.Target}` is null. Cannot access property `empty?`");
                }
            }
            return targetObject;
        }

        public override string ToString() {
            return $"{Target}.empty?";
        }
    }
}