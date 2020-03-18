using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFace.Helpers
{
    public interface IHashHelper
    {
        byte[] GenerateSalt();
        string GenerateHash(string pwd, byte[] salt);
    }
    public class HashHelper: IHashHelper
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var randNum = RandomNumberGenerator.Create())
            {
                randNum.GetBytes(salt);
            }
            return salt;
        }
        
        public string GenerateHash(string pwd, byte[] salt)
        {
            string hashedPwd = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pwd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 32
            ));
            return hashedPwd;
        }
    }
}