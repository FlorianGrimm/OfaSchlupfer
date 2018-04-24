// ----------------------------------------------------------------------------------
// This file was automatically generated - 22-Jan-18 07:31:49 by OfaSchlupfer.TextTemplate.CodeGen
// DOT NOT EDIT THIS FILE MANUALLY
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Reflection;
using OfaSchlupfer.TextTemplate.Helpers;
using OfaSchlupfer.TextTemplate.Parsing;
using OfaSchlupfer.TextTemplate.Syntax;

namespace OfaSchlupfer.TextTemplate.Runtime {
    public abstract partial class DynamicCustomFunction {


        static DynamicCustomFunction() {
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.MathFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.MathFunctions.IsNumber)), method => new Functionbool_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Contains)), method => new Functionbool_string_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.DateTimeFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.DateTimeFunctions.AddDays)), method => new FunctionDateTime_DateTime_double(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.DateTimeFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.DateTimeFunctions.AddMonths)), method => new FunctionDateTime_DateTime_int(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.MathFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.MathFunctions.Ceil)), method => new Functiondouble_double(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.MathFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.MathFunctions.Round)), method => new Functiondouble_double_int___Opt(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Reverse)), method => new FunctionIEnumerable_IEnumerable(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.AddRange)), method => new FunctionIEnumerable_IEnumerable_IEnumerable(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Split)), method => new FunctionIEnumerable_string_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Sort)), method => new FunctionIEnumerable_TemplateContext_SourceSpan_object_string___Opt(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Map)), method => new FunctionIEnumerable_TemplateContext_SourceSpan_object_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.RemoveAt)), method => new FunctionIList_IList_int(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.InsertAt)), method => new FunctionIList_IList_int_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Add)), method => new FunctionIList_IList_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Size)), method => new Functionint_IEnumerable(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Size)), method => new Functionint_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ObjectFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ObjectFunctions.Size)), method => new Functionint_TemplateContext_SourceSpan_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.First)), method => new Functionobject_IEnumerable(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ObjectFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ObjectFunctions.Default)), method => new Functionobject_object_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.MathFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.MathFunctions.DividedBy)), method => new Functionobject_TemplateContext_SourceSpan_double_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Cycle)), method => new Functionobject_TemplateContext_SourceSpan_IList_object___Opt(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.MathFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.MathFunctions.Abs)), method => new Functionobject_TemplateContext_SourceSpan_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.MathFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.MathFunctions.Minus)), method => new Functionobject_TemplateContext_SourceSpan_object_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Compact)), method => new FunctionScriptArray_IEnumerable(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Limit)), method => new FunctionScriptArray_IEnumerable_int(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.RegexFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.RegexFunctions.Match)), method => new FunctionScriptArray_TemplateContext_string_string_string___Opt(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Pluralize)), method => new Functionstring_int_string_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ObjectFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ObjectFunctions.Typeof)), method => new Functionstring_object(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.HtmlFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.HtmlFunctions.Escape)), method => new Functionstring_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Slice)), method => new Functionstring_string_int_int___Opt(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Truncate)), method => new Functionstring_string_int_string___Opt(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Append)), method => new Functionstring_string_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.StringFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.StringFunctions.Replace)), method => new Functionstring_string_string_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.ArrayFunctions.Join)), method => new Functionstring_TemplateContext_SourceSpan_IEnumerable_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.MathFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.MathFunctions.Format)), method => new Functionstring_TemplateContext_SourceSpan_object_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.HtmlFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.HtmlFunctions.Strip)), method => new Functionstring_TemplateContext_string(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.RegexFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.RegexFunctions.Replace)), method => new Functionstring_TemplateContext_string_string_string_string___Opt(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.TimeSpanFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.TimeSpanFunctions.FromDays)), method => new FunctionTimeSpan_double(method));
            BuiltinFunctions.Add(typeof(OfaSchlupfer.TextTemplate.Functions.TimeSpanFunctions).GetTypeInfo().GetDeclaredMethod(nameof(OfaSchlupfer.TextTemplate.Functions.TimeSpanFunctions.Parse)), method => new FunctionTimeSpan_string(method));

        }

        /// <summary>
        /// Optimized custom function for: bool (object)
        /// </summary>
        private class Functionbool_object : DynamicCustomFunction {
            private delegate bool InternalDelegate(object arg0);

            private readonly InternalDelegate _delegate;

            public Functionbool_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: bool (string, string)
        /// </summary>
        private class Functionbool_string_string : DynamicCustomFunction {
            private delegate bool InternalDelegate(string arg0, string arg1);

            private readonly InternalDelegate _delegate;

            public Functionbool_string_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: DateTime (DateTime, double)
        /// </summary>
        private class FunctionDateTime_DateTime_double : DynamicCustomFunction {
            private delegate DateTime InternalDelegate(DateTime arg0, double arg1);

            private readonly InternalDelegate _delegate;

            public FunctionDateTime_DateTime_double(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(DateTime);
                var arg1 = default(double);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (DateTime)context.ToObject(callerContext.Span, arg, typeof(DateTime));
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = (double)context.ToObject(callerContext.Span, arg, typeof(double));
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: DateTime (DateTime, int)
        /// </summary>
        private class FunctionDateTime_DateTime_int : DynamicCustomFunction {
            private delegate DateTime InternalDelegate(DateTime arg0, int arg1);

            private readonly InternalDelegate _delegate;

            public FunctionDateTime_DateTime_int(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(DateTime);
                var arg1 = default(int);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (DateTime)context.ToObject(callerContext.Span, arg, typeof(DateTime));
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToInt(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: double (double)
        /// </summary>
        private class Functiondouble_double : DynamicCustomFunction {
            private delegate double InternalDelegate(double arg0);

            private readonly InternalDelegate _delegate;

            public Functiondouble_double(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(double);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (double)context.ToObject(callerContext.Span, arg, typeof(double));
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: double (double, int = ...)
        /// </summary>
        private class Functiondouble_double_int___Opt : DynamicCustomFunction {
            private delegate double InternalDelegate(double arg0, int arg1);

            private readonly InternalDelegate _delegate;
            private readonly int defaultArg1;

            public Functiondouble_double_int___Opt(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
                defaultArg1 = (int)Parameters[1].DefaultValue;
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count < 1 || arguments.Count > 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `1` arguments");
                }
                var arg0 = default(double);
                var arg1 = defaultArg1;
                int argMask = 2;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (double)context.ToObject(callerContext.Span, arg, typeof(double));
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToInt(callerContext.Span, arg);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `1` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: IEnumerable (IEnumerable)
        /// </summary>
        private class FunctionIEnumerable_IEnumerable : DynamicCustomFunction {
            private delegate IEnumerable InternalDelegate(IEnumerable arg0);

            private readonly InternalDelegate _delegate;

            public FunctionIEnumerable_IEnumerable(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(IEnumerable);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: IEnumerable (IEnumerable, IEnumerable)
        /// </summary>
        private class FunctionIEnumerable_IEnumerable_IEnumerable : DynamicCustomFunction {
            private delegate IEnumerable InternalDelegate(IEnumerable arg0, IEnumerable arg1);

            private readonly InternalDelegate _delegate;

            public FunctionIEnumerable_IEnumerable_IEnumerable(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(IEnumerable);
                var arg1 = default(IEnumerable);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: IEnumerable (string, string)
        /// </summary>
        private class FunctionIEnumerable_string_string : DynamicCustomFunction {
            private delegate IEnumerable InternalDelegate(string arg0, string arg1);

            private readonly InternalDelegate _delegate;

            public FunctionIEnumerable_string_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: IEnumerable (TemplateContext, SourceSpan, object, string = ...)
        /// </summary>
        private class FunctionIEnumerable_TemplateContext_SourceSpan_object_string___Opt : DynamicCustomFunction {
            private delegate IEnumerable InternalDelegate(TemplateContext arg0, SourceSpan arg1, object arg2, string arg3);

            private readonly InternalDelegate _delegate;
            private readonly string defaultArg1;

            public FunctionIEnumerable_TemplateContext_SourceSpan_object_string___Opt(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
                defaultArg1 = (string)Parameters[3].DefaultValue;
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count < 1 || arguments.Count > 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `1` arguments");
                }
                var arg0 = default(object);
                var arg1 = defaultArg1;
                int argMask = 2;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `1` arguments");
                }

                return _delegate(context, callerContext.Span, arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: IEnumerable (TemplateContext, SourceSpan, object, string)
        /// </summary>
        private class FunctionIEnumerable_TemplateContext_SourceSpan_object_string : DynamicCustomFunction {
            private delegate IEnumerable InternalDelegate(TemplateContext arg0, SourceSpan arg1, object arg2, string arg3);

            private readonly InternalDelegate _delegate;

            public FunctionIEnumerable_TemplateContext_SourceSpan_object_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(object);
                var arg1 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(context, callerContext.Span, arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: IList (IList, int)
        /// </summary>
        private class FunctionIList_IList_int : DynamicCustomFunction {
            private delegate IList InternalDelegate(IList arg0, int arg1);

            private readonly InternalDelegate _delegate;

            public FunctionIList_IList_int(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(IList);
                var arg1 = default(int);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToList(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToInt(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: IList (IList, int, object)
        /// </summary>
        private class FunctionIList_IList_int_object : DynamicCustomFunction {
            private delegate IList InternalDelegate(IList arg0, int arg1, object arg2);

            private readonly InternalDelegate _delegate;

            public FunctionIList_IList_int_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 3) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `3` arguments");
                }
                var arg0 = default(IList);
                var arg1 = default(int);
                var arg2 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToList(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToInt(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;
                        case 2:
                            arg2 = arg;
                            argMask |= (1 << 2);
                            break;

                    }
                }

                if (argMask != (1 << 3) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `3` arguments");
                }

                return _delegate(arg0, arg1, arg2);
            }
        }

        /// <summary>
        /// Optimized custom function for: IList (IList, object)
        /// </summary>
        private class FunctionIList_IList_object : DynamicCustomFunction {
            private delegate IList InternalDelegate(IList arg0, object arg1);

            private readonly InternalDelegate _delegate;

            public FunctionIList_IList_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(IList);
                var arg1 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToList(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = arg;
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: int (IEnumerable)
        /// </summary>
        private class Functionint_IEnumerable : DynamicCustomFunction {
            private delegate int InternalDelegate(IEnumerable arg0);

            private readonly InternalDelegate _delegate;

            public Functionint_IEnumerable(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(IEnumerable);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: int (string)
        /// </summary>
        private class Functionint_string : DynamicCustomFunction {
            private delegate int InternalDelegate(string arg0);

            private readonly InternalDelegate _delegate;

            public Functionint_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: int (TemplateContext, SourceSpan, object)
        /// </summary>
        private class Functionint_TemplateContext_SourceSpan_object : DynamicCustomFunction {
            private delegate int InternalDelegate(TemplateContext arg0, SourceSpan arg1, object arg2);

            private readonly InternalDelegate _delegate;

            public Functionint_TemplateContext_SourceSpan_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(context, callerContext.Span, arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: object (IEnumerable)
        /// </summary>
        private class Functionobject_IEnumerable : DynamicCustomFunction {
            private delegate object InternalDelegate(IEnumerable arg0);

            private readonly InternalDelegate _delegate;

            public Functionobject_IEnumerable(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(IEnumerable);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: object (object, object)
        /// </summary>
        private class Functionobject_object_object : DynamicCustomFunction {
            private delegate object InternalDelegate(object arg0, object arg1);

            private readonly InternalDelegate _delegate;

            public Functionobject_object_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(object);
                var arg1 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = arg;
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: object (TemplateContext, SourceSpan, double, object)
        /// </summary>
        private class Functionobject_TemplateContext_SourceSpan_double_object : DynamicCustomFunction {
            private delegate object InternalDelegate(TemplateContext arg0, SourceSpan arg1, double arg2, object arg3);

            private readonly InternalDelegate _delegate;

            public Functionobject_TemplateContext_SourceSpan_double_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(double);
                var arg1 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (double)context.ToObject(callerContext.Span, arg, typeof(double));
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = arg;
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(context, callerContext.Span, arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: object (TemplateContext, SourceSpan, IList, object = ...)
        /// </summary>
        private class Functionobject_TemplateContext_SourceSpan_IList_object___Opt : DynamicCustomFunction {
            private delegate object InternalDelegate(TemplateContext arg0, SourceSpan arg1, IList arg2, object arg3);

            private readonly InternalDelegate _delegate;
            private readonly object defaultArg1;

            public Functionobject_TemplateContext_SourceSpan_IList_object___Opt(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
                defaultArg1 = (object)Parameters[3].DefaultValue;
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count < 1 || arguments.Count > 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `1` arguments");
                }
                var arg0 = default(IList);
                var arg1 = defaultArg1;
                int argMask = 2;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToList(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = arg;
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `1` arguments");
                }

                return _delegate(context, callerContext.Span, arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: object (TemplateContext, SourceSpan, object)
        /// </summary>
        private class Functionobject_TemplateContext_SourceSpan_object : DynamicCustomFunction {
            private delegate object InternalDelegate(TemplateContext arg0, SourceSpan arg1, object arg2);

            private readonly InternalDelegate _delegate;

            public Functionobject_TemplateContext_SourceSpan_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(context, callerContext.Span, arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: object (TemplateContext, SourceSpan, object, object)
        /// </summary>
        private class Functionobject_TemplateContext_SourceSpan_object_object : DynamicCustomFunction {
            private delegate object InternalDelegate(TemplateContext arg0, SourceSpan arg1, object arg2, object arg3);

            private readonly InternalDelegate _delegate;

            public Functionobject_TemplateContext_SourceSpan_object_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(object);
                var arg1 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = arg;
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(context, callerContext.Span, arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: ScriptArray (IEnumerable)
        /// </summary>
        private class FunctionScriptArray_IEnumerable : DynamicCustomFunction {
            private delegate ScriptArray InternalDelegate(IEnumerable arg0);

            private readonly InternalDelegate _delegate;

            public FunctionScriptArray_IEnumerable(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(IEnumerable);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: ScriptArray (IEnumerable, int)
        /// </summary>
        private class FunctionScriptArray_IEnumerable_int : DynamicCustomFunction {
            private delegate ScriptArray InternalDelegate(IEnumerable arg0, int arg1);

            private readonly InternalDelegate _delegate;

            public FunctionScriptArray_IEnumerable_int(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(IEnumerable);
                var arg1 = default(int);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToInt(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: ScriptArray (TemplateContext, string, string, string = ...)
        /// </summary>
        private class FunctionScriptArray_TemplateContext_string_string_string___Opt : DynamicCustomFunction {
            private delegate ScriptArray InternalDelegate(TemplateContext arg0, string arg1, string arg2, string arg3);

            private readonly InternalDelegate _delegate;
            private readonly string defaultArg2;

            public FunctionScriptArray_TemplateContext_string_string_string___Opt(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
                defaultArg2 = (string)Parameters[3].DefaultValue;
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count < 2 || arguments.Count > 3) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `2` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(string);
                var arg2 = defaultArg2;
                int argMask = 4;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 1;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;
                        case 2:
                            arg2 = context.ToString(callerContext.Span, arg);
                            break;

                    }
                }

                if (argMask != (1 << 3) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `2` arguments");
                }

                return _delegate(context, arg0, arg1, arg2);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (int, string, string)
        /// </summary>
        private class Functionstring_int_string_string : DynamicCustomFunction {
            private delegate string InternalDelegate(int arg0, string arg1, string arg2);

            private readonly InternalDelegate _delegate;

            public Functionstring_int_string_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 3) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `3` arguments");
                }
                var arg0 = default(int);
                var arg1 = default(string);
                var arg2 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToInt(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;
                        case 2:
                            arg2 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 2);
                            break;

                    }
                }

                if (argMask != (1 << 3) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `3` arguments");
                }

                return _delegate(arg0, arg1, arg2);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (object)
        /// </summary>
        private class Functionstring_object : DynamicCustomFunction {
            private delegate string InternalDelegate(object arg0);

            private readonly InternalDelegate _delegate;

            public Functionstring_object(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(object);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (string)
        /// </summary>
        private class Functionstring_string : DynamicCustomFunction {
            private delegate string InternalDelegate(string arg0);

            private readonly InternalDelegate _delegate;

            public Functionstring_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (string, int, int = ...)
        /// </summary>
        private class Functionstring_string_int_int___Opt : DynamicCustomFunction {
            private delegate string InternalDelegate(string arg0, int arg1, int arg2);

            private readonly InternalDelegate _delegate;
            private readonly int defaultArg2;

            public Functionstring_string_int_int___Opt(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
                defaultArg2 = (int)Parameters[2].DefaultValue;
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count < 2 || arguments.Count > 3) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `2` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(int);
                var arg2 = defaultArg2;
                int argMask = 4;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToInt(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;
                        case 2:
                            arg2 = context.ToInt(callerContext.Span, arg);
                            break;

                    }
                }

                if (argMask != (1 << 3) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `2` arguments");
                }

                return _delegate(arg0, arg1, arg2);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (string, int, string = ...)
        /// </summary>
        private class Functionstring_string_int_string___Opt : DynamicCustomFunction {
            private delegate string InternalDelegate(string arg0, int arg1, string arg2);

            private readonly InternalDelegate _delegate;
            private readonly string defaultArg2;

            public Functionstring_string_int_string___Opt(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
                defaultArg2 = (string)Parameters[2].DefaultValue;
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count < 2 || arguments.Count > 3) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `2` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(int);
                var arg2 = defaultArg2;
                int argMask = 4;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToInt(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;
                        case 2:
                            arg2 = context.ToString(callerContext.Span, arg);
                            break;

                    }
                }

                if (argMask != (1 << 3) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `2` arguments");
                }

                return _delegate(arg0, arg1, arg2);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (string, string)
        /// </summary>
        private class Functionstring_string_string : DynamicCustomFunction {
            private delegate string InternalDelegate(string arg0, string arg1);

            private readonly InternalDelegate _delegate;

            public Functionstring_string_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (string, string, string)
        /// </summary>
        private class Functionstring_string_string_string : DynamicCustomFunction {
            private delegate string InternalDelegate(string arg0, string arg1, string arg2);

            private readonly InternalDelegate _delegate;

            public Functionstring_string_string_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 3) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `3` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(string);
                var arg2 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;
                        case 2:
                            arg2 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 2);
                            break;

                    }
                }

                if (argMask != (1 << 3) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `3` arguments");
                }

                return _delegate(arg0, arg1, arg2);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (TemplateContext, SourceSpan, IEnumerable, string)
        /// </summary>
        private class Functionstring_TemplateContext_SourceSpan_IEnumerable_string : DynamicCustomFunction {
            private delegate string InternalDelegate(TemplateContext arg0, SourceSpan arg1, IEnumerable arg2, string arg3);

            private readonly InternalDelegate _delegate;

            public Functionstring_TemplateContext_SourceSpan_IEnumerable_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(IEnumerable);
                var arg1 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (IEnumerable)context.ToObject(callerContext.Span, arg, typeof(IEnumerable));
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(context, callerContext.Span, arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (TemplateContext, SourceSpan, object, string)
        /// </summary>
        private class Functionstring_TemplateContext_SourceSpan_object_string : DynamicCustomFunction {
            private delegate string InternalDelegate(TemplateContext arg0, SourceSpan arg1, object arg2, string arg3);

            private readonly InternalDelegate _delegate;

            public Functionstring_TemplateContext_SourceSpan_object_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 2) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }
                var arg0 = default(object);
                var arg1 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 2;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = arg;
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;

                    }
                }

                if (argMask != (1 << 2) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `2` arguments");
                }

                return _delegate(context, callerContext.Span, arg0, arg1);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (TemplateContext, string)
        /// </summary>
        private class Functionstring_TemplateContext_string : DynamicCustomFunction {
            private delegate string InternalDelegate(TemplateContext arg0, string arg1);

            private readonly InternalDelegate _delegate;

            public Functionstring_TemplateContext_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 1;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(context, arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: string (TemplateContext, string, string, string, string = ...)
        /// </summary>
        private class Functionstring_TemplateContext_string_string_string_string___Opt : DynamicCustomFunction {
            private delegate string InternalDelegate(TemplateContext arg0, string arg1, string arg2, string arg3, string arg4);

            private readonly InternalDelegate _delegate;
            private readonly string defaultArg3;

            public Functionstring_TemplateContext_string_string_string_string___Opt(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
                defaultArg3 = (string)Parameters[4].DefaultValue;
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count < 3 || arguments.Count > 4) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `3` arguments");
                }
                var arg0 = default(string);
                var arg1 = default(string);
                var arg2 = default(string);
                var arg3 = defaultArg3;
                int argMask = 8;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 1;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;
                        case 1:
                            arg1 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 1);
                            break;
                        case 2:
                            arg2 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 2);
                            break;
                        case 3:
                            arg3 = context.ToString(callerContext.Span, arg);
                            break;

                    }
                }

                if (argMask != (1 << 4) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting at least `3` arguments");
                }

                return _delegate(context, arg0, arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// Optimized custom function for: TimeSpan (double)
        /// </summary>
        private class FunctionTimeSpan_double : DynamicCustomFunction {
            private delegate TimeSpan InternalDelegate(double arg0);

            private readonly InternalDelegate _delegate;

            public FunctionTimeSpan_double(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(double);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = (double)context.ToObject(callerContext.Span, arg, typeof(double));
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

        /// <summary>
        /// Optimized custom function for: TimeSpan (string)
        /// </summary>
        private class FunctionTimeSpan_string : DynamicCustomFunction {
            private delegate TimeSpan InternalDelegate(string arg0);

            private readonly InternalDelegate _delegate;

            public FunctionTimeSpan_string(MethodInfo method) : base(method) {
                _delegate = (InternalDelegate)method.CreateDelegate(typeof(InternalDelegate));
            }

            public override object Invoke(TemplateContext context, ScriptNode callerContext, ScriptArray arguments, ScriptBlockStatement blockStatement) {
                if (arguments.Count != 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }
                var arg0 = default(string);
                int argMask = 0;

                int argOrderedIndex = 0;
                for (int i = 0; i < arguments.Count; i++) {
                    int argIndex = 0;
                    var arg = arguments[i];
                    var namedArg = arg as ScriptNamedArgument;
                    if (namedArg != null) {
                        Type argType;
                        arg = GetNamedArgument(context, callerContext, namedArg, out argIndex, out argType);
                        argIndex -= 0;
                    }
                    else {
                        argIndex = argOrderedIndex;
                        argOrderedIndex++;
                    }

                    switch (argIndex) {
                        case 0:
                            arg0 = context.ToString(callerContext.Span, arg);
                            argMask |= (1 << 0);
                            break;

                    }
                }

                if (argMask != (1 << 1) - 1) {
                    throw new ScriptRuntimeException(callerContext.Span, $"Invalid number of arguments `{arguments.Count}` passed to `{callerContext}` while expecting `1` arguments");
                }

                return _delegate(arg0);
            }
        }

    }
}

