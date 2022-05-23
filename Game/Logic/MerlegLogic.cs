using Game.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Logic
{
    public class MerlegLogic : IMerlegModel
    {
        public event EventHandler GameOver;
        public event EventHandler Changed;
        System.Windows.Size area;
        public HealthPoint hp;
        public Score score = new Score();
        double x;
        double y;
        Random rnd = new Random();
        public MerlegLogic()
        {

        }

        public MerlegLogic(HealthPoint hp)
        {
            this.hp = hp;
            score.Reset();
            //this.result = rnd.Next(5, 15);
        }

        public int[] correctAnswer()
        {
            throw new NotImplementedException();
        }

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;

        }

        public void SetUpCoordinates(int[] corr, double x, double y)
        {
            //shuffled = corr;
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
            return false;



        }
    }
}
