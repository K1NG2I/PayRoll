
using RFQ.Domain.Models;

namespace RFQ.Application.Interface
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providedPassword);
        string Encrypt(string plainText);
        public string Decrypt(string encryptedText);
    }
}
