using System.Security.Cryptography;

namespace Common.Cryptography;
public class RsaKeyPairGenerator
{
    public static KeyValuePair<string, string> GenerateKeys(int keySize = 2048)
    {
        // 创建RSA实例  
        using RSA rsa = RSA.Create(keySize);
        // 导出私钥  
        byte[] privateKeyBytes = rsa.ExportRSAPrivateKey();
        string privateKey = Convert.ToBase64String(privateKeyBytes);

        // 导出公钥  
        byte[] publicKeyBytes = rsa.ExportRSAPublicKey();
        string publicKey = Convert.ToBase64String(publicKeyBytes);
        
        return new KeyValuePair<string, string>(privateKey, publicKey);
    }
}