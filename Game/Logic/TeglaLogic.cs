using Game.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int result;

        public List<Brush> brickBrushes { get; set; }

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

        public void SetUpCoordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
            GameOn();
        }

        public void Ellenorzes(double x, double y)
        {
            ;
        }

        public void GameOn()
        {
            Ellenorzes(x, y);
        }


    }
}
