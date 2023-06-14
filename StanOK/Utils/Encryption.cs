using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Utils
{
    public class Encryption
    {
        public static string Encrypt (string password)
        {
            string hash = "d65756633986856c50366c1b6a3dbe501e3ef085c45e8aef61a768d0407203d4";
            byte[] data = UTF8Encoding.UTF8.GetBytes(password);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
 
            return Convert.ToBase64String(result);
        }
        public static string Decrypt (string encryptedPassword) 
        {
            string hash = "d65756633986856c50366c1b6a3dbe501e3ef085c45e8aef61a768d0407203d4";
            byte[] data = Convert.FromBase64String(encryptedPassword);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripDES = new TripleDESCryptoServiceProvider();

            tripDES.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripDES.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripDES.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
