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

    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private bool visablePlayerButton;
        private bool visableCompButton;
        private object currentView;
        public MainViewModel()
        {
            CurrentView = new CompVsCompView();
            ComputerVsComputerView = new RelayCommand(CompVsComp);
            PlayerVsComputerView = new RelayCommand(PlayerVsComp);
            VisablePlayerButton = true;
            VisableCompButton = false;


        }
        
         public ICommand ComputerVsComputerView { get; set; }
         public ICommand PlayerVsComputerView { get; set; }

        public void CompVsComp(object obj)
        {
            CurrentView = new CompVsCompView();
            VisableCompButton = false;
            VisablePlayerButton = true;
        }

        public void PlayerVsComp(object obj)
        {
            CurrentView = new PlayerVsCompView(); 
            VisablePlayerButton = false;
            VisableCompButton = true;
        }

        public bool VisablePlayerButton
        {
            get
            {
                return visablePlayerButton;
            }
            set
            {
                visablePlayerButton = value;
                OnPropertyChanged(nameof(VisablePlayerButton));
            }
        }

        public bool VisableCompButton
        {
            get
            {
                return visableCompButton;
            }
            set
            {
                visableCompButton = value;
                OnPropertyChanged(nameof(VisableCompButton));
            }
        }

        public object CurrentView {
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


