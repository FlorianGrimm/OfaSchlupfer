namespace OfaSchlupfer.Elementary.Immutable {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class FreezeVersion : IDisposable {
        private bool _IsDisposed;
        private WeakReference<FreezeVersion> _Parent;
        private FreezeVersionNode _First;
        private FreezeVersionNode _Last;

        public FreezeVersion() {
        }

        private FreezeVersion(FreezeVersion parent) {
            this._Parent = new WeakReference<FreezeVersion>(parent);
        }

        private void Dispose(bool disposing) {
            if (!this._IsDisposed) {
                /*
                var current = this._First;
                while ((object)current != null) {
                   current.
                }
                this._First = this._Last = null;
                */
            }
        }

        ~FreezeVersion() {
            this.Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            this.Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
