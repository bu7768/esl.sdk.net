using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class SignerSpecificEmailMessageExample : SDKSample
	{
        public static void Main (string[] args)
        {
            new SignerSpecificEmailMessageExample(Props.GetInstance()).Run();
        }

        private string email1;
        private Stream fileStream1;

        public SignerSpecificEmailMessageExample( Props props ) : this(props.Get("api.url"), props.Get("api.key"), props.Get("1.email")) {
        }

        public SignerSpecificEmailMessageExample( string apiKey, string apiUrl, string email1 ) : base( apiKey, apiUrl ) {
            this.email1 = email1;
            this.fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document.pdf").FullName);
        }

        override public void Execute()
        {
            DocumentPackage package = PackageBuilder.NewPackageNamed ("SignerSpecificEmailMessageExample " + DateTime.Now)
					.DescribedAs ("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith")
					            .WithEmailMessage("Hi John, could you sign this asap please?"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
					              		.OnPage(0)
					               		.AtPosition(500, 100))
                                  .WithSignature (SignatureBuilder.InitialsFor(email1)
					                	.OnPage (0)
					                	.AtPosition (500, 200))
                                  .WithSignature(SignatureBuilder.CaptureFor (email1)
					               		.OnPage (0)
					               		.AtPosition (500, 300)))
					.Build ();

			PackageId id = eslClient.CreatePackage (package);
			eslClient.SendPackage(id);
		}
	}
}