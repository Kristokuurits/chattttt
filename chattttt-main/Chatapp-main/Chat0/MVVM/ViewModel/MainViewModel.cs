using ChatApp.MVVM.Model;
using ChatClient.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace Chat0.MVVM.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<Model> Users { get; set; }
        public ObservableCollection<string> Messages { get; set; }

        public string Username { get; set; }
        public string Message { get; set; }
        private Server _server;

        public MainViewModel(string Username)
        {
            Users = new ObservableCollection<Model>();
            Messages = new ObservableCollection<string>();
            _server = new Server();
            _server.connectedEvent += UserConnected;
            _server.msgReceivedEvent += MessageReceived;
            _server.userDisconnectedEvent += RemoveUser;
            _server.ConnectToServer(Username);
        }

        public void SendMessage(string Message)
        {
            _server.SendMessageToServer(Message);
        }

        private void MessageReceived()
        {
            var msg = _server.PacketReader.ReadMessage();
            Messages.Add(msg);
            Console.WriteLine(msg);
        }


        private void UserConnected()
        {
            var user = new Model
            {
                Username = _server.PacketReader.ReadMessage(),
                UID = _server.PacketReader.ReadMessage()
            };

            if (!Users.Any(x => x.UID == user.UID))
            {
               Users.Add(user);
            }
        }

        private void RemoveUser()
        {
            var uid = _server.PacketReader.ReadMessage();
            var user = Users.Where(x => x.UID == uid).FirstOrDefault();
            Users.Remove(user);
        }

    }
}
