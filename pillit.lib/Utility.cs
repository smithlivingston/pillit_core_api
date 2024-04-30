using System;
using System.Security.Cryptography;

namespace pillit.lib
{
    public class Utility 
    {
        public static byte[] GenerateSalt()
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static string GenerateHashedPassword(string password, byte[] salt)
        {
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                // Generate the hashed password
                byte[] hashedBytes = deriveBytes.GetBytes(32); // 32 bytes = 256 bits (recommended for SHA256)
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
