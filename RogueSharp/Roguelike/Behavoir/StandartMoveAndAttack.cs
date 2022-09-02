using Roguelike.Core;
using Roguelike.Interfaces;
using Roguelike.Systems;
using RogueSharp;
using RogueSharpV3Tutorial;
using System.Linq;

namespace Roguelike.Behavoir
{
    public class StandartMoveAndAttack : IBehavior
    {
        public bool Act(Monster monster, CommandSystem commandSystem)
        {
            DungeonMap dungeonMap = Game.DungeonMap;
            Player player = Game.Player;
            FieldOfView monsterFov = new FieldOfView(dungeonMap);

            // Если монстр не был предупрежден, вычисляем поле зрения
            // Используйте значение Осведомленности монстра для расстояния в проверке поля зрения
            // Если игрок находится в поле зрения монстра, то предупреждаем его
            // Добавляем сообщение в MessageLog об этом предупрежденном статусе
            if (!monster.TurnsAlerted.HasValue)
            {
                monsterFov.ComputeFov(monster.X, monster.Y, monster.Awareness, true);
                if (monsterFov.IsInFov(player.X, player.Y))
                {
                    Game.MessageLog.Add($"{monster.Name} is eager to fight {player.Name}");
                    monster.TurnsAlerted = 1;
                }  
            }

            if (monster.TurnsAlerted.HasValue)
            {
                // Прежде чем мы найдем путь, убедитесь, что ячейки монстра и игрока доступны для ходьбы
                dungeonMap.SetIsWalkable(monster.X, monster.Y, true);
                dungeonMap.SetIsWalkable(player.X, player.Y, true);

                PathFinder pathFinder = new PathFinder(dungeonMap);
                Path path = null;

                try
                {
                    path = pathFinder.ShortestPath(
                        dungeonMap.GetCell(monster.X, monster.Y),
                        dungeonMap.GetCell(player.X, player.Y));
                }
                catch (PathNotFoundException)
                {
                    // Монстр видит игрока, но не может найти к нему путь
                    // Это может быть из-за того, что другие монстры блокируют путь
                    // Добавляем в журнал сообщений сообщение о том, что монстр ждет
                    Game.MessageLog.Add($"{monster.Name} waits for a turn");
                }

                // Не забудьте снова установить для статуса walkable значение false
                dungeonMap.SetIsWalkable(monster.X, monster.Y, false);
                dungeonMap.SetIsWalkable(player.X, player.Y, false);

                // В случае, если был путь, сообщаем CommandSystem переместить монстра
                if (path != null)
                {
                    try
                    {
                        // TODO: это должно быть path.StepForward(), но в RogueSharp V3 есть ошибка
                        // Ошибка в том, что путь, возвращаемый из Навигатора, не включает исходную ячейку
                        commandSystem.MoveMonster(monster, path.Steps.First());
                    }
                    catch (NoMoreStepsException)
                    {
                        Game.MessageLog.Add($"{monster.Name} growls in frustration");
                    }
                }
                monster.TurnsAlerted++;

                // Теряем статус предупреждений каждые 15 ходов.
                // Пока игрок находится в поле зрения, монстр будет оставаться начеку
                // Иначе монстр перестанет преследовать игрока
                if (monster.TurnsAlerted > 15)
                {
                    monster.TurnsAlerted = null;
                }
            }
            return true;
        }
    }
}
