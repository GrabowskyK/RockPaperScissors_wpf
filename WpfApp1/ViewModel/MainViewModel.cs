﻿using System;
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
    public class ChangeViewEventArgs : EventArgs
    {
        public UserControl NewView { get; }

        public ChangeViewEventArgs(UserControl newView)
        {
            NewView = newView;
        }
    }

    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {



    private object currentView;
        public MainViewModel()
        {
            CurrentView = new MenuView();
           // currentView = new GameView();
           
        }
        private UserControl _currentViewTest;
        public UserControl CurrentViewTest
        {
            get { return _currentViewTest; }
            set
            {
                _currentViewTest = value;
                OnPropertyChanged(nameof(CurrentView));
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

        private void OnCurrentViewChanged(object newView)
        {
            CurrentView = newView;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}


