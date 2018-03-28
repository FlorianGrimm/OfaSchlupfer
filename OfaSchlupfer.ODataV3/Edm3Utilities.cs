namespace OfaSchlupfer.ODataV3 {
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.Data.Edm;
    using Microsoft.Data.Edm.Csdl;

    public static class Edm3Utilities {
        public static bool IsDefaultEntityContainer(this IEdmModel model, IEdmEntityContainer entityContainer) {
            bool isDefaultContainer = false;
            var obj = Microsoft.Data.Edm.ExtensionMethods.GetAnnotationValue(
                model,
                entityContainer,
                Edm3Constants.DataServicesNamespace,
                Edm3Constants.IsDefaultEntityContainerAttributeName);

            //if (TryGetBooleanAnnotation(model, entityContainer, EdmConstants.IsDefaultEntityContainerAttributeName, out isDefaultContainer)) {
            //    return isDefaultContainer;
            //}
            if (obj is Microsoft.Data.Edm.Library.Values.EdmStringConstant stringConstant) {
                if (string.Equals(stringConstant.Value, Edm3Constants.TrueLiteral, StringComparison.InvariantCultureIgnoreCase)) {
                    isDefaultContainer = true;
                }
            }

            return isDefaultContainer;
        }
    }
}
