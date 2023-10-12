using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.ViewModel.BaseClass;

namespace WpfApp1.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        private string player_A;
        private string player_B;
        private int round = 0;
        private int player_A_int;
        private int player_B_int;
        
        private string result;
        private int player_A_points = 0;
        private int player_B_points = 0;
        private string[] images = { @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\rockBigger.png", @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\paperBigger.png", @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\scissorsBigger.png" };
        private string player_A_Image;
        private string player_B_Image;
        public GameViewModel()
        {
            Play = new RelayCommand(StartGame);
            Player_A_image = @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\boy.png";
            Player_B_image = @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\boy.png";

        } 
        public ICommand Play {  get; set; }

        public void StartGame(object obj)
        {
            //Kamien - 0
            //Papier - 1
            //Nozyce - 2
            Random rnd = new Random();
            player_A_int = rnd.Next(3);
            player_B_int = rnd.Next(3);
            Player_A_image = images[player_A_int];
            Player_B_image = images[player_B_int];
            Player_A = WhatSign(player_A_int);
            Player_B = WhatSign(player_B_int);

            if(player_A_int == player_B_int)
            {
                Result = "Remis";
            }
            else if(player_A_int == 0 && player_B_int == 2 || player_A_int == 1 && player_B_int == 0 || player_A_int == 2 && player_B_int == 1)
            {
                Result = "Wygrywa gracz A";
                Player_A_points += 1;
            }
            else
            {
                Result = "Wygrywa gracz B";
                Player_B_points += 1;
            }
            Round += 1;


        }

        private string WhatSign(int i) 
        {
            switch (i)
            {
                case 0:
                    return "Kamień";
                    break;
                case 1:
                    return "Papier";
                    break;
                case 2:
                    return "Nożyce";
                    break;
            }
            return "null";
        }
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public int Round
        {
            get { return round; }
            set
            {
                round = value;
                OnPropertyChanged(nameof(Round));
            }
        }
        public string Player_A_image
        {
            get
            {
                return player_A_Image;
            }
            set
            {
                player_A_Image = value;
                OnPropertyChanged(nameof(Player_A_image));
            }
        }
        public string Player_A 
        { 
            get { return player_A; } 
            set 
            { 
                player_A = value;
                OnPropertyChanged(nameof(Player_A));
            }
        }

        public int Player_A_points
        {
            get
            {
                return player_A_points;
            }
            set
            {
                player_A_points = value;
                OnPropertyChanged(nameof(Player_A_points));
            }
        }

        public int Player_B_points
        {
            get
            {
                return player_B_points;
            }
            set
            {
                player_B_points = value;
                OnPropertyChanged(nameof(Player_B_points));
            }
        }

        public string Player_B_image
        {
            get
            {
                return player_B_Image;
            }
            set
            {
                player_B_Image = value;
                OnPropertyChanged(nameof(Player_B_image));
            }
        }

        public string Player_B
        {
            get { return player_B; }
            set
            {
                player_B = value;
                OnPropertyChanged(nameof(Player_B));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
