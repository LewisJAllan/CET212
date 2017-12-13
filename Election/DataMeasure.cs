using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// Class holding information read from XML file
    /// </summary>
    public class DataMeasure
    {
        /// <summary>
        /// Property holding the partyname the candidate is representing
        /// </summary>
        public String PartyName { get; private set; }
        /// <summary>
        /// The amount of votes the candidate has received 
        /// </summary>
        public double Votes { get; private set; }
        /// <summary>
        /// Constructor taking two parameters 
        /// </summary>
        /// <param name="partyname">parameter for passing in the candidates party</param>
        /// <param name="votes">the candidates total votes</param>
        public DataMeasure(String partyname, double votes)
        {
            this.PartyName = partyname;
            this.Votes = votes;
        }

        public override String ToString()
        {
            return String.Format("{0}: {1}", PartyName, Votes);
        }
    }
}
