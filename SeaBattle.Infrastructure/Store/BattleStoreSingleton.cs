using System;
using SeaBattle.Domain;

namespace SeaBattle.Infrastructure.Store
{
    public class BattleStoreSingleton
    {
        private static Battle _instance = null;
        private static readonly object _lock = new object();

        static BattleStoreSingleton()
        {
        }
        
        private BattleStoreSingleton()
        {
        }

        public static void CreateBattle(Battle battle)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = battle;
                }
                else
                {
                    throw new Exception("Игра уже создана. Повторное создание игры невозможно, используйте метод clear для очищения игры.");
                }
            }
        }

        public static Battle Battle => _instance;

        public static void UpdateBattle(Battle battle)
        {
            // в текущей реализации метод обновления не нужен, т.к. объект хранится в памяти и обновляется по ссылке
            // добавлен для имитации работы с хранилищем
            lock (_lock)
            {
                _instance = battle;
            }
        }
    }
}