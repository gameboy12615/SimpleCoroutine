
namespace SimpleCoroutine
{
    abstract class YieldInstruction
    {
    }

    class WaitForFrames : YieldInstruction
    {
        public int frameNum;

        public WaitForFrames(int frameNum)
        {
            this.frameNum = frameNum;
        }
    }
}
