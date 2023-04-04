using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Tools.Clases_varias
{
    internal class Firma
    {
        public XmlDocument Firma2(XmlDocument xmlDocument, string rutaArchivoCertificado, string passwordCertificado)
        {
            xmlDocument.PreserveWhitespace = true;
            XmlNode ExtensionContent = xmlDocument.GetElementsByTagName("ExtensionContent", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2").Item(0);
            ExtensionContent.RemoveAll();
            X509Certificate2 x509Certificate2 = new X509Certificate2(File.ReadAllBytes(rutaArchivoCertificado), passwordCertificado, X509KeyStorageFlags.Exportable);
            RSACryptoServiceProvider key = new RSACryptoServiceProvider(new CspParameters(24));
            SignedXml signedXML = new SignedXml(xmlDocument);
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            KeyInfo keyInfo = new KeyInfo();
            KeyInfoX509Data keyInfoX509Data = new KeyInfoX509Data(x509Certificate2);
            Reference reference = new Reference("");
            string exportarLlave = x509Certificate2.PrivateKey.ToXmlString(true);
            key.PersistKeyInCsp = false;
            key.FromXmlString(exportarLlave);
            reference.AddTransform(env);
            signedXML.SigningKey = key;
            Signature XMLSignature = signedXML.Signature;
            XMLSignature.SignedInfo.AddReference(reference);
            keyInfoX509Data.AddSubjectName(x509Certificate2.Subject);
            keyInfo.AddClause(keyInfoX509Data);
            XMLSignature.KeyInfo = keyInfo;
            XMLSignature.Id = "SignatureKG";
            signedXML.ComputeSignature();
            ExtensionContent.AppendChild(signedXML.GetXml());
            return xmlDocument;
        }
    }
}
