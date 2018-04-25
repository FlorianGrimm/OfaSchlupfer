namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using OfaSchlupfer.Model;

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

        /// <summary>
        /// set this.Property = value and value.Owner = this;
        /// </summary>
        /// <typeparam name="TThis">this owner</typeparam>
        /// <typeparam name="TProperty">child</typeparam>
        /// <param name="that">this</param>
        /// <param name="thisProperty">this.Child</param>
        /// <param name="value">value</param>
        /// <returns></returns>
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

        /// <summary>
        /// Set this.Owner to value and value.Dynamic = this;
        /// </summary>
        /// <typeparam name="TThis">this</typeparam>
        /// <typeparam name="TOwner">the owner</typeparam>
        /// <param name="that">this</param>
        /// <param name="thisProperty">this.Owner</param>
        /// <param name="value">value</param>
        /// <param name="getChildPropertyofOwner">gets value.Dynamic</param>
        /// <param name="setChildPropertyofOwner">sets value.Dynamic</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool SetOwnerAndProperty<TThis, TOwner>(this TThis that, ref TOwner thisProperty, TOwner value, Func<TOwner, TThis> getChildPropertyofOwner, Action<TOwner, TThis> setChildPropertyofOwner)
            where TThis : class, IFreezeable
            where TOwner : class {
            if (ReferenceEquals(thisProperty, value)) { return false; }
            if (!(thisProperty is null)) { that.ThrowIfFrozen(); }
            var oldValue = thisProperty;
            thisProperty = value;
            if (!(value is null)) {
                setChildPropertyofOwner(value, that);
            }
            if (!(oldValue is null)) {
                if (ReferenceEquals(getChildPropertyofOwner(oldValue), that)) {
                    setChildPropertyofOwner(oldValue, null);
                }
            }
            return true;
        }

        /// <summary>
        /// set this.Owner = value and add/removes it from the children list
        /// </summary>
        /// <typeparam name="TThis">this</typeparam>
        /// <typeparam name="TOwner">the owner</typeparam>
        /// <param name="that">this</param>
        /// <param name="thisPropertyOwner">this.Owner</param>
        /// <param name="value">value</param>
        /// <param name="getChildren">owener.ChildrenList</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool SetOwner<TThis, TOwner>(this TThis that, ref TOwner thisPropertyOwner, TOwner value, Func<TOwner, IList<TThis>> getChildren)
            where TThis : class, IFreezeable
            where TOwner : class {
            if (ReferenceEquals(thisPropertyOwner, value)) {
                return false;
            }
            if (!(thisPropertyOwner is null)) {
                that.ThrowIfFrozen();
            }
            var oldValue = thisPropertyOwner;
            thisPropertyOwner = value;
            if (!(oldValue is null)) {
                var lst = getChildren(oldValue);
                lst.Remove(that);
            }
            if (!(value is null)) {
                var lst = getChildren(value);
                var cnt = lst.Count;
                if (cnt > 0) {
                    if (ReferenceEquals(lst[cnt - 1], that)) {
                        // already added
                        return true;
                    }
                }
                var pos = lst.IndexOf(that);
                if (pos < 0) {
                    lst.Add(that);
                }
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void ResolveNameHelper<TOwner, TName, TMappingKey, TMappingValue>(
            this IFreezeable freezeable,
            TOwner owner,
            TName name,
            ref TMappingKey thisPropertyName,
            ref TMappingValue thisPropertyValue,
            Func<TOwner, TMappingKey, List<TMappingValue>> findByKey,
            ModelErrors errors)
            where TOwner : class
            where TMappingKey : class
            where TMappingValue : class {
            if (owner is null) { return; }
            if (((object)thisPropertyValue == null) && !((object)thisPropertyName != null)) {
                var lstFound = findByKey(owner, thisPropertyName);
                if (lstFound.Count == 1) {
                    thisPropertyValue = lstFound[0];
                    thisPropertyName = null;
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Source {thisPropertyName} not found", name?.ToString(), ResolveNameNotFoundException.Factory);
                } else {
                    errors.AddErrorOrThrow($"Source {thisPropertyName} found #{lstFound.Count} times.", name?.ToString(), ResolveNameNotUniqueException.Factory);
                }
            }
        }
    }
}
