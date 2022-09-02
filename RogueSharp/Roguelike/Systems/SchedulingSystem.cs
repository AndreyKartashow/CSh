using System.Collections.Generic;
using System.Linq;
using Roguelike.Interfaces;

namespace Roguelike.Systems
{
    public class SchedulingSystem
    {
        private int _time;
        private readonly SortedDictionary<int, List<IScheduleable>> _schduleable;

        public SchedulingSystem()
        {
            _time = 0;
            _schduleable = new SortedDictionary<int, List<IScheduleable>>();
        }

        // Добавляем новый объект "Расписание"
        // Поместите его в текущее время плюс свойство Time объекта.
        public void Add(IScheduleable scheduleable)
        {
            int key = _time + scheduleable.Time;
            if (!_schduleable.ContainsKey(key))
            {
                _schduleable.Add(key, new List<IScheduleable>());
            }
            _schduleable[key].Add(scheduleable);
        }

        // Удалить конкретный объект из расписания.
        // Полезно, когда монстр убит, чтобы удалить его, прежде чем он снова начнет действовать.
        public void Remove(IScheduleable scheduleable)
        {
            KeyValuePair<int, List<IScheduleable>> schedulableListFound = new KeyValuePair<int, List<IScheduleable>>(-1, null);

            foreach (var schedulableList in _schduleable)
            {
                if (schedulableList.Value.Contains(scheduleable))
                {
                    schedulableListFound = schedulableList;
                    break;
                }
            }
            if (schedulableListFound.Value != null)
            {
                schedulableListFound.Value.Remove(scheduleable);
                if (schedulableListFound.Value.Count <= 0)
                {
                    _schduleable.Remove(schedulableListFound.Key);
                }
            }
        }

        // Получить следующий объект, чья очередь, из расписания.  Предварительное время, если необходимо
        public IScheduleable Get()
        {
            var firstSchedulableGroup = _schduleable.First();
            var firstSchedulable = firstSchedulableGroup.Value.First();
            Remove(firstSchedulable);
            _time = firstSchedulableGroup.Key;
            return firstSchedulable;
        }

        // Добавим текущее время для расписания
        public int GetTime()
        {
            return _time;
        }

        // Сбросьте время и очистите расписание
        public void Clear()
        {
            _time = 0;
            _schduleable.Clear();
        }
    }
}
