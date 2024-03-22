namespace H5ServerSide_ToDoList.Codes.Services
{
    public interface ISymmetricEncryptionService
    {
        string Encrypt(string inputText);

        string Decrypt(string inputText);
    }
}
