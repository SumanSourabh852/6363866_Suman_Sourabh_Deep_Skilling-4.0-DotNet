using System;

namespace SingletonPatternExample
{
    // Singleton Logger Class
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        // Private constructor
        private Logger()
        {
            Console.WriteLine("Logger initialized.");
        }

        // Public method to get the singleton instance
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        // Log method
        public void Log(string message)
        {
            Console.WriteLine($"[Log]: {message}");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            logger1.Log("First log message.");

            Logger logger2 = Logger.GetInstance();
            logger2.Log("Second log message.");

            if (logger1 == logger2)
            {
                Console.WriteLine("Logger is a Singleton. Both references point to the same instance.");
            }
            else
            {
                Console.WriteLine("Logger is NOT a Singleton. Different instances found.");
            }

            Console.ReadLine(); // Pause the console
        }
    }
}
