using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionDiary.BR
{
    public class PasswordHelper
    {
        private static int  PASSWORD_SIZE_SALT = 9;
        public static string HashString(string source)
        {
            string result = string.Empty;

            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(source);
            data = provider.ComputeHash(data);
            for (int i = 0; i < data.Length; i++)
                result += data[i].ToString("X2").ToLower();
            return result;
        }

        public static string CreateHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd = HashString(saltAndPwd);
            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }


        public static string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[PASSWORD_SIZE_SALT];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
    }

}
