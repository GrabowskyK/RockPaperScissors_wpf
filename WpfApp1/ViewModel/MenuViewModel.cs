using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.View;
using WpfApp1.ViewModel.BaseClass;

namespace WpfApp1.ViewModel
{
    class MenuViewModel : BaseViewModel
    {
        private object currentView;

        public MenuViewModel()
        {
            ChangeViewToComputerVsComputer = new RelayCommand(changeViewToComputer);
            ChangeViewToPlayerVsComputer = new RelayCommand(changeViewToPlayer);
        }



        public ICommand ChangeViewToComputerVsComputer { get; set; }
        public ICommand ChangeViewToPlayerVsComputer { get; set; }

        public void changeViewToComputer(object obj)
        {
            CurrentView = new HomeView();
            OnPropertyChanged(nameof(CurrentView));
        }

        public void changeViewToPlayer(object obj)
        {
            CurrentView = new GameView();
            OnPropertyChanged(nameof(CurrentView));
        }


        public object CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

