﻿using EasySave.NS_ViewModel;
using EasySave.Observable;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasySave.NS_View
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : Page
    {
        // ----- Attributes -----
        private MenuViewModel menuViewModel { get; set; }
        public MainWindow mainWindow { get; set; }


        // ----- Constructor -----
        public MenuView(MenuViewModel _menuViewModel, MainWindow _mainWindow)
        {
            // Initaialize Page content
            this.menuViewModel = _menuViewModel;
            this.mainWindow = _mainWindow;
            DataContext = this.menuViewModel;
            InitializeComponent();
        }


        // ----- Methods
        private void Remove_Clicked(object sender, RoutedEventArgs e)
        {
            int[] SelectedWorks = GetSelectedWorks();

            // Remove Selected Works
            menuViewModel.RemoveWorks(SelectedWorks);
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            if (GetSelectedWorks().Length > 0)
            {
                foreach (int indexWork in GetSelectedWorks())
                {
                    switch (this.menuViewModel.model.works[indexWork].colorProgressBar)
                    {
                        case "White":
                            this.menuViewModel.UpdateWorkColor(indexWork, "Green");
                            this.menuViewModel.LaunchBackupWork(indexWork);
                            _listWorks.Items.Refresh();
                            break;

                        case "Orange":
                            this.menuViewModel.UpdateWorkColor(indexWork, "Green");
                            break;

                        default:
                            break;
                    }
                }
            }
            else
            {
                // Call Error Message if no Works Selected
                this.menuViewModel.model.errorMsg?.Invoke("noSelectedWork");
            }
        }

        private int[] GetSelectedWorks()
        {
            int nbrTotalWorks = _listWorks.SelectedItems.Count;
            int[] SelectedWorks = new int[nbrTotalWorks];

            // Get Works's Index from Selected Items
            for (int i = 0; i < nbrTotalWorks; i++)
            {
                SelectedWorks[i] = _listWorks.Items.IndexOf(_listWorks.SelectedItems[i]);
            }
            return SelectedWorks;
        }

        private void SelectAll_Clicked(object sender, RoutedEventArgs e)
        {
            // Select All or Unselect All If there are All Alerady Selected
            if (_listWorks.SelectedItems.Count != menuViewModel.model.works.Count)
            {
                _listWorks.SelectAll();
            }
            else
            {
                _listWorks.UnselectAll();
            }
        }

        private void ChangePage(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            this.mainWindow.ChangePage(button.Tag.ToString());
        }

        private void CancelBackup_Clicked(object sender, RoutedEventArgs e)
        {
            foreach (int indexWork in GetSelectedWorks())
            {
                this.menuViewModel.UpdateWorkColor(indexWork, "White");
                _listWorks.Items.Refresh();
            }
            
        }

        private void PauseBackup_Clicked(object sender, RoutedEventArgs e)
        {
            foreach (int indexWork in GetSelectedWorks())
            {
                // Check if backup is running
                if (this.menuViewModel.model.works[indexWork].colorProgressBar == "Green")
                {
                    this.menuViewModel.UpdateWorkColor(indexWork, "Orange");
                }
            }
        }
    }
}
