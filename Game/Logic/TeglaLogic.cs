using Game.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Game.Logic
{
    //max 15
    
    public class TeglaLogic : ITeglaModel
    {
        public event EventHandler GameOver;
        public event EventHandler Changed;
        public event EventHandler NextLevel;
        double x;
        double y;
        System.Windows.Size area;
        public HealthPoint hp;
        public Score score = new Score();
        Random rnd = new Random();
        public int[] values { get; set; }
        public int result;
        public int[] shuffled = new int[7];
        public int actual = 16;

        public int[] correctAnswer()
        {
            values = new int[7] { 1,1,2,2,3,3,4};
            
            shuffled = values.OrderBy(a => rnd.Next()).ToArray();
            return shuffled;
        }

        public TeglaLogic()
        {

        }
        public TeglaLogic(HealthPoint hp)
        {
            this.hp = hp;
            score.Reset();
            this.result = rnd.Next(5, 15);
        }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;

        }

        public void SetUpCoordinates(int[] corr,double x, double y)
        {
            shuffled = corr; 
            this.x = x;
            this.y = y;

            GameOn();

        }

        public bool Ellenorzes(double x, double y)
        {
                double szelesseg = area.Width / 2;

                if (y-(area.Height-150) < 150 && x- szelesseg < 400  && y > area.Height-150)
                {
                    actual = actual - shuffled[0];
                }
                else if (y - (area.Height - 300) < 150 && x - szelesseg < 400  && y > area.Height - 300)
                {
                    actual = actual - shuffled[1];
                }
                else if (y - (area.Height - 450) < 150 && x - szelesseg < 400  && y > area.Height - 450)
                {
                    actual = actual - shuffled[2];
                }
                else if (y - (area.Height - 600) < 150 && x - szelesseg < 400  && y > area.Height - 600)
                {
                    actual = actual - shuffled[3];
                }
                else if (y - (area.Height - 750) < 150 && x - szelesseg < 400 &&  y > area.Height - 750)
                {
                    actual = actual - shuffled[4];
                }
                else if (y - (area.Height - 900) < 150 && x - szelesseg < 400  && y > area.Height - 900)
                {
                    actual = actual - shuffled[5];
                }
                else if (y - (area.Height - 1050) < 150 && x - szelesseg < 400  && y > area.Height - 1050)
                {
                    actual = actual - shuffled[6];
                }

            if (actual == result)
            {
                score.ScorePoint++;
                actual = 16;
                result = rnd.Next(5, 15);
                if (score.ScorePoint == 6)
                {
                    //NextLevel.Invoke(this, null);
                }
                return true;
            }
            else if(actual < result)
            {
                hp.Hp--;
                if (hp.Hp>0)
                {
                    actual = 16;
                    result = rnd.Next(5, 15);
                    Changed.Invoke(this, null);
                }
                if (hp.Hp <= 0)
                {
                    GameOver.Invoke(this, null);
                }
            }
            return false;



        }

        public bool GameOn()
        {
           return Ellenorzes(x, y);
        }


    }
}
