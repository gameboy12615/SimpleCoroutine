using System.Collections;

namespace SimpleCoroutine
{
    class Coroutine
    {
        public IEnumerator enumerator;
        private bool isDone = false;

        public void ContinueCoroutine(object context, object userData)
        {
            if(null == enumerator || isDone)
            {
                return;
            }

            this.Run();
        }

        public void Run()
        {
            if (null == enumerator || isDone)
            {
                return;
            }

            if (!enumerator.MoveNext())
            {
                return;
            }

            var element = enumerator.Current;
            if (null == element)
            {
                return;
            }

            if (element is WaitForFrames)
            {
                int delayedFrameNum = ((WaitForFrames)element).frameNum;
                DelayedCallManager.Instance.DelayedCall(ContinueCoroutine, delayedFrameNum, null, null);
            }
        }

        public void StopCoroutine()
        {
            isDone = true;
        }
    }
}
