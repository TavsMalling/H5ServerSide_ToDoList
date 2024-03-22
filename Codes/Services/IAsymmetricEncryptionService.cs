namespace H5ServerSide_ToDoList.Codes.Services
{
    public interface IAsymmetricEncryptionService
    {
        string EncryptAsymmetric(string inputText, string publicKey);

        string DecryptAsymmetric(string inputText, string privateKey);

        string _privateKey { get; }
        string _publicKey { get; }
    }
}
