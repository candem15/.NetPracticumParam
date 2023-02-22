namespace Hafta4.Odev8.Services
{
    public class DBLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - " + message);
        }
    }
}
