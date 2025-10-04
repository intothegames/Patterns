namespace AbstractFactory {
    internal class Program {
        private static Castle _currentCastle;
        static void Main(string[] args) {
            // указав единожды нужную фабрику. этот метод можно дёграть извне, меняя нужный замок
            SetCastle(new WhiteCastle());

            // создаём юнита нужного замка
            var warrior = _currentCastle.CreateWarrior();
            var mage = _currentCastle.CreateMage();
            var archer = _currentCastle.CreateArcher();
        }

        public static void SetCastle(Castle currentCastle) {
            _currentCastle = currentCastle;
        }
    }

    abstract class Castle {
        public abstract Warrior CreateWarrior(); // abstract method
        public abstract Mage CreateMage(); // abstract method
        public abstract Archer CreateArcher(); // abstract method
    }

        class WhiteCastle : Castle {
            public override Warrior CreateWarrior() {
                return new WhiteWarrior(); // логика подгрузки префаба, добавление компонента WhiteWarrior, инициализация его полей
            }
            public override Mage CreateMage() {
                return new WhiteMage(); // логика подгрузки префаба, добавление компонента WhiteMage, инициализация его полей
            }
            public override Archer CreateArcher(){
                return new WhiteArcher(); // логика подгрузки префаба, добавление компонента WhiteArcher, инициализация его полей
            }
        }

        class BlackCastle : Castle {
            public override Warrior CreateWarrior() {
                return new BlackWarrior(); // логика подгрузки префаба, добавление компонента BlackWarrior, инициализация его полей
            }
            public override Mage CreateMage() {
                return new BlackMage(); // логика подгрузки префаба, добавление компонента BlackMage, инициализация его полей
            }
            public override Archer CreateArcher() {
                return new BlackArcher(); // логика подгрузки префаба, добавление компонента BlackArcher, инициализация его полей
            }
        }

    abstract class Unit { }

        abstract class Warrior : Unit { }
            class WhiteWarrior : Warrior { }
            class BlackWarrior : Warrior { }

        abstract class Mage : Unit { }
            class WhiteMage : Mage { }
            class BlackMage : Mage { }

        abstract class Archer : Unit { }
            class WhiteArcher : Archer { }
            class BlackArcher : Archer { }
}
