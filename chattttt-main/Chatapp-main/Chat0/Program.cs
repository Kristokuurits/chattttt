using Chat0.Net.IO;
using ChatClient.Net;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;
using Chat0.MVVM.ViewModel;


class Program
{


    static void Main()
    {
        Console.WriteLine("Enter name NOWWWWW, to connect");
        var name = Console.ReadLine();
        var message = string.Empty;
        var input = new MainViewModel(name);


        while (true)
        {
            message = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(message))
            {
                input.SendMessage(message);
            }
            else
            {
                Console.WriteLine("Message cannot be empty.");
            }
        }



    }
}