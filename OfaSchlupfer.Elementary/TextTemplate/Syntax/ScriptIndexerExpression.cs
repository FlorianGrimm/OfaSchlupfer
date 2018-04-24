
using System.Collections;
using System.IO;
using OfaSchlupfer.TextTemplate.Runtime;
using OfaSchlupfer.TextTemplate.Helpers;

namespace OfaSchlupfer.TextTemplate.Syntax {
    [ScriptSyntax("indexer expression", "<expression>[<index_expression>]")]
    public class ScriptIndexerExpression : ScriptExpression, IScriptVariablePath {
        public ScriptExpression Target { get; set; }

        public ScriptExpression Index { get; set; }

        public override object Evaluate(TemplateContext context) {
            return context.GetValue(this);
        }

        public override bool CanHaveLeadingTrivia() {
            return false;
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write(Target);
            var isSpecialArgumentsArray = Equals(Target, ScriptVariable.Arguments) && Index is ScriptLiteral &&
                                          ((ScriptLiteral) Index).IsPositiveInteger();
            if (!isSpecialArgumentsArray) {
                context.Write("[");
            }
            context.Write(Index);
            if (!isSpecialArgumentsArray) {
                context.Write("]");
            }
        }

        public override string ToString() {
            return $"{Target}[{Index}]";
        }

        public object GetValue(TemplateContext context) {
            return GetOrSetValue(context, null, false);
        }

        public void SetValue(TemplateContext context, object valueToSet) {
            GetOrSetValue(context, valueToSet, true);
        }

        public string GetFirstPath() {
            return (Target as IScriptVariablePath)?.GetFirstPath();
        }

        private object GetOrSetValue(TemplateContext context, object valueToSet, bool setter) {
            object value = null;

            var targetObject = context.GetValue(Target);
            if (targetObject == null) {
                throw new ScriptRuntimeException(Target.Span, $"Object `{Target}` is null. Cannot access indexer: {this}"); // unit test: 130-indexer-accessor-error1.txt
            }

            var index = context.Evaluate(Index);
            if (index == null) {
                throw new ScriptRuntimeException(Index.Span,
                    $"Cannot access target `{Target}` with a null indexer: {this}"); // unit test: 130-indexer-accessor-error2.txt
            }

            if (targetObject is IDictionary || targetObject is ScriptObject) {
                var accessor = context.GetMemberAccessor(targetObject);
                var indexAsString = context.ToString(Index.Span, index);

                if (setter) {
                    if (!accessor.TrySetValue(context, Span, targetObject, indexAsString, valueToSet)) {
                        throw new ScriptRuntimeException(Index.Span, $"Cannot set a value for the readonly member `{indexAsString}` in the indexer: {Target}['{indexAsString}']"); // unit test: 130-indexer-accessor-error3.txt
                    }
                }
                else {
                    if (!accessor.TryGetValue(context, Span, targetObject, indexAsString, out value)) {
                        context.TryGetMember?.Invoke(context, Span, targetObject, indexAsString, out value);
                    }
                }
            }
            else {
                var accessor = context.GetListAccessor(targetObject);
                if (accessor == null) {
                    throw new ScriptRuntimeException(Target.Span, $"Expecting a list. Invalid value `{targetObject}/{targetObject.GetType().Name}` for the target `{Target}` for the indexer: {this}"); // unit test: 130-indexer-accessor-error4.txt
                }

                int i = context.ToInt(Index.Span, index);

                // Allow negative index from the end of the array
                if (i < 0) {
                    i = accessor.GetLength(context, Span, targetObject) + i;
                }

                if (i >= 0) {
                    if (setter) {
                        accessor.SetValue(context, Span, targetObject, i, valueToSet);
                    }
                    else {
                        value = accessor.GetValue(context, Span, targetObject, i);
                    }
                }
            }
            return value;
        }
    }
}