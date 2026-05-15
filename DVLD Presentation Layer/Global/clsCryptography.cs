using System;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Global
{
    public class clsCryptography
    {
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static string EncryptUsingHash(string PlainText, string Key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = new byte[aes.BlockSize / 8];

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(PlainText);
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptUsingHash(string EncryptedText, string Key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = new byte[aes.BlockSize / 8];

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(EncryptedText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        public static string EncryptUsingRSA(string PlainText, string PublicKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(PublicKey);
                    byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(PlainText), false);
                    return Convert.ToBase64String(encryptedData);
                }
            }
            catch (CryptographicException ex)
            {
                clsLogging.LogException(ex.Message, EventLogEntryType.Error);
                return null;
            }
        }

        public static string DecryptUsingRSA(string DecryptedText, string PrivateKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(PrivateKey);
                    byte[] encryptedData = Convert.FromBase64String(DecryptedText);
                    byte[] decryptedData = rsa.Decrypt(encryptedData, false);
                    return Encoding.UTF8.GetString(decryptedData);
                }
            }
            catch (CryptographicException ex)
            {
                clsLogging.LogException(ex.Message, EventLogEntryType.Error);
                return null;
            }
        }

        public static string GeneratePublicKey()
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    return rsa.ToXmlString(false);
                }
            }
            catch (CryptographicException ex)
            {
                clsLogging.LogException(ex.Message, EventLogEntryType.Error);
                return null;
            }
            catch (Exception ex)
            {
                clsLogging.LogException(ex.Message, EventLogEntryType.Error);
                return null;
            }
        }

        public static string GeneratePrivateKey()
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    return rsa.ToXmlString(true);
                }
            }
            catch (CryptographicException ex)
            {
                clsLogging.LogException(ex.Message, EventLogEntryType.Error);
                return null;
            }
            catch (Exception ex)
            {
                clsLogging.LogException(ex.Message, EventLogEntryType.Error);
                return null;
            }
        }
    }
}
