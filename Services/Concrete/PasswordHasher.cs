using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

public class PasswordHasher : IPasswordHasher
{
    private const int Iterations = 100000;
    private const int KeySize = 32; // 256 bit

    public string HashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(16); // 128 bit salt
        var hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: Iterations,
            numBytesRequested: KeySize);

        return Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToVerify = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: Iterations,
            numBytesRequested: KeySize);

        return CryptographicOperations.FixedTimeEquals(hashToVerify, Convert.FromBase64String(hash));
    }
}   