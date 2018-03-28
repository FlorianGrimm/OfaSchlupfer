namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.IO;


    public class CachedMetadataResolver : ICachedMetadataResolver {
        private System.Func<string, System.IO.StreamReader> _DynamicResolution;
        private Dictionary<string, Func<StreamReader>> _Resolutions;
        public IMetadataResolver ChainNext;

        public CachedMetadataResolver() {
            this._Resolutions = new Dictionary<string, Func<StreamReader>>(StringComparer.OrdinalIgnoreCase);
            this._DynamicResolution = defaultDynamicResolution;
        }

        public System.Func<string, System.IO.StreamReader> DynamicResolution {
            get { return this._DynamicResolution; }
            set { this._DynamicResolution = value ?? defaultDynamicResolution; }
        }


        public StreamReader Resolve(string location) {
            var readerFuncs = this._Resolutions;
            var dynamicResolution = this._DynamicResolution;
            var next = this.ChainNext;
            System.Threading.Interlocked.MemoryBarrier();
            StreamReader result = null;
            Func<StreamReader> func = null;
            readerFuncs.TryGetValue(location, out func);
            if ((object)func != null) {
                result = func();
            }
            if ((object)result == null) {
                result = dynamicResolution(location);
                if ((object)result == null) {
                    result = next.Resolve(location);
                }
            }
            return result;
        }

        public System.Func<string, System.IO.StreamReader> SetDynamicResolution(Func<string, StreamReader> readerFunc) {
            var result = this.DynamicResolution;
            System.Threading.Interlocked.MemoryBarrier();
            this.DynamicResolution = readerFunc ?? defaultDynamicResolution;
            return result;
        }

        public Func<StreamReader> SetFixedResolution(string location, Func<StreamReader> readerFunc) {
            while (true) {
                Func<StreamReader> result = null;
                var o = this._Resolutions;
                System.Threading.Interlocked.MemoryBarrier();
                var n = new Dictionary<string, Func<StreamReader>>(this._Resolutions, StringComparer.OrdinalIgnoreCase);
                n.TryGetValue(location, out result);
                n[location] = readerFunc;
                if (ReferenceEquals(System.Threading.Interlocked.CompareExchange(ref this._Resolutions, n, o), o)) {
                    return result;
                }
            }
        }

        private static StreamReader defaultDynamicResolution(string location) => null;

        public IMetadataResolver Chain(IMetadataResolver next) {
            var result = this.ChainNext;
            this.ChainNext = next;
            return result;
        }
    }
}