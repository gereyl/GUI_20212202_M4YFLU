using System;
using System.Windows;

namespace Game.Logic
{
    public interface IGameModel
    {
        event EventHandler GameOver;
        event EventHandler Changed;
        public int correctAnswer { get; set; }
        public Rect correct { get; set; }
        public void SetUpRect(Rect rect);
        public bool Correct(int chosen, double x, double y);

        public int CorrectAnswer();
    }
}