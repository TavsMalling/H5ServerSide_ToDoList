namespace H5ServerSide_ToDoList.Codes.Services
{
    public interface IHashingService
    {
        dynamic MD5Hash(string inputText, ReturnType returnType);

        dynamic SHA2Hash(string inputText, ReturnType returnType);

        dynamic HMACHash(string inputText, ReturnType returnType);

        dynamic PBKDF2Hash(string texinputTexttToHash, ReturnType returnType);

        dynamic BCryptHash(string inputText, ReturnType returnType);

        bool BCryptHashValidate(string inputText, string hashedValue);
    }
}
