using Roguelike.Core;
using RogueSharp.DiceNotation;
using RogueSharpV3Tutorial;
using System.Text;
using Roguelike.Interfaces;
using RogueSharp;

namespace Roguelike.Systems
{
    public class CommandSystem
    {      
        // Возвращаемое значение истинно, если игрок мог двигаться
        // false, когда игрок не может двигаться, например, пытается врезаться в стену
        public bool MovePlayer(Direction direction)
        {
            int x = Game.Player.X;
            int y = Game.Player.Y;

            switch (direction)
            {
                case Direction.Up:
                    {
                        y = Game.Player.Y - 1;
                        break;
                    }
                case Direction.Down:
                    {
                        y= Game.Player.Y + 1;
                        break;
                    }
                case Direction.Left:
                    {
                        x = Game.Player.X - 1;
                        break;
                    }
                case Direction.Right:
                    {
                        x = Game.Player.X + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }
            if (Game.DungeonMap.SetActorPosition(Game.Player, x, y))
            {
                return true;
            }
            Monster monster = Game.DungeonMap.GetMonsterAt(x, y);
            if (monster != null)
            {
                Attack(Game.Player, monster);
                return true;
            }
            return false;
        }

        public void Attack(Actor attacker, Actor defender)
        {
            StringBuilder attackMessage = new StringBuilder();
            StringBuilder deffenseMessage = new StringBuilder();

            int hits = ResolveAttack(attacker, defender, attackMessage);
            int blocks = ResolveDeffense(defender, hits, attackMessage, deffenseMessage);

            Game.MessageLog.Add(attackMessage.ToString());
            if (!string.IsNullOrWhiteSpace(deffenseMessage.ToString()))
            {
                Game.MessageLog.Add(deffenseMessage.ToString());
            }
            int damage = hits - blocks;
            ResolveDamage(defender, damage);
        }

        // Атакующий делает бросок, основываясь на своей статистике, чтобы увидеть, получает ли он какие-либо удары
        private static int ResolveAttack(Actor attacker, Actor defender, StringBuilder attackMessage)
        {
            int hits = 0;
            attackMessage.AppendFormat("{0} attacks {1} and rolls: ", attacker.Name, defender.Name);

            // Бросьте количество 100-гранных кубиков, равное значению атаки атакующего актера
            DiceExpression attackDice = new DiceExpression().Dice(attacker.Attack, 100);
            DiceResult attackResult = attackDice.Roll();

            // Посмотрите на номинал каждой кости, которая была брошена
            foreach (TermResult termResult in attackResult.Results)
            {
                attackMessage.Append(termResult.Value + ", ");
                // Сравните значение со 100 минус шанс атаки и добавьте удар, если он больше
                if (termResult.Value >= 100 - attacker.AttackChance)
                {
                    hits++;
                }
            }
            return hits;
        }

        // Атакующий делает бросок, основываясь на своей статистике, чтобы увидеть, получает ли он какие-либо удары
        private static int ResolveDeffense(Actor defender, int hits, StringBuilder attackMessage, StringBuilder deffenseMessage)
        {
            int blocks = 0;
            if (hits > 0)
            {
                attackMessage.AppendFormat("scoring {0} hits.", hits);
                deffenseMessage.AppendFormat(" {0} defends and rolls: ", defender.Name);

                // Бросьте количество 100-гранных кубиков, равное значению защиты защищающегося актера
                DiceExpression defenseDice = new DiceExpression().Dice(defender.Defense, 100);
                DiceResult defenseRoll = defenseDice.Roll();

                // Посмотрите на номинал каждой кости, которая была брошена
                foreach (TermResult termResult in defenseRoll.Results)
                {
                    deffenseMessage.Append(termResult.Value + ", ");
                    // Сравните значение со 100 минус шанс защиты и добавьте блок, если он больше
                    if (termResult.Value >= 100 - defender.DefenseChance)
                    {
                        blocks++;
                    }
                }
                deffenseMessage.AppendFormat("resulting in {0} blocks.", blocks);
            }
            else
            {
                attackMessage.Append("and misses completely.");
            }
            return blocks;
        }

        // Наносим любой незаблокированный урон защитнику
        private static void ResolveDamage(Actor defender, int damage)
        {
            if (damage > 0)
            {
                defender.Health = defender.Health - damage;
                Game.MessageLog.Add($" {defender.Name} was hit for {damage} damage");
                if (defender.Health <= 0)
                {
                    ResolveDeath(defender);
                }
            }
            else
            {
                Game.MessageLog.Add($" {defender.Name} blocked all damage");
            }
        }

        // Убираем защитника с карты и добавляем сообщения при смерти.
        private static void ResolveDeath(Actor defender)
        {
            if (defender is Player)
            {
                Game.MessageLog.Add($" {defender.Name} was killed, GAME OVER MAN!");
            }
            else if (defender is Monster)
            {
                Game.DungeonMap.RemoveMonster((Monster)defender);
                Game.MessageLog.Add($" {defender.Name} died and dropped {defender.Gold} gold");
            }
        }

        
        public bool IsPlayerTurn { get; set; }

        public void EndPlayerTurn()
        {
            IsPlayerTurn = false;
        }

        public void ActivateMonsters()
        {
            IScheduleable scheduleable = Game.SchedulingSystem.Get();
            if (scheduleable is Player)
            {
                IsPlayerTurn = true;
                Game.SchedulingSystem.Add(Game.Player);
            }
            else
            {
                Monster monster = scheduleable as Monster;

                if (monster != null)
                {
                    monster.PerformAction(this);
                    Game.SchedulingSystem.Add(monster);
                }
                ActivateMonsters();
            }
        }

        public void MoveMonster(Monster monster, Cell cell)
        {
            if (!Game.DungeonMap.SetActorPosition(monster, cell.X, cell.Y))
            {
                if (Game.Player.X == cell.X && Game.Player.Y == cell.Y)
                {
                    Attack(monster, Game.Player);
                }
            }
        }
    }
}
