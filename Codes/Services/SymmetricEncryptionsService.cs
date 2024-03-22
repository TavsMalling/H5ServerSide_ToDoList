using Microsoft.AspNetCore.DataProtection;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public class SymmetricEncryptionsService : ISymmetricEncryptionService
    {
        //.Net name for encryption/decryption is protect/unprotect
        private readonly IDataProtector _dataProtector;
        public SymmetricEncryptionsService(IDataProtectionProvider dataProtector)
        {
            _dataProtector = dataProtector.CreateProtector("BoB");
        }

        public string Encrypt(string inputText) 
        {
            return _dataProtector.Protect(inputText);
        }

        public string Decrypt(string inputText)
        {
            return _dataProtector.Unprotect(inputText);
        }
    }
}
