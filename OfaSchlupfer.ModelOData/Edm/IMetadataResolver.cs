namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.IO;

    public interface IMetadataResolver {
        System.IO.StreamReader Resolve(string location);
    }

    public interface ICachedMetadataResolver : IMetadataResolver {
        Func<StreamReader> SetFixedResolution(string location, System.Func<System.IO.StreamReader> readerFunc);

        System.Func<string, System.IO.StreamReader> SetDynamicResolution(System.Func<string, System.IO.StreamReader> readerFunc);

        IMetadataResolver Chain(IMetadataResolver next);
    }
}