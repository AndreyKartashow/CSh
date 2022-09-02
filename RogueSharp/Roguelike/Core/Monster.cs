using RLNET;
using Roguelike.Behavoir;
using Roguelike.Systems;
using System;

namespace Roguelike.Core
{
    public class Monster : Actor
    {
        public int? TurnsAlerted { get; set; }
        
        public void DrawStats(RLConsole statConsole, int position)
        {
            // Начать с Y=13, что ниже статистики игрока.
            // Умножаем позицию на 2, чтобы оставить пробел между каждой статистикой
            int yPosition = 13 + (position * 2);

            statConsole.Print(1, yPosition, Symbvol.ToString(), Color);

            // Определить ширину полосы здоровья, разделив текущее здоровье на максимальное здоровье
            int width = Convert.ToInt32(((double)Health / (double)MaxHealth) * 16.0);
            int remainingWidth = 16 - width;

            statConsole.SetBackColor(3, yPosition, width, 1, Swatch.Primary);
            statConsole.SetBackColor(3 + width, yPosition, remainingWidth, 1, Swatch.PrimaryDarkest);

            statConsole.Print(2, yPosition, $": {Name}", Swatch.DbLight);

        }

        public virtual void PerformAction(CommandSystem commandSystem)
        {
            var behavior = new StandartMoveAndAttack();
            behavior.Act(this, commandSystem);
        }
    }
}
