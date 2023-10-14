﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp1.ViewModel.BaseClass;

namespace WpfApp1.ViewModel
{
    class PlayerVsCompViewModel : INotifyPropertyChanged
    {
        private string player_A; //Znak gracza A
        private string player_B; 
        private int round = 0;  //Ilość rund
        private int player_A_int; // Wylosowana wartość znaku
        private int player_B_int;
        private string result;  //Kto wygrał daną runde
        private int player_A_points = 0; //Punkty
        private int player_B_points = 0;
        private string[] images = { @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\rockBigger.png", @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\paperBigger.png", @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\scissorsBigger.png" };
        private string player_A_Image; //Zdjęcie danego znaku dla gracza
        private string player_B_Image;

        private string visableChooseOption = "Visible"; //Widoczność batonów
        private string visibilityPlayAgain = "Hidden";
        public PlayerVsCompViewModel()
        {
            Play = new RelayCommand(PlayAgain); 
            ChooseOption = new RelayCommand(chooseOption);

            Player_A_image = @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\boy.png";
            Player_B_image = @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\boy.png";
        }
        public ICommand Play { get; set; } //Służy do ponownej gry
        public ICommand ChooseOption { get; set; } //Służy do wyboru znaku


    public void PlayAgain(object obj)
        {
            VisibilityChooseOption = "Visible";
            VisibilityPlayAgain = "Hidden";
            Result = "";
            Player_A_image = @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\boy.png";
            Player_B_image = @"G:\Studia\Grafika\RPS_Grabowski\WpfApp1\assets\boy.png";
        }
    public void StartGame()
        {
            //Kamien - 0
            //Papier - 1
            //Nozyce - 2
            Random rnd = new Random();
            player_B_int = rnd.Next(3);
            Player_A_image = images[player_A_int];
            Player_B_image = images[player_B_int];
            Player_A = WhatSign(player_A_int);
            Player_B = WhatSign(player_B_int);

            if (player_A_int == player_B_int)
            {
                Result = "Remis";
            }
            else if (player_A_int == 0 && player_B_int == 2 || player_A_int == 1 && player_B_int == 0 || player_A_int == 2 && player_B_int == 1)
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

            VisibilityPlayAgain = "Visible";
        }

        public void chooseOption(object obj)
        {
            player_A_int = Int32.Parse(obj.ToString());
            StartGame();
            VisibilityChooseOption = "Hidden";
        }

        private string WhatSign(int i) // Służy do wyświetlenia jaki znak wylosowało
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

        public string Result //Jaki gracz wygrał runde
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public int Round // Która runda
        {
            get { return round; }
            set
            {
                round = value;
                OnPropertyChanged(nameof(Round));
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

        public string Player_A_image //Obrazek dla danego wyboru
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
        

        public int Player_A_points //punkty dla gracza A
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

        public string Player_B
        {
            get { return player_B; }
            set
            {
                player_B = value;
                OnPropertyChanged(nameof(Player_B));
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

        public string VisibilityChooseOption
        {
            get
            {
                return visableChooseOption;
            }
            set
            {
                visableChooseOption = value;
                OnPropertyChanged(nameof(VisibilityChooseOption));
            }
        }
        public string VisibilityPlayAgain
        {
            get
            {
                return visibilityPlayAgain;
            }
            set
            {
                visibilityPlayAgain = value;
                OnPropertyChanged(nameof(VisibilityPlayAgain));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
