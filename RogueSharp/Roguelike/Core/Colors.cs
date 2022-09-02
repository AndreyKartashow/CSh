using RLNET;

namespace Roguelike.Core
{
    public class Colors
    {
        // Цвета, которые используются в игре

        // Цвет пола
        public static RLColor FloorBackground = RLColor.Black;
        public static RLColor Floor = Swatch.AlternateDarkest;
        public static RLColor FloorBackgroundFov = Swatch.DbDark;
        public static RLColor FloorFov = Swatch.Alternate;

        // Цвет стен
        public static RLColor WallBackground = Swatch.SecondaryDarkest;
        public static RLColor Wall = Swatch.Secondary;
        public static RLColor WallBackgroundFov = Swatch.SecondaryDarker;
        public static RLColor WallFov = Swatch.SecondaryLighter;

        // Цвет дверей
        public static RLColor DoorBackground = Swatch.ComplimentDarkest;
        public static RLColor Door = Swatch.ComplimentLighter;
        public static RLColor DoorBackgroundFov = Swatch.ComplimentDarker;
        public static RLColor DoorFov = Swatch.ComplimentLightest;

        public static RLColor TextHeading = Swatch.DbLight;
        public static RLColor Text = Swatch.DbLight;

        // Цвет игрока
        public static RLColor Player = Swatch.DbLight;

        // Статистика
        public static RLColor Gold = Swatch.DbSun;

        // Цвет кобольта
        public static RLColor KoboldColor = Swatch.DbBrightWood;
    }
}