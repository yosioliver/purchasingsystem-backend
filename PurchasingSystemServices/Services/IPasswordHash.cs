using System;
namespace PurchasingSystemServices.Services
{
    public interface IPasswordHash
    {
        string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false);
        bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck);
    }
}
