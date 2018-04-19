namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public static class FreezableExtensions {

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T AsFrozen<T>(this T that)
            where T : IFreezeable {
            that.Freeze();
            return that;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowIfFrozen(this IFreezeable that, string name = null) {
            if ((object)that != null) {
                if (that.IsFrozen()) {
                    if ((object)name == null) {
                        throw new InvalidOperationException($"{that.GetType().FullName} is frozen.");
                    } else {
                        throw new InvalidOperationException($"{name} is frozen.");
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowIfNotFrozen(this IFreezeable that, string name = null) {
            if ((object)that != null) {
                if (!(that.IsFrozen())) {
                    if ((object)name == null) {
                        throw new InvalidOperationException($"{that.GetType().FullName} is NOT frozen.");
                    } else {
                        throw new InvalidOperationException($"{name} is NOT frozen.");
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetOrThrowIfFrozen<T>(this IFreezeable that, ref T target, T value, string name = null) {
            if ((object)that != null) {
                if (that.IsFrozen()) {
                    if ((object)name == null) {
                        throw new InvalidOperationException($"{that.GetType().FullName} is frozen.");
                    } else {
                        throw new InvalidOperationException($"{name} is frozen.");
                    }
                }
            }
            target = value;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool SetPropertyAndOwner<TThis, TProperty>(this TThis that, ref TProperty thisProperty, TProperty value)
            where TThis : class, IFreezeable
            where TProperty : class, IObjectWithOwner<TThis> {            
            if (ReferenceEquals(thisProperty, value)) { return false; }
            that.ThrowIfFrozen();
            var oldValue = thisProperty;
            thisProperty = value;
            if (!(value is null)) {
                value.Owner = that;
            }
            if (!(oldValue is null)) {
                if (ReferenceEquals(oldValue.Owner, that)) {
                    oldValue.Owner = null;
                }
            }
            return true;
        }
    }
}
