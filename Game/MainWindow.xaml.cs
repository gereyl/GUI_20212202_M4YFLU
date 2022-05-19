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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViragLogic logic;
        DispatcherTimer timer;
        TimeSpan time;
        public MainWindow()
        {
            InitializeComponent();

            time = new TimeSpan(150000000);

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = time.ToString("g");
                if (time == TimeSpan.Zero)
                {
                    timer.Stop();
                    //MessageBox.Show("Lejárt az időd!");
                    Logic_GameOver(this, null);

                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new ViragLogic();
            logic.GameOver += Logic_GameOver;
            logic.NextLevel += Logic_NextLevel;
            viragosdisplay.SetupModel(logic);
            viragosdisplay.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.SetupSizes(new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
            tbHP.Text = ("Maradék élet: " + logic.hp.Hp);
            tbScore.Text = ("Pontjaid: " + logic.score.ScorePoint + "/3");

        }

        private void Logic_NextLevel(object sender, EventArgs e)
        {
            timer.Stop();
            TeglaWindow win2 = new TeglaWindow();
            win2.Show();

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

            var point = Mouse.GetPosition(Application.Current.MainWindow);
            double x = point.X;
            double y = point.Y;
            int chosen = viragosdisplay.rnd;

            logic.SetUpCoordinates(chosen, x, y);

            tbHP.Text = ("Maradék élet: " + logic.hp.Hp);
            tbScore.Text = ("Pontjaid: " + logic.score.ScorePoint + "/3");
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;


        }



    }
}
