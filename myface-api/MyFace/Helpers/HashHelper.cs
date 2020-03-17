using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFace.Helpers
{
    public class HashHelper
    {
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var randNum = RandomNumberGenerator.Create())
            {
                randNum.GetBytes(salt);
            }
            return salt;
        }

        public static string GenerateHash(string pwd, byte[] salt)
        {
            string hashedPwd = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pwd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256/8
            ));
            return hashedPwd;
        }
    }
}