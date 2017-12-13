using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Election
{
    public class XMLConstituencyFileReader : IConstituencyFileReader
    {
        public Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord)
        {
            // Open the file to read from on the local file system.
            // If this file is missing then return immediately from this method.

            if (!File.Exists(configRecord.Filename))
            {
                // Cannot open the file as it does not exist for whatever reason, so return immediately.
                return null;
            }

            // Open file and load into memory as XML
            XDocument xmlDoc = XDocument.Load(configRecord.Filename);

            // Create constituency (should only be one in file but retrieve first to be sure)
            var constituencyName = (from c in xmlDoc.Descendants("Constituency")
                                    select c.Attribute("name").Value).First();

            Constituency constituency = new Constituency(constituencyName);
            //ConstituencyList constituencyList;

            // Create Vote report for this constituency
            constituency.VoteReportVotes = new VoteReport();

            // Retrieve data for measures and add to fit report
            // Local helper method used to select measures via LINQ query on XML document
            constituency.VoteReportVotes.constituencyTotalVotes = SelectDataMeasure(xmlDoc);
            constituency.VoteReportVotes.candidateInformation = SelectDataMeasureCand(xmlDoc);
            constituency.VoteReportVotes.candidateInfoExt = SelectDataMeasureCandExt(xmlDoc);

            return constituency;
           
        }
        /// <summary>
        /// pass the required information from the XML Files to different DataMeasure classes for LINQ Queries and specific presentation formats
        /// </summary>
        /// <param name="xmlDoc">name of XDocument parameter</param>
        /// <returns>Generic List of DataMeasure </returns>
        private List<DataMeasure> SelectDataMeasure(XDocument xmlDoc)
        {
            var measures = from constit in xmlDoc.Root.Descendants("Constituency")
                           from measure in constit.Descendants("Candidate")
                           select new DataMeasure(measure.Attribute("party").Value, Convert.ToDouble(measure.Element("Votes").Value));
            return measures.ToList();
        }
        /// <summary>
        ///  pass the required information from the XML Files to different DataMeasure classes for LINQ Queries and specific presentation formats
        /// </summary>
        /// <param name="xmlDoc">name of XDocument parameter</param>
        /// <returns>Generic List of DataMeasureCandidate</returns>
        private List<DataMeasureCandidate> SelectDataMeasureCand(XDocument xmlDoc)
        {
            var measures = from constit in xmlDoc.Root.Descendants("Constituency")
                           from measure in constit.Descendants("Candidate")
                           select new DataMeasureCandidate(measure.Attribute("party").Value, measure.Element("Firstname").Value, 
                           measure.Element("Lastname").Value, Convert.ToDouble(measure.Element("Votes").Value));
            return measures.ToList();
        }
        /// <summary>
        ///  pass the required information from the XML Files to different DataMeasure classes for LINQ Queries and specific presentation formats
        /// </summary>
        /// <param name="xmlDoc">name of XDocument file</param>
        /// <returns>Generic list of DataMeasureCandidateExt</returns>
        private List<DataMeasureCandidateExt> SelectDataMeasureCandExt(XDocument xmlDoc)
        {
            var measures = from constit in xmlDoc.Root.Descendants("Constituency")
                           from measure in constit.Descendants("Candidate")
                           select new DataMeasureCandidateExt(constit.Attribute("name").Value, measure.Attribute("party").Value, measure.Element("Firstname").Value,
                           measure.Element("Lastname").Value, Convert.ToDouble(measure.Element("Votes").Value));
            return measures.ToList();
        }
    }
}
