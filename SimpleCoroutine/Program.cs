using System;
using System.Collections;
using System.Threading;
using SimpleCoroutine;

namespace CoroutineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Init();

            while(true)
            {
                game.Update();
                Thread.Sleep(33);
            }
        }
    }

    class Game
    {
        private uint frameCount = 0;

        public void Init()
        {
            frameCount = 0;
        }

        public void Update()
        {
            frameCount++;

            DelayedCallManager.Instance.Update();

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch(keyInfo.Key)
                {
                    case ConsoleKey.Spacebar:
                        OnSpacebarClicked();
                        break;
                }
            }
        }

        public void StartCoroutine(IEnumerator enumerator)
        {
            CoroutineManager.Instance.CreateCoroutine(enumerator);
        }

        public void StopCoroutine(IEnumerator enumerator)
        {
            CoroutineManager.Instance.RemoveCoroutine(enumerator);
        }

        void OnSpacebarClicked()
        {
            StartCoroutine(DelayedCoroutine(100, 10));
        }

        IEnumerator DelayedCoroutine(int delayedFrameNum1, int delayedFrameNum2)
        {
            Console.WriteLine("DelayedCoroutine1: frameCount = " + frameCount);

            yield return new WaitForFrames(delayedFrameNum1);

            Console.WriteLine("DelayedCoroutine2: frameCount = " + frameCount);

            yield return new WaitForFrames(delayedFrameNum2);

            Console.WriteLine("DelayedCoroutine3: frameCount = " + frameCount);
        }
    }
}
