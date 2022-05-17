﻿using Game.Logic;
using System;
using System.Collections.Generic;
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

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViragLogic logic;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new ViragLogic();
            logic.GameOver += Logic_GameOver;
            viragosdisplay.SetupModel(logic);
            viragosdisplay.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.SetupSizes(new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
        }

        private void Logic_GameOver(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Game Over");
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (logic != null)
            {
                viragosdisplay.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
                logic.SetupSizes(new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            }
        }

        private void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.OriginalSource is Rect)
            //{

            //double x = e.GetPosition((IInputElement)sender).X;
            //double y = e.GetPosition((IInputElement)sender).Y;
            //MessageBox.Show(string.Format("X: {0} Y: {1}",x.ToString(),y.ToString()));

            var point = Mouse.GetPosition(Application.Current.MainWindow);
            double x = point.X;
            double y = point.Y;

            logic.SetUpCoordinates(x, y);

            logic.GameOn();

                
            //}
        }

       

    }
}
