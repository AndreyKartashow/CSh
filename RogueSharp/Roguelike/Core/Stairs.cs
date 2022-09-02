using Roguelike.Interfaces;
using RLNET;
using RogueSharp;


namespace Roguelike.Core
{
    public class Stairs : IDrawable
    {
        public RLColor Color { get; set; }
        public char Symbvol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsUp { get; set; }
        public void Draw(RLConsole console, IMap map)
        {
            if (!map.GetCell(X, Y).IsExplored)
            {
                return;
            }
            Symbvol = IsUp ? '<' : '>';
            if (map.IsInFov(X, Y))
            {
                Color = Colors.Player;
            }
            else
            {
                Color= Colors.Floor;
            }
            console.Set(X, Y, Color, null, Symbvol);
        }
    }
}
