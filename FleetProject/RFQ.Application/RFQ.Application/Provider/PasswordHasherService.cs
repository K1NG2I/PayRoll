using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using RFQ.Application.Interface;
using RFQ.Domain.Models;

public class PasswordHasherService : IPasswordHasher
{
    private readonly IPasswordHasher<object> _passwordHasher;
    private static readonly string Key = "12345678901234567890123456789012"; // 32-byte key for AES-256

    public PasswordHasherService()
    {
        _passwordHasher = new PasswordHasher<object>();
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        
        return result == PasswordVerificationResult.Success;
    }


    // AES Encryption Method
    public string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[16]; // Default IV (should be randomized in production)

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }

    // AES Decryption Method
    public string Decrypt(string encryptedText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[16]; // Must match the IV used in encryption

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
