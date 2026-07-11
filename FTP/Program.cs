using Kaven.Standard;

await Utility.StartConsoleApplication<AppFtpServer>(new()
{
    IoC = new IoC(),
});