using RabbitMQ.Client;
using System;
using System.Globalization;
using System.Text;

namespace consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("inserte una fecha");
            string date;
            date = Console.ReadLine();
            DateTime newDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            connection(newDate);
        }

        static public void connection(DateTime date)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("send-date", false, false, false, null);
                    var message = date.ToString("yyyyMMdd");
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "date", null, body);
                }
            }
        }
    }
}
