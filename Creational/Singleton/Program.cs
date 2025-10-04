namespace Singleton {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(Singleton.Instance.Value);
        }
    }

    class Singleton {
        private static Singleton _instance;

        public static Singleton Instance {
            get {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }

        public string Value = "Hello";
    }
}