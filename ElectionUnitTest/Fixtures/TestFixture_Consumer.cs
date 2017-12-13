using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Election;
using ElectionUnitTest.Fixtures;
using TestedClass = Election.Consumer;
using ElectionUnitTest.Dependencies;

namespace ElectionUnitTest.Fixtures
{
    [TestClass]
    public class TestFixture_Consumer
    {
        //set classes to null
        TestedClass testedClass = null;
        ProgressManager progressManager = null;
        ConstituencyList constituencyList = null;
        IPCQueue pcQueue = null;
        //after each test
        //set class objects back to null
        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
            progressManager = null;
            constituencyList = null;
            pcQueue = null;
        }

        [TestMethod]
        public void Test_One_Thread_Created()
        {
            // Arrange
            pcQueue = new PCQueueKnownDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("CONSUMER", pcQueue, constituencyList, progressManager);
            var expectedThreadCount = 1;

            // Act
            // Wait a few milliseconds to allow Consumer thread to start up
            Thread.Sleep(5000);

            // During this time the Consumer should have started as a single thread and incremented the running thread
            // count by one
            var actualThreadCount = TestedClass.RunningThreads;

            // Signal Consumer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            Thread.Sleep(1000);

            // Assert
            Assert.AreEqual(expectedThreadCount, actualThreadCount);
        }

        [TestMethod]
        public void Test_Run_Method_Constituency_Created_Equals_Progress_Mananger_Accesses()
        {
            // Arrange
            pcQueue = new PCQueueKnownDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

            // Act
            // Wait a few milliseconds to allow Consumer thread to run for a short period, during this time the Consumer will
            // have created as many constituency as progress manager accesses, we do not know how many though
            Thread.Sleep(5000);

            // Signal Consumer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            Thread.Sleep(1000);

            // Assert
            // Expected ProgressManager accesses can be determined by the abs value of the ItemsRemaining property, one of these
            // for each time a constituency is added to the constituencylist
            Assert.AreEqual(Math.Abs(progressManager.ItemsRemaining), constituencyList.constituency.Count);
        }

        [TestMethod]
        public void Test_Run_Method_Null_Dequeued_Expect_No_ProgressManager_Accesses()
        {
            // Arrange
            pcQueue = new PCQueueNullDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

            // Act
            // Wait a few seconds to allow Consumer thread to run for a short period, during this time the Consumer will
            // have dequeued a number of nulls each of which should be ignored, we do not know how many though and it does not
            // matter (if it works for one it works for all)
            Thread.Sleep(5000);

            // Signal Consumer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            Thread.Sleep(1000);

            // Assert
            // There should be no accesses of the ProgressManager
            Assert.AreEqual(0, Math.Abs(progressManager.ItemsRemaining));
        }

        [TestMethod]
        public void Test_Run_Method_Null_Dequeued_Expect_No_Constituency()
        {
            // Arrange
            pcQueue = new PCQueueNullDequeued();
            progressManager = new ProgressManager();
            constituencyList = new ConstituencyList();
            testedClass = new TestedClass("Consumer", pcQueue, constituencyList, progressManager);

            // Act
            // Wait a few seconds to allow Consumer thread to run for a short period, during this time the Consumer will
            // have dequeued a number of nulls each of which should be ignored, we do not know how many though and it does not
            // matter (if it works for one it works for all)
            Thread.Sleep(5000);

            // Signal Consumer thread to finish
            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            Thread.Sleep(1000);

            // Assert
            // There should be no constituency added to the constituency list
            Assert.AreEqual(0, constituencyList.constituency.Count);
        }
    }
}
