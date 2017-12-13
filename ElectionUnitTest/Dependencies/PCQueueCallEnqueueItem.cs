using Election;

namespace ElectionUnitTest.Dependencies
{
    public class PCQueueCallEnqueueItem : IPCQueue
    {
        // This property is used to record the number of times the EnqueueItem method has
        // been called
        public int EnqueueItemCallCount { get; private set; }

        // Constructor
        public PCQueueCallEnqueueItem()
        {
            // Initially no calls to EnqueueItem method
            EnqueueItemCallCount = 0;
        }

        public void enqueueItem(Work item)
        {
            // When called, increment the call count property to record how many times this
            // method has been called
            EnqueueItemCallCount++;
        }

        public Work dequeueItem()
        {
            // Can be left as an empty stub since it is not called but must return something 
            return null;
        }
    }
}
