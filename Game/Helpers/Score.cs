using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Helpers
{
    public class Score
    {

        public int ScorePoint { get; set; }

        public Score()
        {
            ScorePoint = 0;
        }

        public void Reset()
        {
            this.ScorePoint = 0;
        }
    }
}
