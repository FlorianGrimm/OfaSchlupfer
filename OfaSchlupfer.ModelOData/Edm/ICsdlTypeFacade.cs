namespace OfaSchlupfer.ModelOData.Edm {
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICsdlTypeFacade {
        ICsdlTypeFacade ItemType { get; set; }
        bool Collection { get; set; }
        bool Nullable { get; set; }
        short MaxLength { get; set; }
        bool FixedLength { get; set; }
        byte Precision { get; set; }
        byte Scale { get; set; }
        bool Unicode { get; set; }
        string Collation { get; set; }
        string SRID { get; set; }
    }
}
