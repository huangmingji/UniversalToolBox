using System.Security.Cryptography;
using System.Text;

namespace Common.Cryptography;

public partial class Cryptography
{
    /// <summary>
    /// Des加密
    /// </summary>
    /// <param name="plaintext"></param>
    /// <param name="salt">8字节初始化向量</param>
    /// <param name="key">8字节密钥</param>
    /// <returns></returns>
    public static string DesEncrypt(string plaintext, string salt, string key)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        
        using var des = new DESCryptoServiceProvider();
        des.Key = keyBytes;
        des.IV = saltBytes;
        using var encryptor = des.CreateEncryptor();  
        using var memoryStream = new MemoryStream();  
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);  
  
        var plaintextBytes = Encoding.UTF8.GetBytes(plaintext);  
        cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);  
        cryptoStream.FlushFinalBlock();  
  
        byte[] encrypted = memoryStream.ToArray();  
        return Convert.ToBase64String(encrypted);
    }

    /// <summary>
    /// Des解密
    /// </summary>
    /// <param name="ciphertext"></param>
    /// <param name="salt"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string? DesDecrypt(string ciphertext, string salt, string key)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] cipherText = Convert.FromBase64String(ciphertext);  
        
        using var des = new DESCryptoServiceProvider();  
        des.Key = keyBytes;
        des.IV = saltBytes;
        using var decryptor = des.CreateDecryptor();  
        using var memoryStream = new MemoryStream(cipherText);  
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);  
  
        using var streamReader = new StreamReader(cryptoStream);  
        return streamReader.ReadToEnd();  
    }
}