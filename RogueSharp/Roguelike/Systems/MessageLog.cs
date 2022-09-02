using RLNET;
using System.Collections.Generic;


namespace Roguelike.Systems
{
    // Представляет собой стек сообщений
    // Имеет метод для рисования на RLConsole
    public class MessageLog
    {
        // Определяем максимальное количество строк для хранения
        private static readonly int _maxLines = 9;

        // Используем очередь для отслеживания строк текста
        // Первая строка, добавленная в лог, будет и первой удаленной
        private readonly Queue<string> _lines;

        public MessageLog()
        {
            _lines = new Queue<string>();
        }

        // Добавляем строку в очередь MessageLog
        public void Add(string message)
        {
            _lines.Enqueue(message);
            // Если число сообщений больше чем нужно, то первое удаляется
            if (_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
        }

        // Отрисовываем каждую строку очереди MessageLog в консоль
        public void Draw(RLConsole console)
        {
            string[] lines = _lines.ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                console.Print(1, i + 1, lines[i], RLColor.White);
            }
        }




    }
}
