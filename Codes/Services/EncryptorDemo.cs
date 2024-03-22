using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public class EncryptorDemo
    {
        public static string Encrypter(string textToEncrypt, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new())
            {
                rsa.FromXmlString(publicKey);

                byte[] byteArrayInputText = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);

                byte[] encryptedTextByteArray = rsa.Encrypt(byteArrayInputText, true);

                return Convert.ToBase64String(encryptedTextByteArray);
            }
        }
    }
}
