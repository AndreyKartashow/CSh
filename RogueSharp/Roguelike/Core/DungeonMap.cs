using RLNET;
using RogueSharp;
using RogueSharpV3Tutorial;
using System.Collections.Generic;
using System.Linq;

namespace Roguelike.Core
{
    // Наш собственный класс DungeonMap расширяет базовый класс RogueSharp Map.
    public class DungeonMap : Map
    {
        // Создаем список комнат, дверей и монстров
        private readonly List<Monster> _monsters;
        public List<Rectangle> Rooms { get; set; }
        public List<Door> Doors { get; set; }
        public Stairs StairsUp { get; set; }
        public Stairs StairsDown { get; set; }

        public DungeonMap()
        {
            // Очистка событий при переходе на новую карту
            Game.SchedulingSystem.Clear();
            // Инициализируем список комнат и монстров при создании новой карты подземелья
            _monsters = new List<Monster>();
            Rooms = new List<Rectangle>();
            Doors = new List<Door>();
        }

        // Метод Draw (рисование) будет вызываться каждый раз при обновлении карты
        // Он отобразит все символы/цвета для каждой ячейки в консоли карты
        public void Draw(RLConsole mapConsole, RLConsole statConsole)
        {
            foreach (Cell cell in GetAllCells())
            {
                SetConsoleSymbvolForCell(mapConsole, cell);
            }
            // Рисуем двери
            foreach (Door door in Doors)
            {
                door.Draw(mapConsole, this);
            }
            // Прорисовка подземелий (переход на другие карты по лестнице)
            StairsUp.Draw(mapConsole, this);
            StairsDown.Draw(mapConsole, this);
            // Перебираем всех монстров из коллекции и отрисовываем их на карте
            int i = 0;
            foreach (Monster monster in _monsters)
            {
                monster.Draw(mapConsole, this);
                // Прорисовка статистики монстра при нахождении его в поле видимости
                if (IsInFov(monster.X, monster.Y))
                {
                    // Передаем индекс в DrawStats, а затем увеличиваем его
                    monster.DrawStats(statConsole, i);
                    i++;
                }
            } 
        }

        // Вызывается MapGenerator после того, как мы создадим новую карту, чтобы добавить игрока на карту
        public void AddPlayer(Player player)
        {
            Game.Player = player;
            SetIsWalkable(player.X, player.Y, false);
            UpdatePlayerFieldOfView();
            Game.SchedulingSystem.Add(player);
        }

        private void SetConsoleSymbvolForCell(RLConsole console, Cell cell)
        {
            // Когда мы еще не исследовали ячейку, мы не хотим ничего рисовать
            if (!cell.IsExplored)
            {
                return;
            }
            // Когда ячейка в данный момент находится в поле зрения, она должна быть окрашена более светлым цветом
            if (IsInFov(cell.X, cell.Y))
            {
                // Выбираем символ для рисования в зависимости от того, проходима ячейка или нет
                // '.'  для пола и '#' для стен
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBackgroundFov, '#');
                }
            }
            // Когда ячейка находится вне поля зрения, рисуем ее более темными цветами
            else
            {
                if (cell.IsWalkable)
                {
                    console.Set(cell.X, cell.Y, Colors.Floor, Colors.FloorBackground, '.');
                }
                else
                {
                    console.Set(cell.X, cell.Y, Colors.Wall, Colors.WallBackground, '#');
                }
            }
        }

        // Этот метод будет вызываться всякий раз, когда мы перемещаем игрока для обновления поля зрения
        public void UpdatePlayerFieldOfView()
        {
            Player player = Game.Player;
            // Вычисляем поле зрения на основе местоположения и осведомленности игрока
            ComputeFov(player.X, player.Y, player.Awareness, true);
            // Отмечаем все ячейки в поле зрения как исследованные
            foreach (Cell cell in GetAllCells())
            {
                if (IsInFov(cell.X, cell.Y))
                {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }

        // Возвращает true, если можно поместить Актера в ячейку, или false в противном случае.
        public bool SetActorPosition(Actor actor, int x, int y)
        {
            // Разрешить размещение актера только в том случае, если ячейка доступна для ходьбы
            if (GetCell(x, y).IsWalkable)
            {
                // Ячейка, в которой ранее находился актер, теперь доступна для ходьбы
                SetIsWalkable(actor.X, actor.Y, true);
                // Обновить позицию актера
                actor.X = x;
                actor.Y = y;
                // Новая ячейка, в которой находится актер, теперь недоступна для ходьбы
                SetIsWalkable(actor.X, actor.Y, false);
                OpenDoor(actor, x, y);
                // Не забудьте обновить поле зрения, если мы только что изменили положение игрока
                if (actor is Player)
                {
                    UpdatePlayerFieldOfView();
                }
                return true;
            }
            return false;
        }

        // Вспомогательный метод для установки свойства IsWalkable в ячейке
        public void SetIsWalkable(int x, int y, bool isWalkable)
        {
            Cell cell = (Cell)GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }

        public void AddMonster(Monster monster)
        {
            _monsters.Add(monster);
            // После добавления монстра на карте, ячейка не доступна для ходьбы
            SetIsWalkable(monster.X, monster.Y, false);
            Game.SchedulingSystem.Add(monster);
        }

        public void RemoveMonster(Monster monster)
        {
            _monsters.Remove(monster);
            // после удаления монтстра с карты, ячейка должна стать свободной
            SetIsWalkable(monster.X, monster.Y, true);
            Game.SchedulingSystem.Remove(monster);
        }

        public Monster GetMonsterAt(int x, int y)
        {
            return _monsters.FirstOrDefault(m => m.X == x && m.Y == y);
        }

        // Ищем случайное место в комнате, по которому можно пройти
        public Point GetRandonWalkableLocationInRoom(Rectangle room)
        {
            if (DoesRoomHaveWalkableSpace(room))
            {
                for (int i = 0; i < 100; i++)
                {
                    int x = Game.Random.Next(1, room.Width - 2) + room.X;
                    int y = Game.Random.Next(1, room.Height - 2) + room.Y;
                    if (IsWalkable(x, y))
                    {
                        return new Point(x, y);
                    }
                }
            }
            // Если мы не нашли проходного места, возвращаем null
            return null;
        }

        // Итерируем все ячейки и возвращаем истину, если можно пройтись
        public bool DoesRoomHaveWalkableSpace(Rectangle room)
        {
            for (int x = 1; x <= room.Width - 2; x++)
            {
                for (int y = 1; y <= room.Height - 2; y++)
                {
                    if (IsWalkable(x + room.X, y + room.Y))
                    {
                        return true;
                    }    
                }
            }
        return false;
        }

        // Возвращаем дверь в позиции x,y или null, если она не найдена.
        public Door GetDoor(int x, int y)
        {
            return Doors.SingleOrDefault(d => d.X == x && d.Y == y);
        }

        // Актер открывает дверь, расположенную в позиции x,y
        private void OpenDoor(Actor actor, int x, int y)
        {
            Door door = GetDoor(x, y);
            if (door != null && !door.IsOpen)
            {
                door.IsOpen = true;
                var cell = GetCell(x, y);
                // Как только дверь открыта, она должна быть помечена как прозрачная и больше не блокировать поле зрения
                SetCellProperties(x, y, true, cell.IsWalkable, cell.IsExplored);

                Game.MessageLog.Add($"{actor.Name} opened a door");
            }
        }

        // Метод проверки положения игрока на лестнице
        public bool CanMoveDownToNextLevel()
        {
            Player player = Game.Player;
            return StairsDown.X == player.X && StairsDown.Y == player.Y;
        }
    }
}
