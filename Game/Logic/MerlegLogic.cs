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
        public int[] shuffled = new int[7];
        public int[] values { get; set; }
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
            values = new int[9] { 1, 2,3,4,5,6,7,8,9 };

            shuffled = values.OrderBy(a => rnd.Next()).ToArray();
            return shuffled;
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
            return false;



        }
    }
}
