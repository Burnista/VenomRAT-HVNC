using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Extension;

namespace VenomRAT_HVNC.Server.Helper
{
    public static class CreateCertificate
    {
        public static X509Certificate2 CreateCertificateAuthority(
          string caName,
          int keyStrength)
        {
            SecureRandom random = new SecureRandom();
            RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(new KeyGenerationParameters(random, keyStrength));
            AsymmetricCipherKeyPair keyPair = keyPairGenerator.GenerateKeyPair();
            X509V3CertificateGenerator certificateGenerator = new X509V3CertificateGenerator();
            X509Name issuer = new X509Name("CN=" + caName + ",OU=qwqdanchun,O=DcRat By qwqdanchun,L=SH,C=CN");
            X509Name subject = new X509Name("CN=DcRat");
            BigInteger serialNumber = BigInteger.ProbablePrime(160, (Random)new SecureRandom());
            certificateGenerator.SetSerialNumber(serialNumber);
            certificateGenerator.SetSubjectDN(subject);
            certificateGenerator.SetIssuerDN(issuer);
            certificateGenerator.SetNotAfter(DateTime.UtcNow.Subtract(new TimeSpan(-3650, 0, 0, 0)));
            certificateGenerator.SetNotBefore(DateTime.UtcNow.Subtract(new TimeSpan(285, 0, 0, 0)));
            certificateGenerator.SetPublicKey(keyPair.Public);
            certificateGenerator.AddExtension(X509Extensions.SubjectKeyIdentifier, false, (Asn1Encodable)new SubjectKeyIdentifierStructure(keyPair.Public));
            certificateGenerator.AddExtension(X509Extensions.BasicConstraints, true, (Asn1Encodable)new BasicConstraints(true));
            ISignatureFactory signatureCalculatorFactory = (ISignatureFactory)new Asn1SignatureFactory("SHA512WITHRSA", keyPair.Private, random);
            return new X509Certificate2(DotNetUtilities.ToX509Certificate(certificateGenerator.Generate(signatureCalculatorFactory)))
            {
                PrivateKey = (AsymmetricAlgorithm)DotNetUtilities.ToRSA(keyPair.Private as RsaPrivateCrtKeyParameters)
            };
        }
    }
}