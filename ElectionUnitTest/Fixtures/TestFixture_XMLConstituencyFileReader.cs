using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Election;
using ElectionUnitTest.Fixtures;
using TestedClass = Election.XMLConstituencyFileReader;
using ElectionUnitTest.Helpers;

namespace ElectionUnitTest.Fixtures
{
    [TestClass]
    public class TestFixture_XMLConstituencyFileReader
    {
        //set class object to null
        TestedClass testedClass = null;
        //after each test
        //set class object back to null
        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Not_Exist()
        {
            // Arrange
            // A file with this name does not exist
            var fileName = "DOES_NOT_EXIST";

            // Instantiate an XMLConstituencyFileReader object
            testedClass = new TestedClass();

            // Act
            var actualConstituency = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(fileName));

            // Assert
            Assert.IsNull(actualConstituency);
        }
        //check file exist and is a valid file type
        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Middlesbrough_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid("Middlesbrough.xml", Helper_KnownConstituencyDataRepository.GetKnownMiddlesbrough());
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_NewcastleN_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid("Newcastle North.xml", Helper_KnownConstituencyDataRepository.GetKnownNewcastleN());
        }

        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_SunderlandN_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid("Sunderland North.xml", Helper_KnownConstituencyDataRepository.GetKnownSunderlandN());
        }

        [TestMethod]
        [ExpectedException(typeof(System.Xml.XmlException))]
        public void Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Invalid()
        {
            // Arrange
            // A file with this name exist and contains a constituency that has the same data as the expected constituency
            // object instance
            var fileName = "Newcastle North-Invalid.xml";

            // Instantiate an XMLConstituencyFileReader object
            testedClass = new TestedClass();

            // Act
            // Call the ReadConstituencyDataFromFile() method to load and process an invalid XML format, this should
            // throw a System.Xml.XmlException
            var actualConstituency = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(fileName));

            // Assert
            // Should not reach here due to exception being raised, if reached then force the test to fail
            Assert.Fail("ERROR: should have thrown System.Xml.XmlException before reaching here!");
        }

        private void Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid(string fileName, Constituency expectedConstituency)
        {
            // Arrange
            // Instantiate an XMLConstituencyFileReader object
            testedClass = new TestedClass();

            // Act
            // Call the ReadConstituencyDataFromFile() method to load and process the known constituency from the XML format
            var actualConstituency = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(fileName));

            // Assert
            // Check each property of the expected and actual constituency instances to make sure they contain the same data,
            // note here that it would be a good idea to give the VoteReport class a way to check its data value equality
            // with another VoteRecord object via the overriding of its Equals() method

            // First check constituencyName properties
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
