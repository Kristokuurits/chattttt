using Chat0.Net.IO;
using ChatClient.Net;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;
using Chat0.MVVM.ViewModel;

namespace Chat0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nimi: ");
            string name = Console.ReadLine();
            MainViewModel MainViewModel = new MainViewModel(name);

            while (true)
            {
                string message = Console.ReadLine();
                MainViewModel.SendMessage(message);
            }
        }
    }
}