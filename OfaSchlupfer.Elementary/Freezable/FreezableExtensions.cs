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
                    if (name is null) {
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
                    if (name is null) {
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
                    if (name is null) {
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
        public static bool SetOwnerWithChildren<TThis, TOwner>(this TThis that, ref TOwner thisPropertyOwner, TOwner value, Func<TOwner, IList<TThis>> getChildren)
            where TThis : class, IFreezeable, IContainerNamedReferences
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
                if (cnt == 0) {
                    lst.Add(that);
                } else {
                    if (cnt > 0) {
                        if (ReferenceEquals(lst[cnt - 1], that)) {
                            // already added
                        } else {
                            var pos = lst.IndexOf(that);
                            if (pos < 0) {
                                lst.Add(that);
                            }
                        }
                    }
                }
                that.ResolveNamedReferences(ModelErrors.GetIgnorance());
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static TKey GetPairNameProperty<TThis, TKey, TValue>(this TThis @this, ref TKey thisKey, ref TValue thisValue, Func<TValue, TKey> getName)
            where TThis : class, IFreezeable
            //where TKey : class
            where TValue : class {
            if ((object)thisValue is null) {
                return thisKey;
            } else {
                return getName(thisValue);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool SetPairNameProperty<TThis, TKey, TValue>(this TThis @this, ref TKey thisKey, ref TValue thisValue, TKey value, Func<TThis, TKey, TValue> resolve)
            where TThis : class, IFreezeable
            //where TKey : class
            where TValue : class {
            @this.ThrowIfFrozen();
            thisKey = value;
            if ((object)value is null) {
                thisValue = default(TValue);
            } else {
                thisValue = resolve(@this, value);
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static TValue GetPairRefProperty<TThis, TKey, TValue>(this TThis @this, ref TKey thisKey, ref TValue thisValue, Func<TThis, TKey, TValue> resolve)
            where TThis : class, IFreezeable
            where TKey : class
            where TValue : class {
            if (thisValue is null) {
                thisValue = resolve(@this, thisKey);
            }
            return thisValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static bool SetPairRefProperty<TThis, TKey, TValue>(this TThis @this, ref TKey thisKey, ref TValue thisValue, TValue value, Func<TValue, TKey> getName)
            where TThis : class, IFreezeable
            where TKey : class
            where TValue : class {
            @this.ThrowIfFrozen();
            thisValue = value;
            if (value is null) {
                thisKey = default(TKey);
            } else {
                thisKey = getName(value);
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static TMappingValue ResolveNameHelper<TOwner, TName, TMappingKey, TMappingValue>(
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
            if (owner is null) { return default(TMappingValue); }
            if ((thisPropertyValue is null) && !(thisPropertyName is null)) {
                var lstFound = findByKey(owner, thisPropertyName);
                if (lstFound.Count == 1) {
                    thisPropertyValue = lstFound[0];
                    thisPropertyName = null;
                    return lstFound[0];
                } else if (lstFound.Count == 0) {
                    errors.AddErrorOrThrow($"Entity named {thisPropertyName} not found", name?.ToString(), ResolveNameNotFoundException.Factory);
                    return default(TMappingValue);
                } else {
                    errors.AddErrorOrThrow($"Entity named {thisPropertyName} found #{lstFound.Count} times.", name?.ToString(), ResolveNameNotUniqueException.Factory);
                    return default(TMappingValue);
                }
            } else {
                return default(TMappingValue);
            }
        }
    }
}
