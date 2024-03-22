using BCrypt.Net;
using Humanizer.Bytes;
using System.Security.Cryptography;
using System.Text;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public enum ReturnType
    {
        String,
        ByteArray
    }
    public class HashingService : IHashingService
    {
        public dynamic MD5Hash(string inputText, ReturnType returnType)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);
            byte[] hashedValue = MD5.HashData(inputBytes);

            if(returnType == ReturnType.String)
            {
                return Convert.ToBase64String(hashedValue);
            }
            else
            {
                return hashedValue;
            }

        }

        public dynamic SHA2Hash(string inputText, ReturnType returnType)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);
            var hashedValue = SHA256.HashData(inputBytes);

            return Convert.ToBase64String(hashedValue);
        }

        public dynamic HMACHash(string inputText, ReturnType returnType)
        {
            byte[] hashKey = Encoding.ASCII.GetBytes("BoB");
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);
            var hashedValue = HMACSHA256.HashData(hashKey, inputBytes);

            return Convert.ToBase64String(hashedValue);
        }

        //Most the parameters will be hardcoded, chage for dynamic
        public dynamic PBKDF2Hash(string inputText, ReturnType returnType)
        {
            
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);
            byte[] salt = Encoding.ASCII.GetBytes("SaltyText");

            var hashingAlgorithmName = new HashAlgorithmName("SHA256");

            int iterations = 10;

            var hashedValue = Rfc2898DeriveBytes.Pbkdf2(inputBytes, salt, iterations, hashingAlgorithmName, 32);

            return Convert.ToBase64String(hashedValue);
        }

        public dynamic BCryptHash(string inputText, ReturnType returnType)
        {

            int workFactor = 10;
            bool entropy = true;
            string salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor); //Using workforce will modify the salt to use that workfactor
            var hashType = HashType.SHA256;

            //Without salt and iterations
            //return BCrypt.Net.BCrypt.HashPassword(textToHash);

            //Hash with iterations and entropy(Sha384)
            //return BCrypt.Net.BCrypt.HashPassword(textToHash, workFactor, entropy);

            //Hash with iterations and defined hashType
            return BCrypt.Net.BCrypt.HashPassword(inputText, salt, entropy, hashType);
        }

        public bool BCryptHashValidate(string inputText, string hashedValue)
        {
            var hashType = HashType.SHA256;

            //Standard with no entropy
            //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValue);

            //With entropy defined, iterations are implicit from hash value.
            //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValue, true);

            //With salt, entropy, salt and hash type.
            return BCrypt.Net.BCrypt.Verify(inputText, hashedValue, true, hashType);
        }

    }
}
