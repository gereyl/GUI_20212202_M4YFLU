using Game.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Logic
{
    public class MerlegLogic : IMerlegModel
    {
        public event EventHandler GameOver;
        public event EventHandler Changed;
        public event EventHandler Win;
        System.Windows.Size area;
        public HealthPoint hp;
        public Score score = new Score();
        double x;
        double y;
        Random rnd = new Random();
        public int[] shuffled = new int[9];
        public int[] values { get; set; }

        int futasszam;

        public MerlegLogic()
        {

        }

        public MerlegLogic(HealthPoint hp)
        {
            this.hp = hp;
            score.Reset();
            //this.result = rnd.Next(5, 15);
        }


        int FutasszamErtekadas()
        {
            if (futasszam.ToString() != null)
            {
                futasszam = 0;
            }
            else
            {
                futasszam++;
            }
            return futasszam;
        }

        public int[] correctAnswer()
        {
            values = new int[9] {0, 1, 2, 3, 4, 5, 6, 7, 8 };

            shuffled = values.OrderBy(a => rnd.Next()).ToArray();
           // shuffled = values;
            return shuffled;
        }

        public int correct(int szam)
        {
            if (szam == 0) //ant
            {
                return 1;
            }
            else if (szam == 1 || szam == 6) //cat
            {
                return 2;
            }
            else if (szam == 2 || szam == 4 || szam == 7) //dog, puppy
            {
                return 4;
            }
            else // pig
            {
                return 3;
            }
        }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;

        }

        public void SetUpCoordinates(int[] corr, double x, double y)
        {
            shuffled = corr;
            this.x = x;
            this.y = y;

            GameOn();

        }

        public bool GameOn()
        {
            return Ellenorzes(x, y);
        }

        public bool Ellenorzes(double x, double y)
        {
            double magassag = area.Height / 8 * 6;
            int chosen = 0;

            if (x - (area.Width / 5 - 100) < 200 && y - magassag < 150 && x < area.Width - 200)
            {
                chosen = 1;
            }
            else if (x - (area.Width / 5 * 2 - 100) < 200 && y - magassag < 150 && x < area.Width - 200)
            {
                chosen = 2;
            }
            else if (x - (area.Width / 5 * 3 - 100) < 200 && y - magassag < 150 && x < area.Width - 200)
            {
                chosen = 3;
            }
            else if (x - (area.Width / 5 * 4 - 100) < 200 && y - magassag < 150 && x < area.Width - 200)
            {
                chosen = 4;
            }


            if (correct(shuffled[futasszam]) == chosen)
            {
                futasszam++;
                score.ScorePoint++;
                Changed.Invoke(this, null);
                if (score.ScorePoint == 1)
                {
                    Win.Invoke(this, null);
                }
                return true;
            }
            else
            {
                futasszam++;
                hp.Hp--;
                if (hp.Hp > 0)
                {

                    Changed.Invoke(this, null);
                }
                if (hp.Hp <= 0)
                {
                    GameOver.Invoke(this, null);
                }

                return false;
            }


        }

        public int Futas()
        {
            return FutasszamErtekadas();
        }

    }

}