using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Logic
{
    public interface IMerlegModel
    {
        event EventHandler GameOver;
        event EventHandler Changed;
        public int[] correctAnswer();
    }
}
