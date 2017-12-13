using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Election;
using ElectionUnitTest.Fixtures;
using TestedClass = Election.Producer;
using ElectionUnitTest.Dependencies;

namespace ElectionUnitTest.Fixtures
{
    [TestClass]
    public class TestFixture_Producer
    {
        //set class objects to null
        TestedClass testedClass = null;
        ConfigData configData = null;
        PCQueueCallEnqueueItem pcQueue = null;
        //after each completed/attempted test
        //set class objects back to null
        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
            configData = null;
            pcQueue = null;
        }

        [TestMethod]
        public void Test_One_Thread_Created()
        {
            // Arrange
            pcQueue = new PCQueueCallEnqueueItem();

            // When arranging the ConfigData instance no ConfigRecords are required since it does not need to actually
            // do anything, plus no IOHandler needed as it is never called (so use null)
            configData = new ConfigData();
            testedClass = new TestedClass("PRODUCER", pcQueue, configData, null);
            var expectedThreadCount = 1;

            // Act
            // Wait a few seconds to allow Producer thread to start up
            Thread.Sleep(5000);

            // During this time the Producer should have started as a single thread and incremented the running thread
            // count by one
            var actualThreadCount = TestedClass.RunningThreads;

            // Signal Producer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Producer to finish
            Thread.Sleep(1000);

            // Assert
            Assert.AreEqual(expectedThreadCount, actualThreadCount);
        }

        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Never_Called()
        {
            // Use the helper methods to run the test
            Helper_Assert(Helper_Arrange(0), Helper_Act());
        }

        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Called_Once()
        {
            // Use the helper methods to run the test
            Helper_Assert(Helper_Arrange(1), Helper_Act());
        }

        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Called_Ten_Times()
        {
            // Use the helper methods to run the test
            Helper_Assert(Helper_Arrange(10), Helper_Act());
        }

        private int Helper_Arrange(int configRecordsCount)
        {
            // Instantiate a new PCQueue object
            pcQueue = new PCQueueCallEnqueueItem();

            // Instantiate a new ConfigData object
            configData = new ConfigData();

            // Add ConfigRecord instances to ConfigData object's config records list 
            for (int i = 0; i < configRecordsCount; i++)
            {
                configData.configRecords.Add(new ConfigRecord("NeverUsed"));
            }

            // Instantiate a new Producer object, note: work items need no IOHandler as it is never called so this
            // can be supplied as a null
            testedClass = new TestedClass("PRODUCER", pcQueue, configData, null);

            // The expected number of calls to the pcQueue's EnqueueItem() method should be once per iteration of the 
            // while(...) loop in the Run() method of the Producer, this is returned from this method
            return configRecordsCount;
        }

        private int Helper_Act()
        {
            // Wait a few seconds to allow Producer thread to start up and execute its Run() method
            Thread.Sleep(5000);

            // During this time the Producer thread should have iterated through its Run() method's while(...) loop once
            // for each config record in the config data list 

            // Signal Producer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Producer to finish
            Thread.Sleep(1000);

            // Return the actual number of calls to the PCQueue's EnqueueItem method
            return pcQueue.EnqueueItemCallCount;
        }
        private void Helper_Assert(int expected, int actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
