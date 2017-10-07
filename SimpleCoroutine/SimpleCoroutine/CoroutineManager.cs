using System.Collections;
using System.Collections.Generic;

namespace SimpleCoroutine
{
    class CoroutineManager : Singleton<CoroutineManager>
    {
        List<Coroutine> coroutineList = new List<Coroutine>();

        public override void Init()
        {
            base.Init();

            coroutineList.Clear();
        }

        public void CreateCoroutine(IEnumerator enumerator)
        {
            Coroutine coroutine = new Coroutine();
            coroutine.enumerator = enumerator;
            coroutineList.Add(coroutine);

            coroutine.Run();
        }

        public void RemoveCoroutine(IEnumerator enumerator)
        {
            Coroutine removeCoroutine = null;
            for (int i = 0; i < coroutineList.Count; i++)
            {
                Coroutine coroutine = coroutineList[i];
                if (coroutine.enumerator == enumerator)
                {
                    removeCoroutine = coroutine;
                }
            }

            if (null != removeCoroutine)
            {
                removeCoroutine.StopCoroutine();
                coroutineList.Remove(removeCoroutine);
            }
        }
    }
}
