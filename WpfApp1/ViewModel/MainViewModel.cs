using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.View;
using WpfApp1.ViewModel.BaseClass;

namespace WpfApp1.ViewModel
{
    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private object currentView;
        public MainViewModel()
        {
            currentView = new GameView();
            changeView = new RelayCommand(changeViewFunc);
        }

        public ICommand changeView { get; set; }

        public void changeViewFunc(object obj)
        {
            CurrentView = new HomeView();
        }
        private bool y = false;

        public object CurrentView {
            get
            {
                return currentView;
            }
            set
            {
                if (y == false)
                {
                    currentView = new HomeView();
                    y = true;
                }
                else
                {
                    currentView = new GameView();
                    this.y = false;
                }
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


