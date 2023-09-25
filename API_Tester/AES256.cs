using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace API_Tester
{
    class AES256
    {
        //32byte
        static string aes_key = "01234567890123456789012345678901";
        //16byte
        static string aes_iv = aes_key.Substring(0, 16);

        public static string Encrypt(string input)
        {
            byte[] encrypted;

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;

                // 키와 iv를 평문이 아닌 base64로 남겼으면
                // Convert.FromBase64String() >> Base64문자열을 string으로 바꿔주는 함수
                //aes.Key = Convert.FromBase64String(aes_key);
                //aes.IV = Convert.FromBase64String(aes_iv);


                // Encoding.UTF8.GetBytes() >> String을 Byte로 바꿔주는 함수
                aes.Key = Encoding.UTF8.GetBytes(aes_key);
                aes.IV = Encoding.UTF8.GetBytes(aes_iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // 암호문을 만들 수 있는 객체 enc 선언
                ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);


                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(input);
                        }
                        encrypted = ms.ToArray();
                    }
                }
            }

            // 스트링 >> base64로 반환
            return Convert.ToBase64String(encrypted);
        }
    }
}
