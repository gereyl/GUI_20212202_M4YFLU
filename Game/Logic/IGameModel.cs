using System;
using System.Windows;

namespace Game.Logic
{
    internal interface IGameModel
    {
        event EventHandler GameOver;
        event EventHandler Changed;
        Rect correct { get; set; }
    }
}