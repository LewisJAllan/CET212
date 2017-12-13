using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Election
{
    /// <summary>
    /// Class with the purpose of holding Constituency Class objects and running LINQ Queries
    /// </summary>
    public class ConstituencyList
    {
        /// <summary>
        /// Generic List holding objects of Class Constituency
        /// </summary>
        public List<Constituency> constituency { get; set; }

        /// <summary>
        /// Constructor that requires no parameters
        /// </summary>
        public ConstituencyList()
        {
            constituency = new List<Constituency>();
        }
        /// <summary>
        /// A method for getting LINQ Queries back to the FormBasedUI by accessing objects of Class DataMeasure through a generic List
        /// </summary>
        /// <param name="reportType">Name of LINQ Query case to be passed intop method</param>
        /// <returns>Candidates in a list satisfying the Query</returns>
        public List<DataMeasure> data(String reportType)
        {
            //create an object of List<DataMeasure>
            List<DataMeasure> constMeasure = new List<DataMeasure>();
            switch (reportType)
            {
                //To tally the votes of all parties despite which Constituency they are from
                case "Votes":
                    var constList = from cons in constituency
                                    from measures in cons.VoteReportVotes.constituencyTotalVotes
                                    group measures by measures.PartyName into measure
                                    select measure;
                    foreach (var measure in constList)
                    {
                        constMeasure.Add(new DataMeasure(measure.Key, (from m in measure select m.Votes).Sum()));
                    }
                    return constMeasure.ToList();

                //LINQ Query for finding the overall Party Winner, the party with the most votes
                case "PartyWinner":
                    List<DataMeasure> partyWinner = new List<DataMeasure>();
                    List<DataMeasure> winner = new List<DataMeasure>();
                    var candWin = from cand in constituency
                                  from measures in cand.VoteReportVotes.constituencyTotalVotes
                                  group measures by measures.PartyName into measure
                                  select measure;

                    foreach (var measure in candWin)
                    {
                        partyWinner.Add(new DataMeasure(measure.Key, (from m in measure select m.Votes).Sum()));
                    }

                    foreach (var cand in partyWinner)
                    {
                        if (!winner.Any())
                        {
                            winner.Add(cand);
                        }
                        if (cand.Votes > winner[0].Votes)
                        {
                            winner.Clear();
                            winner.Add(cand);
                        }
                    }

                    return winner.ToList();

                default:
                    return null;
            }
        }
        /// <summary>
        /// A method for getting LINQ Queries back to the FormBasedUI by accessing objects of Class DataMeasure through a generic List
        /// </summary>
        /// <param name="reportType">Name of LINQ Query case to be passed intop method</param>
        /// <returns>Candidates in a list satisfying the Query</returns>
        public List<DataMeasureCandidate> dataCand(String reportType)
        {
            switch (reportType)
            {
                //Show all candidates despite the constituency
                case "Candidates":
                    List<DataMeasureCandidate> candidatesAll = new List<DataMeasureCandidate>();
                    var candList = from cand in constituency
                                   from measures in cand.VoteReportVotes.candidateInformation
                                   select measures;
                    foreach (var measure in candList)
                    {
                        candidatesAll.Add(measure);
                    }

                    return candidatesAll.ToList();
                //Show the candidate with the most votes
                case "ElectionWinner":
                    List<DataMeasureCandidate> candidatesWinner = new List<DataMeasureCandidate>();
                    List<DataMeasureCandidate> winner = new List<DataMeasureCandidate>();
                    var candWin = from cand in constituency
                                  from measure in cand.VoteReportVotes.candidateInformation
                                  select measure;

                    foreach (var measure in candWin)
                    {
                        candidatesWinner.Add(measure);
                    }

                    foreach (var cand in candidatesWinner)
                    {
                        if (!winner.Any())
                        {
                            winner.Add(cand);
                        }
                        if (cand.Votes > winner[0].Votes)
                        {
                            winner.Clear();
                            winner.Add(cand);
                        }
                    }

                    return winner.ToList();

                default:
                    return null;
            }
        }
        /// <summary>
        /// A method for getting LINQ Queries back to the FormBasedUI by accessing objects of Class DataMeasure through a generic List
        /// </summary>
        /// <param name="reportType">Name of LINQ Query case to be passed intop method</param>
        /// <param name="conName">Name of selected Constituency</param>
        /// <returns>Candidates in a list satisfying the Query</returns>
        public List<DataMeasureCandidate> dataCon(String reportType, String conName)
        {
            switch (reportType)
            {
                //Show the candidate with the most votes in the selected constituency (passed through from FormsBasedUI as a parameter)
                case "ConstituencyWinner":
                    List<DataMeasureCandidate> constituencyWinner = new List<DataMeasureCandidate>();
                    List<DataMeasureCandidate> champ = new List<DataMeasureCandidate>();
                    var conWin = from con in constituency
                                 from measures in con.VoteReportVotes.candidateInformation
                                 where con.constituencyName == conName
                                 select measures;

                    foreach (var measure in conWin)
                    {
                        constituencyWinner.Add(measure);
                    }

                    foreach (var cand in constituencyWinner)
                    {
                        if (!champ.Any())
                        {
                            champ.Add(cand);
                        }
                        if (cand.Votes > champ[0].Votes)
                        {
                            champ.Clear();
                            champ.Add(cand);
                        }
                    }

                    return champ.ToList();
                //Show all candidates from the selected constituency
                case "ConstituencyCandidates":
                    List<DataMeasureCandidate> candidatesAll = new List<DataMeasureCandidate>();
                    var candList = from cand in constituency
                                   from measures in cand.VoteReportVotes.candidateInformation
                                   where cand.constituencyName == conName
                                   select measures;
                    foreach (var measure in candList)
                    {
                        candidatesAll.Add(measure);
                    }

                    return candidatesAll.ToList();

                default:
                    return null;
            }
        }
        /// <summary>
        /// A method for getting LINQ Queries back to the FormBasedUI by accessing objects of Class DataMeasure through a generic List
        /// </summary>
        /// <param name="reportType">Name of LINQ Query case to be passed intop method</param>
        /// <returns>Candidates in a list satisfying the Query</returns>
        public List<DataMeasureCandidateExt> dataCon(String reportType)
        {
            int num = 0;
            switch (reportType)
            {
                //the winner of each constituency with information of their constituency
                case "ElectedCandidates":
                    List<DataMeasureCandidateExt> candidatesElected = new List<DataMeasureCandidateExt>();
                    List<DataMeasureCandidateExt> elected = new List<DataMeasureCandidateExt>();
                    var canElect = from cand in constituency
                                   from measured in cand.VoteReportVotes.candidateInfoExt
                                   select measured;

                    foreach (var measure in canElect)
                    {
                        candidatesElected.Add(measure);
                    }

                    foreach (var cand in candidatesElected)
                    {                        
                        if (!elected.Any())
                        {
                            elected.Add(cand);
                        }
                        else
                        {
                            if (cand.ConstituencyName == elected[num].ConstituencyName)
                            {
                                if (cand.Votes > elected[num].Votes)
                                {
                                    elected.RemoveAt(num);
                                    elected.Add(cand);
                                }
                            }
                            else if (cand.ConstituencyName != elected[num].ConstituencyName)
                            {
                                elected.Add(cand);
                                num++;
                            }
                        }                        
                    }

                    return elected.ToList();

                default:
                    return null;
            }
        }
    }
}
