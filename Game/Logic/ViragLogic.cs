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

        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
            
        }

        public Rect correct { get; set; }


    }
}
