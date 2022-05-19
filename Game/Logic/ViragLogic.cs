using Game.Helpers;
using Game.Renderer;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Logic
{
    internal class ViragLogic : IGameModel
    {
        public event EventHandler GameOver;
        public event EventHandler Changed;
        System.Windows.Size area;
        //static Random r;
        double x;
        double y;
        public HealthPoint hp = new HealthPoint();
        public int correctAnswer { get; set; }






        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;

        }

        public void SetUpRect(Rect rect)
        {
            this.correct = rect;
        }
        public Rect correct { get; set; }





        public void SetUpCoordinates(int chosen, double x, double y)
        {
            correctAnswer = chosen;
            this.x = x;
            this.y = y;
            GameOn();
        }

        public int CorrectAnswer()
        {
            Random r = new Random();
            correctAnswer = r.Next(0, 4);
            return correctAnswer;
        }


        public bool Correct(int chosen, double x, double y)
        {
            chosen = correctAnswer;
            double correctX = 0;
            double correctY = area.Height / 8;
            if (chosen == 0)
            {
                correctX = area.Width / 5;
            }
            if (chosen == 1)
            {
                correctX = (area.Width / 5) * 2;
            }
            if (chosen == 2)
            {
                correctX = (area.Width / 5) * 3;
            }
            if (chosen == 3)
            {
                correctX = (area.Width / 5) * 4;
            }

            if ((x - correctX) < 100 && (y - correctY) < 100 && x > correctX && y > correctY)
            {
                MessageBox.Show("anyad");
                return true;

            }
            else
            {
                MessageBox.Show("rossz");
                hp.Hp--;
                if (hp.Hp <= 0)
                {
                    GameOver.Invoke(this, null);
                }
                return false;

            }
        }



        public void GameOn()
        {
            Correct(correctAnswer, x, y);


            
        }



        






    }
}
