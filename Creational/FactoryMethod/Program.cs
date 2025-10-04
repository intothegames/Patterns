namespace FactoryMethod {
    internal class Program {
        static void Main(string[] args) {
            Castle _warriorsCastle = new WarriorsCastle();
            Castle _magesCastle = new MagesCastle();

            Unit warrior = _warriorsCastle.CreateUnit();
            Unit mage = _magesCastle.CreateUnit();
            // или так
            Unit anotherWarrior = MakeUnit(_warriorsCastle);
            Unit anotherMage = MakeUnit(_magesCastle);
        }

        public static Unit MakeUnit(Castle creator) {
            return creator.CreateUnit();
        }
    }

    public abstract class Unit { }
        public class Warrior : Unit { }
        public class Mage : Unit { }

    public abstract class Castle {
        public abstract Unit CreateUnit(); // Factory Method
    }

    public class WarriorsCastle : Castle {
        public override Unit CreateUnit() {
            // логика подгрузки префаба, добавление компонента Warrior, инициализация его полей - фишка паттерна в этом
            return new Warrior(); 
        }
    }

    public class MagesCastle : Castle {
        public override Unit CreateUnit() {
            // логика подгрузки префаба, добавление компонента Warrior, инициализация его полей - фишка паттерна в этом
            return new Mage();
        }
    }
}
