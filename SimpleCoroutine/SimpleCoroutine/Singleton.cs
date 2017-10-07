
namespace SimpleCoroutine
{
    class Singleton<T> where T : class, new()
    {
        private static T instance;

        protected Singleton() { }

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    CreateInstance();
                }

                return instance;
            }

            protected set
            {
                instance = value;
            }
        }

        public static void CreateInstance()
        {
            if (instance == null)
            {
                instance = new T();

                (instance as Singleton<T>).Init();
            }
        }

        public static void DestroyInstance()
        {
            if (instance != null)
            {
                (instance as Singleton<T>).UnInit();
                instance = null;
            }
        }

        public virtual void Init() { }

        public virtual void UnInit() { }
    }
}
