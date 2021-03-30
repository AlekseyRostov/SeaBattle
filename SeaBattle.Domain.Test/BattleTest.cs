using System.Collections.Generic;
using NUnit.Framework;
using SeaBattle.Domain.Exceptions;

namespace SeaBattle.Domain.Test
{
    public class BattleTest
    {
        [Test]
        public void Battle_CreateShipsBeforeBattle_ThrowException()
        {
            var battle = new Battle();
            var shipsCoordinates = new List<ShipCoordinates>();

            Assert.Throws<InvalidBusinessLogicException>(() => battle.CreateShips(shipsCoordinates));
        }
        
        [Test]
        public void Battle_CreateShipsRepeatedly_ThrowException()
        {
            var battle = new Battle();
            battle.CreateBattle(10);
            var shipsCoordinates = new List<ShipCoordinates>();
            shipsCoordinates.Add(new ShipCoordinates(new[] { new Coordinates("1A"), new Coordinates("2B") }));

            battle.CreateShips(shipsCoordinates);

            Assert.Throws<InvalidBusinessLogicException>(() => battle.CreateShips(shipsCoordinates));
        }
    }
}