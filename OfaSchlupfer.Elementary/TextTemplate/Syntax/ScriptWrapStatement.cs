
using OfaSchlupfer.TextTemplate.Runtime;

namespace OfaSchlupfer.TextTemplate.Syntax {
    [ScriptSyntax("wrap statement", "wrap <function_call> ... end")]
    public class ScriptWrapStatement : ScriptStatement {
        public ScriptExpression Target { get; set; }

        public ScriptBlockStatement Body { get; set; }

        public override object Evaluate(TemplateContext context) {
            // Check that the Target is actually a function
            var functionCall = Target as ScriptFunctionCall;
            if (functionCall == null) {
                var parameterLessFunction = context.Evaluate(Target, true);
                if (!(parameterLessFunction is IScriptCustomFunction)) {
                    var targetPrettyname = ScriptSyntaxAttribute.Get(Target);
                    throw new ScriptRuntimeException(Target.Span, $"Expecting a direct function instead of the expression `{Target}/{targetPrettyname.Name}`");
                }

                context.BlockDelegates.Push(Body);
                return ScriptFunctionCall.Call(context, this, parameterLessFunction, false);
            }
            else {
                context.BlockDelegates.Push(Body);
                return context.Evaluate(functionCall);
            }
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write("wrap").ExpectSpace();
            context.Write(Target);
            context.ExpectEos();
            context.Write(Body);
            context.ExpectEnd();
        }
    }
}