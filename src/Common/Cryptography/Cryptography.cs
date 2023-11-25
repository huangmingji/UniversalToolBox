using System.Security.Cryptography;
using System.Text;

namespace Common.Cryptography;

/// <summary>
/// 加密相关类
/// </summary>
public partial class Cryptography
{
    public static string Aes128Encrypt(string plainText, string salt, string key)
    {
        return AesEncrypt(plainText, salt, key, 128);
    }

    public static string Aes128Decrypt(string cipherText, string salt, string key)
    {
        return AesDecrypt(cipherText, salt, key, 128);
    }
    
    public static string Aes256Encrypt(string plainText, string salt, string key)
    {
        return AesEncrypt(plainText, salt, key);
    }

    public static string Aes256Decrypt(string cipherText, string salt, string key)
    {
        return AesDecrypt(cipherText, salt, key);
    }

    private static string AesEncrypt(string plainText, string salt, string key, int keySize = 256)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

        using var aes = Aes.Create();
        aes.KeySize = keySize;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = HashKey(keyBytes, aes.KeySize);
        if (!string.IsNullOrWhiteSpace(salt))
        {
            aes.IV = saltBytes;
        }

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainBytes, 0, plainBytes.Length);
        cryptoStream.FlushFinalBlock();
        return Convert.ToBase64String(memoryStream.ToArray());
    }

    private static string AesDecrypt(string cipherText, string salt, string key, int keySize = 256)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using var aes = Aes.Create();
        aes.KeySize = keySize;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = HashKey(keyBytes, aes.KeySize);
        if (!string.IsNullOrWhiteSpace(salt))
        {
            aes.IV = saltBytes;
        }

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write);
        cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
        cryptoStream.FlushFinalBlock();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }
    
    private static byte[] HashKey(byte[] keyBytes, int keySize)
    {
        using (var hashAlgorithm = SHA256.Create())
        {
            byte[] hashedKey = hashAlgorithm.ComputeHash(keyBytes);
            Array.Resize(ref hashedKey, keySize / 8); // 调整字节数组大小为密钥大小  
            return hashedKey;
        }
    }
}
