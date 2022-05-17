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
        double x;
        double y;
        

        

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
            
        }

        public void SetUpRect(Rect rect)
        {
            this.correct = rect;
        }
        public Rect correct { get; set; }

        



        public void SetUpCoordinates(double x,double y)
        {
            this.x = x;
            this.y = y;
        }


        public bool Correct(Rect rect, double x, double y)
        {
            double rectx = rect.X;
            double recty = rect.Y;

            if ((rectx - x) < 50 && (recty - y) < 50)
            {
                MessageBox.Show("anyad");
                return true;
                
            }
            else
            {
                MessageBox.Show("rossz");
                return false;
                
            }
        }

        
        
        public void GameOn()
        {
            int z = 0;
            
           if (Correct(correct, x, y))
           {
                    
           }
            
            //GameOver();
        }

        //public void GameOver()
        //{

        //}






    }
}
