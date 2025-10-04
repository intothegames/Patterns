namespace State {
    // StateMachine - класс, который содержит в себе экземпляр абстрактного класса GameState
    // а также метод DoStep() который вызывает DoStep() в GameState
    // и реализован по разному в наследниках класса GameState (PlayerTurn, EnemyTurn, EndRound)
    // Переключение состояний осуществляется внутри класса состояния

    internal class Program {
        static void Main(string[] args) {
            StateMachine _stateMachine = new StateMachine();
            _stateMachine.DoStep();
        }
    }

    public class StateMachine {
        private GameState _currentState;
        private Dictionary<Type, GameState> _gameStates;

        public StateMachine() {
            InitStates();
            SetStateByDefault();
        }
        public void DoStep() {
            _currentState.DoStep();
        }
        public void SetStatePlayerTurn() {
            var playerTurnState = GetState<PlayerTurn>();
            SetState(playerTurnState);
        }
        public void SetStateEnemyTurn() {
            var enemyTurnState = GetState<EnemyTurn>();
            SetState(enemyTurnState);
        }
        public void SetStateEndRound() {
            var endRoundState = GetState<EndRound>();
            SetState(endRoundState);
        }

        private void InitStates() {
            _gameStates = new Dictionary<Type, GameState>();

            _gameStates[typeof(PlayerTurn)] = new PlayerTurn(this);
            _gameStates[typeof(EnemyTurn)] = new EnemyTurn(this);
            _gameStates[typeof(EndRound)] = new EndRound(this);
        }

        private void SetState(GameState newState) {
            if(_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private void SetStateByDefault() {
            var stateByDefault = GetState<PlayerTurn>();
            SetState(stateByDefault);
        }

        private GameState GetState<T>() where T : GameState {
            var type = typeof(T);
            return _gameStates[type];
        }
    }

    public abstract class GameState {
        protected StateMachine _gameManager;
        protected GameState(StateMachine gameManager) {
            _gameManager = gameManager;
        }
        public abstract void Enter();
        public abstract void Exit();
        public abstract void DoStep();
    }
    public class PlayerTurn(StateMachine gameManager) : GameState(gameManager)
    {
        public override void Enter() { }
        public override void Exit() { }
        public override void DoStep() {
            // Player attacks enemy
            if (Enemy.IsAlive)
                _gameManager.SetStateEnemyTurn();
            else
                _gameManager.SetStateEndRound();
        }
    }
    public class EnemyTurn(StateMachine gameManager) : GameState(gameManager) {
        public override void Enter() { }
        public override void Exit() { }
        public override void DoStep() {
            // Enemy attacks player
            if (Player.IsAlive)
                _gameManager.SetStatePlayerTurn();
            else
                _gameManager.SetStateEndRound();
        }
    }
    public class EndRound(StateMachine gameManager) : GameState(gameManager) {
        public override void Enter() { }
        public override void Exit() { }
        public override void DoStep() {
            // Calculate round result
            _gameManager.SetStatePlayerTurn();
        }
    }


    // additional class
    public static class Player {
        public static bool IsAlive { get; set; }
    }
    public static class Enemy {
        public static bool IsAlive { get; set; }
    }
}
