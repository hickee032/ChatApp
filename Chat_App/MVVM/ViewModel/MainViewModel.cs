﻿using Chat_App.MVVM.Core;
using Chat_App.MVVM.Model;
using Chat_App.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chat_App.MVVM.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; }
        public RelayCommand ConnectToServerCommand { get; set; }

        public string Username { get; set; }
        public string Message { get; set; }

        private Server _server;

        public MainViewModel() {
            Users = new ObservableCollection<UserModel>();
            _server = new Server();
            _server.connectedEvent += UserConnected;
            ConnectToServerCommand = new RelayCommand(o => _server.ConnectToServer(Username), o => !string.IsNullOrEmpty(Username));
        }

        private void UserConnected() {

            var user = new UserModel {
                Username = _server.PacketReader.ReadMessage(),
                UID = _server.PacketReader.ReadMessage(),
            };

            if (!Users.Any(x => x.UID == user.UID)) {
                Application.Current.Dispatcher.Invoke(() => Users.Add(user));
            }
        }
    }
}
