using Business.Constants;
using System;

namespace Business.CCS
{
    public class DataBaseLogger : ILogger //Logları dosyaya alıyorum.
    {
        public void Log()
        {
            Console.WriteLine(Messages.LoggedInDatabase);
        }
    }
}
