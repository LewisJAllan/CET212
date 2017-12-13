using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Election;
using ElectionUnitTest.Fixtures;
using TestedClass = Election.Work;
using ElectionUnitTest.Dependencies;
using ElectionUnitTest.Helpers;

namespace ElectionUnitTest.Fixtures
{
    [TestClass]
    public class TestFixture_Work
    {
        [TestMethod]
        public void Test_ReadData_Method_Correct_Constituency_Returned()
        {
            // Arrange
            // Use the ConstituencyFileReaderReturnKnownNewcastleN implementation of IConstituencyFileReader which simply returns a
            // known Constituency instance from its ReadConstituencyDataFromFile() method, note that no ConfigRecord if actually
            // needed so this can be passed as a null
            var ioHandler = new ConstituencyFileReaderReturnKnownNewcastleN();

            // Instantiate a Work object
            var testedClass = new TestedClass(null, ioHandler);

            // Use helper class to get a known Newcastle North instance
            var expectedConstituency = Helper_KnownConstituencyDataRepository.GetKnownNewcastleN();

            // Act
            // Call the ReadData() method of the Work instance and the data held in the constituency returned from this should
            // be identical to the data held in the expected constituency instance
            var actualConstituency = testedClass.ReadData();

            // Assert
            // Check each property of the expected and actual constituency instances to make sure they contain the same data,
            // note here that it would be a good idea to give the VoteReport class a way to check its data value equality
            // with another VoteRecord object via the overriding of its Equals() method

            // First check ConstituencyName properties
            Assert.AreEqual(expectedConstituency.constituencyName, actualConstituency.constituencyName);

            // Next check lengths of DataMeasure lists
            Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInformation.Count, actualConstituency.VoteReportVotes.candidateInformation.Count);
            Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInfoExt.Count, actualConstituency.VoteReportVotes.candidateInfoExt.Count);
            Assert.AreEqual(expectedConstituency.VoteReportVotes.constituencyTotalVotes.Count, actualConstituency.VoteReportVotes.constituencyTotalVotes.Count);

            // Now iterate through each DataMeasure list and check for data equality
            for (var i = 0; i < expectedConstituency.VoteReportVotes.candidateInformation.Count; i++)
            {
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInformation[i].PartyName, actualConstituency.VoteReportVotes.candidateInformation[i].PartyName);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInformation[i].Firstname, actualConstituency.VoteReportVotes.candidateInformation[i].Firstname);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInformation[i].Lastname, actualConstituency.VoteReportVotes.candidateInformation[i].Lastname);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInformation[i].Votes, actualConstituency.VoteReportVotes.candidateInformation[i].Votes);
            }
            for (var i = 0; i < expectedConstituency.VoteReportVotes.candidateInfoExt.Count; i++)
            {
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInfoExt[i].ConstituencyName, actualConstituency.VoteReportVotes.candidateInfoExt[i].ConstituencyName);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInfoExt[i].PartyName, actualConstituency.VoteReportVotes.candidateInfoExt[i].PartyName);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInfoExt[i].Firstname, actualConstituency.VoteReportVotes.candidateInfoExt[i].Firstname);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInfoExt[i].Lastname, actualConstituency.VoteReportVotes.candidateInfoExt[i].Lastname);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.candidateInfoExt[i].Votes, actualConstituency.VoteReportVotes.candidateInfoExt[i].Votes);
            }
            for (var i = 0; i < expectedConstituency.VoteReportVotes.constituencyTotalVotes.Count; i++)
            {
                Assert.AreEqual(expectedConstituency.VoteReportVotes.constituencyTotalVotes[i].PartyName, actualConstituency.VoteReportVotes.constituencyTotalVotes[i].PartyName);
                Assert.AreEqual(expectedConstituency.VoteReportVotes.constituencyTotalVotes[i].Votes, actualConstituency.VoteReportVotes.constituencyTotalVotes[i].Votes);
            }
        }
    }
}
