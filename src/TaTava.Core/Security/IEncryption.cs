namespace TaTava.Core.Security
{
    public interface IEncryption
    {
         string EncryptText(string text, string privateKey = "");
         string DecryptText(string text, string privateKey = "");

    }
}