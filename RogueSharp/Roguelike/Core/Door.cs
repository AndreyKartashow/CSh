using Roguelike.Interfaces;
using RLNET;
using RogueSharp;

namespace Roguelike.Core
{
    public class Door : IDrawable
    {
        public Door()
        {
            Symbvol = '+';
            Color = Colors.Door;
            BackroundColor = Colors.DoorBackground;
        }
        public bool IsOpen { get; set; }

        public RLColor Color { get; set; }
        public RLColor BackroundColor { get; set; }
        public char Symbvol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(RLConsole console, IMap map)
        {
            if (!map.GetCell(X, Y).IsExplored)
            {
                return;
            }
            Symbvol = IsOpen ? '-' : '+';
            if (map.IsInFov(X, Y))
            {
                Color = Colors.DoorFov;
                BackroundColor = Colors.DoorBackgroundFov;
            }
            else
            {
                Color = Colors.Door;
                BackroundColor = Colors.DoorBackground;
            }

            console.Set(X, Y, Color, BackroundColor, Symbvol);
        }
    }
}
