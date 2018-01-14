namespace OfaSchlupfer.Elementary.Immutable {
    using System;

    public class BuildTargetBase : IBuildTarget {
        private bool _IsFrozen;
        private FreezeReceiverList _FreezeReceiverList;

        /// <summary>
        /// Gets a value indicating whether this instance is frozen.
        /// </summary>
        public bool IsFrozen => this._IsFrozen;

        /// <summary>
        /// Add FreezeHandler
        /// </summary>
        /// <param name="freezeReceiver">freezeReceiver</param>
        public void AddFreezeReceiver(IFreezeReceiver freezeReceiver) {
            if ((object)freezeReceiver != null) {
                FreezeReceiverList.Add(ref this._FreezeReceiverList, freezeReceiver);
            }
        }

        /// <summary>
        /// Freeze this instance.
        /// </summary>
        public void Freeze() {
            if (!(this._IsFrozen)) {
                this._IsFrozen = true;
                this.FreezeChildren();

                // Freeze
                FreezeReceiverList.HandleFreeze(ref this._FreezeReceiverList, this);
            }
        }

        /// <summary>
        /// Freeze the children of this.
        /// </summary>
        protected virtual void FreezeChildren() { }

        /// <summary>
        /// Throw if frozen
        /// </summary>
        public void ThrowIfFozen() {
            if (this._IsFrozen) {
                throw new InvalidOperationException("frozen");
            }
        }

        /// <summary>
        /// Un freeze means clone and return the new instance if frozen.
        /// </summary>
        /// <param name="cloneAlways">clone</param>
        /// <returns>a clone or this if not frozen.</returns>
        public IBuildTarget UnFreeze(bool cloneAlways = false) {
            if (this._IsFrozen || cloneAlways) {
                var result = (BuildTargetBase)this.UnFreezeCreateInstance();
                result.UnFreezeChildren();

                // UnFreeze
                FreezeReceiverList.HandleUnFreeze(ref this._FreezeReceiverList, this, result);

                // done
                return result;
            } else {
                return this;
            }
        }

        /// <summary>
        /// Create a unfrozen instance
        /// </summary>
        /// <returns>a new instacne</returns>
        protected virtual IBuildTarget UnFreezeCreateInstance() {
            var result = (BuildTargetBase)this.MemberwiseClone();
            result._IsFrozen = false;
            result._FreezeReceiverList = null;
            return result;
        }

        /// <summary>
        /// Freeze the children of this.
        /// </summary>
        protected virtual void UnFreezeChildren() {
        }

        private class FreezeReceiverList {
            public static void Add(ref FreezeReceiverList freezeReceiverList, IFreezeReceiver freezeReceiver) {
                if ((object)freezeReceiver != null) {
                    freezeReceiverList = new FreezeReceiverList(freezeReceiverList, freezeReceiver);
                }
            }

            private FreezeReceiverList _Next;
            private IFreezeReceiver _FreezeReceiver;

            private FreezeReceiverList(FreezeReceiverList next, IFreezeReceiver freezeReceiver) {
                this._Next = next;
                this._FreezeReceiver = freezeReceiver;
            }

            internal static void HandleFreeze(ref FreezeReceiverList freezeReceiverList, IBuildTarget frozenBuildTarget) {
                FreezeReceiverList currentList = freezeReceiverList;
                if ((object)currentList == null) { return; }
                FreezeReceiverList previousList = null;
                do {
                    var freezeReceiver = currentList._FreezeReceiver;
                    if ((object)freezeReceiver != null) {
                        bool bRemove = freezeReceiver.HandleFreeze(frozenBuildTarget);
                        if (bRemove) {
                            currentList._FreezeReceiver = freezeReceiver = null;
                        }
                    }

                    // next
                    var next = currentList._Next;
                    if ((object)freezeReceiver == null) {
                        // do not touch previousList
                        if ((object)previousList != null) {
                            previousList._Next = next;
                            currentList = next;
                        } else {
                            currentList = next;
                        }
                    } else {
                        previousList = currentList;
                        currentList = next;
                    }
                } while ((object)currentList != null);

                // is it empty
                if (((object)freezeReceiverList._FreezeReceiver == null)
                    && ((object)freezeReceiverList._Next == null)) {
                    freezeReceiverList = null;
                }
            }

            internal static void HandleUnFreeze(ref FreezeReceiverList freezeReceiverList, IBuildTarget previousBuildTarget, IBuildTarget nextBuildTarget) {
                FreezeReceiverList currentList = freezeReceiverList;
                if ((object)currentList == null) { return; }
                FreezeReceiverList previousList = null;
                do {
                    var freezeReceiver = currentList._FreezeReceiver;
                    if ((object)freezeReceiver != null) {
                        bool bRemove = freezeReceiver.HandleUnFreeze(previousBuildTarget, nextBuildTarget);
                        if (bRemove) {
                            currentList._FreezeReceiver = freezeReceiver = null;
                        }
                    }

                    // next
                    var next = currentList._Next;
                    if ((object)freezeReceiver == null) {
                        // do not touch previousList
                        if ((object)previousList != null) {
                            previousList._Next = next;
                            currentList = next;
                        } else {
                            currentList = next;
                        }
                    } else {
                        previousList = currentList;
                        currentList = next;
                    }
                } while ((object)currentList != null);

                // is it empty
                if (((object)freezeReceiverList._FreezeReceiver == null)
                    && ((object)freezeReceiverList._Next == null)) {
                    freezeReceiverList = null;
                }
            }
        }
    }
}
