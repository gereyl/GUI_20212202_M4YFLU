using System;
using System.Windows;

namespace Game.Logic
{
    public interface IGameModel
    {
        event EventHandler GameOver;
        event EventHandler Changed;
        public Rect correct { get; set; }
        public void SetUpRect(Rect rect);
        public bool Correct(Rect rect, double x, double y);
    }
}