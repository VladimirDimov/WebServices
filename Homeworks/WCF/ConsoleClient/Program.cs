namespace ConsoleClient
{
    using ConsoleClient.DayOfWeekServiceReference;
    using System;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var client = new DayOfWeekServiceClient();

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("DayOfWeek/Today => {0}", client.Today());
        }
    }
}
