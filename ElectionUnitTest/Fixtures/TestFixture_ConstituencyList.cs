using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Election;
using TestedClass = Election.ConstituencyList;
using ElectionUnitTest.Helpers;

namespace ElectionUnitTest.Fixtures
{
    [TestClass]
    public class TestFixture_ConstituencyList
    {
        [TestMethod]
        public void Test_data_Method_Invalid_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // Invalid report type asked for so should return null
            var actualDataMeasuresList = testedClass.data("INVALID");

            // Assert
            // Actual data measures list should be null
            Assert.IsNull(actualDataMeasuresList);
        }
        [TestMethod]
        public void Test_dataCon_Method_Invalid_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // Invalid report type asked for so should return null
            var actualDataMeasuresList = testedClass.dataCon("INVALID");

            // Assert
            // Actual data measures list should be null
            Assert.IsNull(actualDataMeasuresList);
        }
        [TestMethod]
        public void Test_dataCand_Method_Invalid_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // Invalid report type asked for so should return null
            var actualDataMeasuresList = testedClass.dataCand("INVALID");

            // Assert
            // Actual data measures list should be null
            Assert.IsNull(actualDataMeasuresList);
        }

        [TestMethod]
        public void Test_data_Method_No_Constiuency_Votes_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // No constituencies in the list so expected to return an empty data measures list
            var actualDataMeasuresList = testedClass.data("Votes");

            // Assert
            // Actual data measures list should be empty
            Assert.AreEqual(0, actualDataMeasuresList.Count);
        }

        [TestMethod]
        public void Test_data_Method_No_Constituency_PartyWinner_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // No constituencies in the list so expected to return an empty data measures list
            var actualDataMeasuresList = testedClass.data("PartyWinner");

            // Assert
            // Actual data measures list should be empty
            Assert.AreEqual(0, actualDataMeasuresList.Count);
        }
        [TestMethod]
        public void Test_dataCand_Method_No_Constituency_Candidates_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // No constituencies in the list so expected to return an empty data measures list
            var actualDataMeasuresList = testedClass.dataCand("Candidates");

            // Assert
            // Actual data measures list should be empty
            Assert.AreEqual(0, actualDataMeasuresList.Count);
        }
        [TestMethod]
        public void Test_dataCand_Method_No_Constituency_ElectionWinner_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // No constituencies in the list so expected to return an empty data measures list
            var actualDataMeasuresList = testedClass.dataCand("ElectionWinner");

            // Assert
            // Actual data measures list should be empty
            Assert.AreEqual(0, actualDataMeasuresList.Count);
        }
        [TestMethod]
        public void Test_dataCon_Method_No_Constituency_ConstituencyWinner_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // No constituencies in the list so expected to return an empty data measures list
            var actualDataMeasuresList = testedClass.dataCon("ConstituencyWinner");

            // Assert
            // Actual data measures list should be empty
            Assert.AreEqual(0, actualDataMeasuresList.Count);
        }
        [TestMethod]
        public void Test_dataCon_Method_No_Constituency_ElectedCandidates_Report()
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Act
            // No constituencies in the list so expected to return an empty data measures list
            var actualDataMeasuresList = testedClass.dataCon("ElectedCandidates");

            // Assert
            // Actual data measures list should be empty
            Assert.AreEqual(0, actualDataMeasuresList.Count);
        }
        [TestMethod]
        public void Test_data_Method_Three_Constituency_Votes_Report()
        {
            Helper_Test_data_Method_Three_Constituency("Votes", Helper_KnownConstituencyDataRepository.GetVotes());
        }

        [TestMethod]
        public void Test_data_Method_Three_Constituency_PartyWinner_Report()
        {
            Helper_Test_data_Method_Three_Constituency("PartyWinner", Helper_KnownConstituencyDataRepository.GetPartyWinner());
        }

        [TestMethod]
        public void Test_dataCand_Method_Three_Constituency_Candidates_Report()
        {
            Helper_Test_dataCand_Method_Three_Constituency1("Candidates", Helper_KnownConstituencyDataRepository.GetCandidates());
        }
        [TestMethod]
        public void Test_dataCand_Method_Three_Constituency_ElectionWinner_Report()
        {
            Helper_Test_dataCand_Method_Three_Constituency1("ElectionWinner", Helper_KnownConstituencyDataRepository.GetElectionWinner());
        }
        [TestMethod]
        public void Test_dataCon_Method_Three_Constituency_ElectedCandidates_Report()
        {
            Helper_Test_dataCon_Method_Three_Constituency2("ElectedCandidates", Helper_KnownConstituencyDataRepository.GetElectedCandidates());
        }
        private void Helper_Test_data_Method_Three_Constituency(string reportType, List<DataMeasure> expectedDataMeasuresList)
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Add the three constituencies to the list
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownMiddlesbrough());
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownNewcastleN());
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownSunderlandN());

            // Act
            // Has constituencies in the list so expected to return an populated data measures list
            var actualDataMeasuresList = testedClass.data(reportType);

            // Assert
            // Expected data measures list should contain the same number of items as the actual data measures list
            Assert.AreEqual(expectedDataMeasuresList.Count, actualDataMeasuresList.Count);

            // Each expected data measure should be equal to the actual data measure, note that the values are given
            // an accuracy of 4 decimal places to ensure they can be deemed equal (due to rounding)
            for (int i = 0; i < expectedDataMeasuresList.Count; i++)
            {
                Assert.AreEqual(expectedDataMeasuresList[i].PartyName, actualDataMeasuresList[i].PartyName);
                Assert.AreEqual(expectedDataMeasuresList[i].Votes, actualDataMeasuresList[i].Votes, 0.0001);
            }
        }
        private void Helper_Test_dataCand_Method_Three_Constituency1(string reportType, List<DataMeasureCandidate> expectedDataMeasuresList)
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Add the three constituencies to the list
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownMiddlesbrough());
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownNewcastleN());
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownSunderlandN());

            // Act
            // Has constituencies in the list so expected to return an populated data measures list
            var actualDataMeasuresList = testedClass.dataCand(reportType);

            // Assert
            // Expected data measures list should contain the same number of items as the actual data measures list
            Assert.AreEqual(expectedDataMeasuresList.Count, actualDataMeasuresList.Count);

            // Each expected data measure should be equal to the actual data measure, note that the values are given
            // an accuracy of 4 decimal places to ensure they can be deemed equal (due to rounding)
            for (int i = 0; i < expectedDataMeasuresList.Count; i++)
            {
                Assert.AreEqual(expectedDataMeasuresList[i].PartyName, actualDataMeasuresList[i].PartyName);
                Assert.AreEqual(expectedDataMeasuresList[i].Firstname, actualDataMeasuresList[i].Firstname);
                Assert.AreEqual(expectedDataMeasuresList[i].Lastname, actualDataMeasuresList[i].Lastname);
                Assert.AreEqual(expectedDataMeasuresList[i].Votes, actualDataMeasuresList[i].Votes, 0.0001);
            }
        }
        private void Helper_Test_dataCon_Method_Three_Constituency2(string reportType, List<DataMeasureCandidateExt> expectedDataMeasuresList)
        {
            // Arrange
            // Instantiate a ConstituencyList object
            var testedClass = new TestedClass();

            // Add the three constituencies to the list
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownMiddlesbrough());
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownNewcastleN());
            testedClass.constituency.Add(Helper_KnownConstituencyDataRepository.GetKnownSunderlandN());

            // Act
            // Has constituencies in the list so expected to return an populated data measures list
            var actualDataMeasuresList = testedClass.dataCon(reportType);

            // Assert
            // Expected data measures list should contain the same number of items as the actual data measures list
            Assert.AreEqual(expectedDataMeasuresList.Count, actualDataMeasuresList.Count);

            // Each expected data measure should be equal to the actual data measure, note that the values are given
            // an accuracy of 4 decimal places to ensure they can be deemed equal (due to rounding)
            for (int i = 0; i < expectedDataMeasuresList.Count; i++)
            {
                Assert.AreEqual(expectedDataMeasuresList[i].ConstituencyName, actualDataMeasuresList[i].ConstituencyName);
                Assert.AreEqual(expectedDataMeasuresList[i].PartyName, actualDataMeasuresList[i].PartyName);
                Assert.AreEqual(expectedDataMeasuresList[i].Firstname, actualDataMeasuresList[i].Firstname);
                Assert.AreEqual(expectedDataMeasuresList[i].Lastname, actualDataMeasuresList[i].Lastname);
                Assert.AreEqual(expectedDataMeasuresList[i].Votes, actualDataMeasuresList[i].Votes, 0.0001);
            }
        }
    }
}
