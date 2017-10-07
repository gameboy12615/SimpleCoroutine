
namespace SimpleCoroutine
{
    delegate void DelayedCallbackDelegate(object context, object userData);

    class DelayedCallback
    {
        public DelayedCallbackDelegate callback;
        public object context;
        public object userData;
        public int frameNum;
        public int curFrameNum;
    }
}
