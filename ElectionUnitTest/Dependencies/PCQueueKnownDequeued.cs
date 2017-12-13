using Election;

namespace ElectionUnitTest.Dependencies
{
    public class PCQueueKnownDequeued : IPCQueue
    {
        public void enqueueItem(Work item)
        {
            // Can be left as an empty stub since it is not called 
        }

        public Work dequeueItem()
        {
            // Dequeue a dummy Work instance
            var work = new Work(new ConfigRecord("Newcastle North.xml"), new ConstituencyFileReaderReturnKnownNewcastleN());
            return work;
        }
    }
}
