using RLNET;

namespace Roguelike.Core
{
    public class Player : Actor
    {
        public Player()
        {
            Attack = 2;
            AttackChance = 50;
            Awareness = 15;
            Color = Colors.Player;
            Defense = 0;
            DefenseChance = 40;
            Gold = 0;
            Health = 100;
            MaxHealth = 100;
            Name = "Andrey";
            Speed = 10;
            Symbvol = '@';
            
            // Теперь игрок привязан к центру комнаты, а не к координатам
            // X = 10;
            // Y = 10;
        }
        public void DrawStats(RLConsole statConsole)
        {
            statConsole.Print(1, 1, $"Name: {Name}", Colors.Text);
            statConsole.Print(1, 3, $"Health: {Health}/{MaxHealth}", Colors.Text);
            statConsole.Print(1, 5, $"Attack: {Attack} ({AttackChance}%)", Colors.Text);
            statConsole.Print(1, 7, $"Defense: {Defense} ({DefenseChance}%)", Colors.Text);
        }
    }
}
