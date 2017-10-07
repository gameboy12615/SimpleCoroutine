using System.Collections.Generic;

namespace SimpleCoroutine
{
    class DelayedCallManager : Singleton<DelayedCallManager>
    {
        private List<DelayedCallback> callbacks = new List<DelayedCallback>();
        private List<DelayedCallback> addCallbacks = new List<DelayedCallback>();
        private List<DelayedCallback> removeCallbacks = new List<DelayedCallback>();

        public override void Init()
        {
            base.Init();

            callbacks.Clear();
            addCallbacks.Clear();
            removeCallbacks.Clear();
        }

        public void Update()
        {
            for (int i = 0; i < addCallbacks.Count; i++)
            {
                DelayedCallback addCallback = addCallbacks[i];
                callbacks.Add(addCallback);
            }
            addCallbacks.Clear();

            for (int i = 0; i < callbacks.Count; i++)
            {
                DelayedCallback callback = callbacks[i];

                if (null == callback)
                {
                    continue;
                }

                callback.curFrameNum++;
                if (callback.curFrameNum >= callback.frameNum)
                {
                    callback.callback(callback.context, callback.userData);
                    removeCallbacks.Add(callback);
                }
            }

            for (int i = 0; i < removeCallbacks.Count; i++)
            {
                DelayedCallback removeCallback = removeCallbacks[i];
                callbacks.Remove(removeCallback);
            }
            removeCallbacks.Clear();
        }

        public void DelayedCall(DelayedCallbackDelegate callback, int delayedFrameNum, object context, object userData)
        {
            DelayedCallback delayedCallback = new DelayedCallback();
            delayedCallback.callback = callback;
            delayedCallback.frameNum = delayedFrameNum;
            delayedCallback.context = context;
            delayedCallback.userData = userData;

            addCallbacks.Add(delayedCallback);
        }
    }
}
