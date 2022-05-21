using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game.Logic
{
    public interface ITeglaModel
    {
        event EventHandler GameOver;
        event EventHandler Changed;
        List<Brush> brickBrushes { get; set; }


    }
}
