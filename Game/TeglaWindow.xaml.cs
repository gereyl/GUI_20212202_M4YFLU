using Game.Logic;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game
{
    /// <summary>
    /// Interaction logic for TeglaWindow.xaml
    /// </summary>
    public partial class TeglaWindow : Window
    {
        TeglaLogic logic;
        ViragLogic logic2;
        DispatcherTimer timer;
        TimeSpan time;
        public TeglaWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = time.ToString("g");
                if (time == TimeSpan.Zero)
                {
                    timer.Stop();
                    //MessageBox.Show("Lejárt az időd!");
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /* logic = new TeglaLogic();
             logic.GameOver += Logic_GameOver;
             tegladisplay.SetupModel(logic);
             tegladisplay.SetupSizes(new Size(grid2.ActualWidth, grid2.ActualHeight));
             logic.SetupSizes(new System.Windows.Size((int)grid2.ActualWidth, (int)grid2.ActualHeight));
             tbHP.Text = ("Maradék élet: " + logic2.hp.Hp);
             tbScore.Text = ("Pontjaid: " + logic2.score.ScorePoint + "/3");*/
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (logic != null)
            {
                //tegladisplay.SetupSizes(new Size(grid2.ActualWidth, grid2.ActualHeight));
                //logic.SetupSizes(new System.Windows.Size((int)grid2.ActualWidth, (int)grid2.ActualHeight));
            }
        }

        private void grid2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(Application.Current.MainWindow);
            double x = point.X;
            double y = point.Y;
            //int chosen = tegladisplay.rnd;

            //logic.SetUpCoordinates(chosen, x, y);

            tbHP.Text = ("Maradék élet: " + logic2.hp.Hp);
            tbScore.Text = ("Pontjaid: " + logic2.score.ScorePoint + "/3");
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;
        }
    }
}
