using Roguelike.Core;
using Roguelike.Monsters;
using RogueSharp;
using RogueSharp.DiceNotation;
using RogueSharpV3Tutorial;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Roguelike.Systems
{
    public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _maxRooms;
        private readonly int _roomMaxSize;
        private readonly int _roomMinSize;

        private readonly DungeonMap _map;

        // Для построения нового MapGenerator требуются размеры карт, которые он создаст
        public MapGenerator(int width, int height, int maxRooms, int roomMaxSize, int roomMinSize, int mapLevel)
        {
            _width = width;
            _height = height;
            _maxRooms = maxRooms;
            _roomMaxSize = roomMaxSize;
            _roomMinSize = roomMinSize;
            _map = new DungeonMap();
        }

        // Генерируем новую карту, которая представляет собой простой открытый пол со стенами снаружи
        public DungeonMap CreateMap()
        {
            // Инициализируем каждую ячейку на карте
            // устанавливаем для пешехода, прозрачности и исследования значение true 
            _map.Initialize(_width, _height);

            // Пытаемся разместить столько комнат, сколько указано maxRooms
            // Примечание: используется только убывающий цикл из-за форматирования WordPress
            for (int r = _maxRooms; r > 0; r--)
            {
                // Определяем размер и положение комнаты случайным образом
                int roomWidth = Game.Random.Next(_roomMinSize, _roomMaxSize);
                int roomHeight = Game.Random.Next(_roomMinSize, _roomMaxSize);
                int roomXPosition = Game.Random.Next(0, _width - roomWidth - 1);
                int roomYPosition = Game.Random.Next(0, _height - roomHeight - 1);

                // Все наши комнаты можно представить в виде прямоугольников
                var newRoom = new Rectangle(roomXPosition, roomYPosition, roomWidth, roomHeight);

                // Проверяем, пересекается ли прямоугольник комнаты с другими комнатами
                bool newRoomInrersects = _map.Rooms.Any(room => newRoom.Intersects(room));

                // Пока он не пересекается добавляем его в список комнат
                if (!newRoomInrersects)
                {
                    _map.Rooms.Add(newRoom);
                }
            }
            // Итерируем каждую комнату, которую мы хотели разместить
            // вызовите CreateRoom, чтобы сделать это
            foreach (Rectangle room in _map.Rooms)
            {
                CreateRoom(room);
                CreateDoors(room);
            }

            // Перебираем каждую сгенерированную комнату
            // Ничего не делаем с первой комнатой, поэтому начинаем с r = 1 вместо r = 0
            for (int r = 1; r < _map.Rooms.Count; r++)
            {
                // находим центры комнат для всех оставшихся (комната это одна из матриц в списке)
                int previosRoomCenterX = _map.Rooms[r - 1].Center.X;
                int previosRoomCenterY = _map.Rooms[r - 1].Center.Y;
                int currentRoomCenterX = _map.Rooms[r].Center.X;
                int currentRoomCenterY = _map.Rooms[r].Center.Y;

                // Даем шанс 50/50, какой L-образный соединительный коридор будет туннелем
                if (Game.Random.Next(1, 2) == 1)
                {
                    CreateHorizontalTunel(previosRoomCenterX, currentRoomCenterX, previosRoomCenterY);
                    CreateVerticaleTunel(previosRoomCenterY, currentRoomCenterY, currentRoomCenterX);
                }
                else
                {
                    CreateVerticaleTunel(previosRoomCenterY, currentRoomCenterY, currentRoomCenterX);
                    CreateHorizontalTunel(previosRoomCenterX, currentRoomCenterX, previosRoomCenterY);
                }
            }


            // Устанавливаем игрока в центре первой сгенерированной комнаты, лестницу и монстров
            CreateStairs();
            PlacePlayer();
            PlaceMonsters();

            return _map;
        }

        // Дана прямоугольная область на карте
        // устанавливаем свойства ячейки для этой области в true
        private void CreateRoom(Rectangle room)
        {
            for (int x = room.Left + 1; x < room.Right; x++)
            {
                for (int y = room.Top + 1; y < room.Bottom; y++)
                {
                    _map.SetCellProperties(x, y, true, true, true);
                }
            }
        }

        // Находим центр первой созданной нами комнаты и помещаем туда Player
        private void PlacePlayer()
        {
            Player player = Game.Player;
            if (player == null)
            {
                player = new Player();
            }
            player.X = _map.Rooms[0].Center.X;
            player.Y = _map.Rooms[0].Center.Y;

            _map.AddPlayer(player);
        }

        // Метод для создания горизонтальных тунелей
        private void CreateHorizontalTunel(int xStart, int xEnd, int yPosition)
        {
            for (int x = Math.Min(xStart, xEnd); x <= Math.Max(xStart, xEnd); x++)
            {
                _map.SetCellProperties(x, yPosition, true, true);
            }
        }

        // Метод для создания вертикального тунеля
        private void CreateVerticaleTunel(int yStart, int yEnd, int xPosition)
        {
            for (int y = Math.Min(yStart, yEnd); y <= Math.Max(yStart, yEnd); y++)
            {
                _map.SetCellProperties(xPosition, y, true, true);
            }
        }

        // Расположение монстров на карте
        private void PlaceMonsters()
        {
            // Каждая комната имеет 60% шанс появления монстров
            foreach (var room in _map.Rooms)
            {
                if (Dice.Roll("1D10") < 7)
                {
                    // Генерируем от 1 до 4 монстров
                    var numberOfMonsters = Dice.Roll("1D4");
                    for (int i = 0; i < numberOfMonsters; i++)
                    {
                        // Найдите случайное место в комнате, по которому можно пройти, чтобы разместить монстра
                        Point randomRoomLocation =(Point) _map.GetRandonWalkableLocationInRoom(room);
                        // Создаем монстра если в комнате есть место (null ставили на отрицание)
                        if (randomRoomLocation != null)
                        {
                            // Временно фиксируем в одном положении
                            var monster = Kobold.Create(1);
                            monster.X = randomRoomLocation.X;
                            monster.Y = randomRoomLocation.Y;
                            _map.AddMonster(monster);
                        }
                    }
                }
            }
                
        }

        // Создание дверей
        private void CreateDoors(Rectangle room)
        {
            // Границы комнат
            int xMin = room.Left;
            int xMax = room.Right;
            int yMin = room.Top;
            int yMax = room.Bottom;

            // Помещаем ячейки границ комнат в список
            List<Cell> borderCells = _map.GetCellsAlongLine(xMin, yMin, xMax, yMin).ToList();
            borderCells.AddRange(_map.GetCellsAlongLine(xMin, yMin, xMin, yMax));
            borderCells.AddRange(_map.GetCellsAlongLine(xMin, yMax, xMax, yMax));
            borderCells.AddRange(_map.GetCellsAlongLine(xMax, yMin, xMax, yMax));

            // Проходим по границам каждой из комнат и ищем места для размещения дверей.
            foreach (Cell cell in borderCells)
            {
                if (IsPotentialDoor(cell))
                {
                    // Дверь должна блокировать поле зрения, когда она закрыта.
                    _map.SetCellProperties(cell.X, cell.Y, false, true);
                    _map.Doors.Add(new Door 
                    {
                        X = cell.X, 
                        Y = cell.Y, 
                        IsOpen = false 
                    });
                }
            }
        }

        // Проверяет, подходит ли ячейка для размещения двери
        private bool IsPotentialDoor(Cell cell)
        {
            // Если ячейка не проходима
            // тогда это стена, а не место для двери
            if (!cell.IsWalkable)
            {
                return false;
            }
            // Сохраняем ссылки на все соседние ячейки
            Cell right = _map.GetCell(cell.X + 1, cell.Y);
            Cell left = _map.GetCell(cell.X - 1, cell.Y);
            Cell top = _map.GetCell(cell.X, cell.Y - 1);
            Cell bottom = _map.GetCell(cell.X, cell.Y + 1);

            // Убедитесь, что здесь еще нет двери
            if (_map.GetDoor(cell.X, cell.Y) != null ||
                _map.GetDoor(right.X, right.Y) != null ||
                _map.GetDoor(left.X, left.Y) != null ||
                _map.GetDoor(top.X, top.Y) != null ||
                _map.GetDoor(bottom.X, bottom.Y) != null
                )
            {
                return false;
            }

            // Это хорошее место для двери в левой или правой части комнаты
            if (right.IsWalkable && left.IsWalkable && !top.IsWalkable && !bottom.IsWalkable)
            {
                return true;
            }

            // Это хорошее место для двери в верхней или нижней части комнаты
            if (!right.IsWalkable && !left.IsWalkable && top.IsWalkable && bottom.IsWalkable)
            {
                return true;
            }
            return false;
        }

        private void CreateStairs()
        {
            _map.StairsUp = new Stairs
            {
                X = _map.Rooms.First().Center.X + 1,
                Y = _map.Rooms.First().Center.Y,
                IsUp = true
            };
            _map.StairsDown = new Stairs
            {
                X = _map.Rooms.Last().Center.X,
                Y = _map.Rooms.Last().Center.Y,
                IsUp = false
            };
        }
    }
}
