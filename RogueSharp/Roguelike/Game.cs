using RLNET;
using Roguelike.Core;
using Roguelike.Systems;
using RogueSharp.Random;
using System;

namespace RogueSharpV3Tutorial
{
    public class Game
    {
        // Задаем высоту и ширину экрана в пикселях
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;
        private static RLRootConsole _rootConsole;

        // Консоль карты занимает большую часть экрана и именно здесь будет отображаться карта.
        private static readonly int _mapWidth = 80;
        private static readonly int _mapHeight = 48;
        private static RLConsole _mapConsole;

        // Под консолью карты находится консоль сообщений, которая отображает броски атаки и другую информацию.
        private static readonly int _messageWidth = 80;
        private static readonly int _messageHeight = 11;
        private static RLConsole _messageConsole;

        // Консоль статистики находится справа от карты и отображает статистику игроков и монстров.
        private static readonly int _statWidth = 20;
        private static readonly int _statHeight = 70;
        private static RLConsole _statConsole;

        // Над картой находится консоль инвентаря, которая показывает снаряжение, способности и предметы игроков.
        private static readonly int _inventoryWidth = 80;
        private static readonly int _inventoryHeight = 11;
        private static RLConsole _inventoryConsole;

        private static bool _renderRequired = true;

        private static int _mapLevel = 1;

        // Свойства создаются для того, что бы в них потом положить екзкмпляры класса, которые могут меняться со временем
        // Создние свойства "Игрок"
        public static Player Player { get; set; }
        // Создние свойства "Карта"
        public static DungeonMap DungeonMap { get; private set; }
        // Создание свойства "Передвижение игрока"
        public static CommandSystem CommandSystem { get; private set; }

        // Создание свойства "Журнал сообщений"
        public static MessageLog MessageLog { get; private set; }

        // Создание свойства "Рандом"
        public static IRandom Random { get; private set; }

        // Создание свойства "Планирование"
        public static SchedulingSystem SchedulingSystem { get; private set; }

        public static void Main()
        {
            // Устанавливаем начальное значение для генератора случайных чисел с текущего времени
            int seed = (int) DateTime.UtcNow.Ticks;
            Random = new DotNetRandom(seed);

            // Создание консольного окна
            // Перенос шрифта из растровой картинки в системную строку.
            string fontFileName = "terminal8x8.png";

            // Заголовок появится в верхней части окна консоли.
            // также включаем начальное значение, используемое для генерации уровня
            string consoleTitle = $"RougeSharp V3 Tutorial - Level {_mapLevel} - Seed {seed}";

            // Создание основной консоли с растровым шрифтом, который мы указали, с каждой плиткой размером 8 x 8 пикселей.
            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);
            // Создание дополнительных консолей карты, сообщений, инвенторя и статистики
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _inventoryConsole = new RLConsole(_inventoryWidth, _inventoryHeight);

            // Карта отрисовывается в генераторе
            // Отрисовка консоли статистики (перенесено из OnRootConsoleUpdate)
            // _statConsole.SetBackColor(0, 0, _statWidth, _statHeight, Swatch.DbOldStone);
            // _statConsole.Print(1, 1, "Stats", Colors.TextHeading);
            
            // отрисовка консоли инвентаря (перенесено из OnRootConsoleUpdate)
            _inventoryConsole.SetBackColor(0, 0, _inventoryWidth, _inventoryHeight, Swatch.DbWood);
            _inventoryConsole.Print(1, 1, "Inventory", Colors.TextHeading);

            // Создаем новый MessageLog и печатаем случайное начальное число, используемое для генерации уровня
            MessageLog = new MessageLog();
            MessageLog.Add("Hello, rogue!");
            MessageLog.Add($"Welcom on the map '{seed}'");

            SchedulingSystem = new SchedulingSystem();

            // Создание объектов игры: карта, движение игрока
            // Создание экземпляра генератора карты с заполненным конструктором
            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight, 75, 10, 7, _mapLevel);
            // Передача значения карты из генератора в свойство
            DungeonMap = mapGenerator.CreateMap();
            // Создание модели перемещений и перенос их в свойство
            CommandSystem = new CommandSystem();
            

            DungeonMap.UpdatePlayerFieldOfView();

            // Настройте обработчик события Update RLNET.
            _rootConsole.Update += OnRootConsoleUpdate;
            // Настройте обработчик события Render RLNET.
            _rootConsole.Render += OnRootConsoleRender;
            // Начать игровой цикл RLNET
            _rootConsole.Run(); 
        }

        // Обработчик события для обновления RLNET
        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            // Фиксируем последнюю нажатую клавишу
            bool didPlayerAct = false;
            RLKeyPress keyPress = _rootConsole.Keyboard.GetKeyPress();

            if (CommandSystem.IsPlayerTurn)
            {
                if (keyPress != null)
                {
                    if (keyPress.Key == RLKey.Up)
                    {
                        didPlayerAct = CommandSystem.MovePlayer(Direction.Up);
                    }
                    else if (keyPress.Key == RLKey.Down)
                    {
                        didPlayerAct = CommandSystem.MovePlayer(Direction.Down);
                    }
                    else if (keyPress.Key == RLKey.Left)
                    {
                        didPlayerAct = CommandSystem.MovePlayer(Direction.Left);
                    }
                    else if (keyPress.Key == RLKey.Right)
                    {
                        didPlayerAct = CommandSystem.MovePlayer(Direction.Right);
                    }
                    else if (keyPress.Key == RLKey.Escape)
                    {
                        _rootConsole.Close();
                    }
                    else if (keyPress.Key == RLKey.Period)
                    {
                        if (DungeonMap.CanMoveDownToNextLevel())
                        {
                            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight, 20, 13, 7, ++_mapLevel);
                            DungeonMap = mapGenerator.CreateMap();
                            MessageLog = new MessageLog();
                            CommandSystem = new CommandSystem();
                            _rootConsole.Title = $"RougeSharp RLNet Tutorial - Level {_mapLevel}";
                            didPlayerAct = true;
                        }
                    }
                }
                if (didPlayerAct)
                {
                    _renderRequired = true;
                    CommandSystem.EndPlayerTurn();
                }
            }
            else
            {
                CommandSystem.ActivateMonsters();
                _renderRequired = true;
            }
        }

        // Обработчик события для воспроизведения Render RLNET
        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            // Проверка необходимости отрисовки консоли
            if (_renderRequired)
            {
                // Очистка консолей    
                _mapConsole.Clear();
                _statConsole.Clear();
                _messageConsole.Clear();

                // Рисование карты
                DungeonMap.Draw(_mapConsole, _statConsole);
                Player.Draw(_mapConsole, DungeonMap);
                Player.DrawStats(_statConsole);
                MessageLog.Draw(_messageConsole);


                // Размещаем консоли по верх основной 
                // консоль / ХУ начала / размеры окна / основная консоль / ХУ перемещения
                // См. размеры окон в классе Game 
                RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, 0, _inventoryHeight);
                RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole, _mapWidth, 0);
                RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, 0, _screenHeight - _messageHeight);
                RLConsole.Blit(_inventoryConsole, 0, 0, _inventoryWidth, _inventoryHeight, _rootConsole, 0, 0);

                // Рисование карты. Метод не нужен, т.к. карта прорисовывается в генераторе
                // DungeonMap.Draw(_mapConsole);

                // Скажите RLNET, чтобы он нарисовал консоль, которую мы установили
                _rootConsole.Draw();

                _renderRequired = false;
            }
            
            
        }

    }
}