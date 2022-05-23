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
    /// Interaction logic for MerlegWindow.xaml
    /// </summary>
    public partial class MerlegWindow : Window
    {
        MerlegLogic logic;
        public TeglaLogic logic2;
        DispatcherTimer timer;
        TimeSpan time;
        public MerlegWindow(TeglaLogic logic2)
        {
            time = new TimeSpan(1500000000);

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                //tbTime.Text = time.ToString("g");
                if (time == TimeSpan.Zero)
                {
                    timer.Stop();
                    //MessageBox.Show("Lejárt az időd!");
                    //Logic_GameOver(this, null);
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
            this.logic2 = logic2;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (logic != null)
            {
                merlegdisplay.SetupSizes(new Size(grid3.ActualWidth, grid3.ActualHeight));
                logic.SetupSizes(new System.Windows.Size((int)grid3.ActualWidth, (int)grid3.ActualHeight));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new MerlegLogic(logic2.hp);
            logic.GameOver += Logic_GameOver;
            logic.Changed += Logic_Changed;
            merlegdisplay.SetupModel(logic);
            merlegdisplay.SetupSizes(new Size(grid3.ActualWidth, grid3.ActualHeight));
            logic.SetupSizes(new System.Windows.Size((int)grid3.ActualWidth, (int)grid3.ActualHeight));
            tbHP.Text = ("Maradék élet: " + logic2.hp.Hp);
            tbScore.Text = ("Pontjaid: " + logic2.score.ScorePoint + "/6");
            //tbResult.Text = ("Elérendő összeg: " + logic.result.ToString());
            //tbResult.Margin = new Thickness(40, 40, 300, 70);
        }

        private void Logic_Changed(object sender, EventArgs e)
        {
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;
        }

        private void Logic_GameOver(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Game Over");
            if (result == MessageBoxResult.OK)
            {
                this.Close();

            }
        }

        //private void Logic_NextLevel(object sender, EventArgs e)
        //{
        //    //timer.Stop();
        //    //TeglaWindow win2 = new TeglaWindow(logic);
        //    //win2.Show();
        //    //this.Close();
        //}

        private void grid3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(Window.GetWindow(this));
            double x = point.X;
            double y = point.Y;
            //int[] corr = tegladisplay.corrects;

            /*logic.SetUpCoordinates(corr, x, y);
            tbResult.Text = ("Elérendő összeg: " + logic.result.ToString());
            tbHP.Text = ("Maradék élet: " + logic.hp.Hp);
            tbScore.Text = ("Pontjaid: " + logic.score.ScorePoint + "/6");
            actualScore.Text = ("Pontjaid: " + logic.actual);*/
        }
    }
}
