namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class FreezableExtensions {
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
    }
}
