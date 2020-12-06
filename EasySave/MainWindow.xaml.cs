﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySave.NS_View;
using EasySave.NS_ViewModel;
using EasySave.NS_Model;

namespace EasySave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ----- Attributes -----
        private MenuView menuView { get; set; }
        private AddWorkView addWorkView { get; set; }
        private SettingsView settingsView { get; set; }

        public MenuViewModel menuViewModel { get; set; }
        public AddWorkViewModel addWorkViewModel { get; set; }
        public SettingsViewModel settingsViewModel { get; set; }


        // ----- Constructor -----
        public MainWindow()
        {
            // Initialize Model
            Model model = new Model();

            // Initialize ViewModel
            this.menuViewModel = new MenuViewModel(model);
            this.addWorkViewModel = new AddWorkViewModel(model);
            this.settingsViewModel = new SettingsViewModel(model);

            // Set Main Window Datacontent
            menuView = new MenuView(menuViewModel, this);
            DataContext = menuView;

            // Load Language
            Langs.Lang.Culture = new CultureInfo("en-US");

            // Initialize Main Window
            InitializeComponent();
        }


        // ----- Methods -----
        // Change Main Window Content (Change Datacontent)
        public void ChangePage(string _route)
        {
            DataContext = null;

            switch (_route)
            {
                case "menu":
                    if (menuView == null)
                    {
                        menuView = new MenuView(menuViewModel, this);
                    }
                    DataContext = menuView;
                    return;

                case "addWork":
                    if (addWorkView == null)
                    {
                        addWorkView = new AddWorkView(addWorkViewModel, this);
                    }
                    DataContext = addWorkView;
                    return;

                case "settings":
                    if (settingsView == null)
                    {
                        settingsView = new SettingsView(settingsViewModel, this);
                    }
                    DataContext = settingsView;
                    return;
            }
        }
    }
}
