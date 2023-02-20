using System.Security.Cryptography;
using System.Text;

namespace Hafta3.Odev3_4.Extensions
{
    // This extension will help to hash and salt User's passwords and keep them at Db safer.
    public static class PasswordHasherExtension
    {
        const int keySize = 64;
        const int iterations = 350000;
        static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        // Password Hashing method
        public static string HashPasword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash) + Convert.ToHexString(salt);
        }

        // Method to verify passwords at login process.
        public static bool VerifyPassword(string password, string hash)
        {
            // Getting "Salt" value from stored password hash.
            byte[] salt = Convert.FromHexString(hash.Substring(128, 128));

            //Seperating password hash from salted Hash.
            hash = hash.Substring(0, 128);

            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}
