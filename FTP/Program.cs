using Kaven.Standard;

namespace FTP
{
    internal class Program
    {
        private static void Main()
        {
            Utility.StartConsoleApplication<AppFtpServer>(new()
            {
                IoC = new IoC(),
            });
        }
    }
}
