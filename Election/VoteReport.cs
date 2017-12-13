using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class VoteReport
    {
        /// <summary>
        /// Generic List hold DataMeasure information
        /// </summary>
        public List<DataMeasure> constituencyTotalVotes { get; set; }
        /// <summary>
        /// Generic List holding DataMeasureCandidate Information
        /// </summary>
        public List<DataMeasureCandidate> candidateInformation { get; set; }
        /// <summary>
        /// Generic List holding DataMeasureCandidateExt information
        /// </summary>
        public List<DataMeasureCandidateExt> candidateInfoExt { get; set; }
        /// <summary>
        /// constructor setting above properties to null
        /// </summary>
        public VoteReport()
        {
            this.constituencyTotalVotes = null;
            this.candidateInformation = null;
            this.candidateInfoExt = null;
        }

        public override String ToString()
        {
            String str = String.Format("Votes: ");

            foreach (var c in constituencyTotalVotes)
            {
                str += String.Format("\n\t\t{0}", c.ToString());
                
            }

            return String.Format("Vote Report - {0}", str);
        }
    }
}
