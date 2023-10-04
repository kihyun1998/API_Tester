using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace API_Tester
{
    class SHA256
    {
        public static string Hash(string text)
        {
            System.Security.Cryptography.SHA256 sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(Encoding.ASCII.GetBytes(text));
            StringBuilder stringBuilder = new StringBuilder();

            foreach(byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        public static bool CheckIntegrity(string originText, string hashText)
        {
            string decryptHash = Hash(originText);
            if (string.Equals(hashText, decryptHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
