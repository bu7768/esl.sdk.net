using System;

namespace Silanis.ESL.SDK.Builder
{
    public class DocumentPackageAttributesBuilder
    {
        private DocumentPackageAttributes attributes = new DocumentPackageAttributes();

        public DocumentPackageAttributesBuilder withAttribute( string name, Object value ) {
            this.attributes.append(name, value);
            return this;
        }

        public DocumentPackageAttributes build() {
            return attributes;
        }
    }
}

