using MailSender.lib.Interfaces;
using MailSender.lib.Service;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IEncryptorService cryptor = new Rfc2898Encryptor();

            var str = "Hello World!";
            const string password = "MailSender!";

            var crypted_str = cryptor.Encrypt(str, password);

            var decrypted_str = cryptor.Decrypt(crypted_str, password);
        }
    }
}
