using System.Collections.Generic;
using Election;

namespace ElectionUnitTest.Helpers
{
    public static class Helper_KnownConstituencyDataRepository
    {
        public static Constituency GetKnownMiddlesbrough()
        {
            // Build a know constituency object and return this for use in various test methods
            var constituency = new Constituency("Middlesbrough");

            // Instantiate the fit reports in the constituency, including data measure lists
            constituency.VoteReportVotes = new VoteReport();
            constituency.VoteReportVotes.constituencyTotalVotes = new List<DataMeasure>();
            constituency.VoteReportVotes.candidateInformation = new List<DataMeasureCandidate>();
            constituency.VoteReportVotes.candidateInfoExt = new List<DataMeasureCandidateExt>();

            // Build a known report for this known constituency (selection of data from Middlesbrough.xml)
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Green", 145.0));
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Conservative", 130.0));
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Labour", 150.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Green", "Jordan", "Williams", 145.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Conservative", "Natasha", "Shields", 130.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Labour", "Dylan", "Corn", 150.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Middlesbrough", "Green", "Jordan", "Williams", 145.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Middlesbrough", "Conservative", "Natasha", "Shields", 130.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Middlesbrough", "Labour", "Dylan", "Corn", 150.0));

            return constituency;
        }

        public static Constituency GetKnownNewcastleN()
        {
            // Build a know constituency object and return this for use in various test methods
            var constituency = new Constituency("Newcastle North");

            // Instantiate the fit reports in the constituency, including data measure lists
            constituency.VoteReportVotes = new VoteReport();
            constituency.VoteReportVotes.constituencyTotalVotes = new List<DataMeasure>();
            constituency.VoteReportVotes.candidateInformation = new List<DataMeasureCandidate>();
            constituency.VoteReportVotes.candidateInfoExt = new List<DataMeasureCandidateExt>();

            // Build a known initial fit report for this known constituency (selection of data from Newcastle North.xml)
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("BNP", 155.0));
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Green", 115.0));
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Labour", 150.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("BNP", "Joe", "Kinnear", 155.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Green", "Rachael", "Lewis", 115.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Labour", "Brett", "New", 150.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Newcastle North", "BNP", "Joe", "Kinnear", 155.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Newcastle North", "Green", "Rachael", "Lewis", 115.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Newcastle North", "Labour", "Brett", "New", 150.0));

            return constituency;
        }

        public static Constituency GetKnownSunderlandN()
        {
            // Build a know constituency object and return this for use in various test methods
            var constituency = new Constituency("Sunderland North");

            // Instantiate the fit reports in the constituency, including data measure lists
            constituency.VoteReportVotes = new VoteReport();
            constituency.VoteReportVotes.constituencyTotalVotes = new List<DataMeasure>();
            constituency.VoteReportVotes.candidateInformation = new List<DataMeasureCandidate>();
            constituency.VoteReportVotes.candidateInfoExt = new List<DataMeasureCandidateExt>();

            // Build a known initial fit report for this known constituency (selection of data from Sunderland North.xml)
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Conservative", 135.0));
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Green", 200.0));
            constituency.VoteReportVotes.constituencyTotalVotes.Add(new DataMeasure("Labour", 250.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Conservative", "Fred", "Bloggs", 135.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Green", "Jane", "Smith", 200.0));
            constituency.VoteReportVotes.candidateInformation.Add(new DataMeasureCandidate("Labour", "John", "Smith", 250.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Sunderland North", "Conservative", "Fred", "Bloggs", 135.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Sunderland North", "Green", "Jane", "Smith", 200.0));
            constituency.VoteReportVotes.candidateInfoExt.Add(new DataMeasureCandidateExt("Sunderland North", "Labour", "John", "Smith", 250.0));

            return constituency;
        }
        //set expected results of methods called
        public static List<DataMeasure> GetVotes()
        {
            var list = new List<DataMeasure>();

            list.Add(new DataMeasure("Green", 460.0));
            list.Add(new DataMeasure("Conservative", 265.0));
            list.Add(new DataMeasure("Labour", 550.0));
            list.Add(new DataMeasure("BNP", 155.0));

            return list;
        }

        public static List<DataMeasure> GetPartyWinner()
        {
            var list = new List<DataMeasure>();

            list.Add(new DataMeasure("Labour", 550.0));

            return list;
        }

        public static List<DataMeasureCandidate> GetCandidates()
        {
            var list = new List<DataMeasureCandidate>();
            list.Add(new DataMeasureCandidate("Green", "Jordan", "Williams", 145.0));
            list.Add(new DataMeasureCandidate("Conservative", "Natasha", "Shields", 130.0));
            list.Add(new DataMeasureCandidate("Labour", "Dylan", "Corn", 150.0));
            list.Add(new DataMeasureCandidate("BNP", "Joe", "Kinnear", 155.0));
            list.Add(new DataMeasureCandidate("Green", "Rachael", "Lewis", 115.0));
            list.Add(new DataMeasureCandidate("Labour", "Brett", "New", 150.0));
            list.Add(new DataMeasureCandidate("Conservative", "Fred", "Bloggs", 135.0));
            list.Add(new DataMeasureCandidate("Green", "Jane", "Smith", 200.0));
            list.Add(new DataMeasureCandidate("Labour", "John", "Smith", 250.0));

            return list;
        }
        public static List<DataMeasureCandidate> GetElectionWinner()
        {
            var list = new List<DataMeasureCandidate>();

            list.Add(new DataMeasureCandidate("Labour", "John", "Smith", 250.0));

            return list;
        }
        public static List<DataMeasureCandidateExt> GetElectedCandidates()
        {
            var list = new List<DataMeasureCandidateExt>();
            list.Add(new DataMeasureCandidateExt("Middlesbrough", "Labour", "Dylan", "Corn", 150.0));
            list.Add(new DataMeasureCandidateExt("Newcastle North", "BNP", "Joe", "Kinnear", 155.0));
            list.Add(new DataMeasureCandidateExt("Sunderland North", "Labour", "John", "Smith", 250.0));

            return list;
        }
    }
}
