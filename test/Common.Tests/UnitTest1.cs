using Common.Extend;
using Shouldly;
using Xunit.Abstractions;

namespace Common.Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        string salt = Ext.CreateNonceStr(16);
        string key = "sdfsdfsd";
        string plainText = "sdfsdf";
        string ciphertext =  Cryptography.Cryptography.Aes256Encrypt(plainText, salt, key);
        _testOutputHelper.WriteLine(ciphertext);
        ciphertext.ShouldNotBeNullOrWhiteSpace();


        string decryptPlainText = Cryptography.Cryptography.Aes256Decrypt(ciphertext, salt, key); 
        _testOutputHelper.WriteLine(decryptPlainText);
        decryptPlainText.ShouldNotBeNullOrWhiteSpace();

        
        salt = Ext.CreateNonceStr(16);
        key = "sdfsdfsd";
        plainText = "sdfsdf";
        ciphertext =  Cryptography.Cryptography.Aes128Encrypt(plainText, salt, key);
        _testOutputHelper.WriteLine(ciphertext);
        ciphertext.ShouldNotBeNullOrWhiteSpace();


        decryptPlainText = Cryptography.Cryptography.Aes128Decrypt(ciphertext, salt, key); 
        _testOutputHelper.WriteLine(decryptPlainText);
        decryptPlainText.ShouldNotBeNullOrWhiteSpace();
    }
}