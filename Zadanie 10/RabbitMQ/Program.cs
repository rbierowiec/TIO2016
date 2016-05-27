using EasyNetQ;
using EasyNetQ.Management.Client;
using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class Program
    {
        private static long myID;
        private static String myNick;

        static void Main(string[] args)
        {
            String nickName;

            Console.Write("Podaj swój nick: ");
            nickName = Console.ReadLine().ToString();
            if (nickName == "") nickName = "Anonymous";

            myID = generateUniqueID();
            myNick = nickName;

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<Message>(myID.ToString(), HandleTextMessage);

                var input = "";
                Console.WriteLine("Dołączyłeś do czatu, wpisz wiadomość. Aby wyjść z czatu wpisz 'koniec'");
                while ((input = Console.ReadLine()) != "koniec")
                {

                    bus.Publish(
                        new Message
                        {
                            Name = nickName,
                            Text = input
                        });
                }
            }
        }

        static void HandleTextMessage(Message textMessage)
        {
            // Nie wyświetlaj moich własnych wiadomości
            if (textMessage.Name != myNick)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("<{0}> : <{1}>", textMessage.Name, textMessage.Text);
                Console.ResetColor();
            }
        }

        // Na podstawie aktualnych kolejek wygeneruj unikalne ID
        static long generateUniqueID()
        {
            List<long> queuesID = new List<long>();

            var managementClient = new ManagementClient("http://localhost", "admin", "admin");
            var queues = managementClient.GetQueues();

            foreach (var queue in queues) {
                String name = queue.Name.Replace("Library.Message:Library_", "");
                long value;
                if (Int64.TryParse(name, out value))
                {
                    queuesID.Add(value);
                }
            }

            return queuesID.Max() + 1;
        }
    }
}
