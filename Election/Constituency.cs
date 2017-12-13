using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Election
{
    /// <summary>
    /// Store data of XML file in a class
    /// </summary>
    public class Constituency
    {
        /// <summary>
        /// property for storing Constituency Name
        /// </summary>
        public String constituencyName { get; set; }
        /// <summary>
        /// Property for accessing objects of Class VoteReport
        /// </summary>
        public VoteReport VoteReportVotes { get; set; }

        /// <summary>
        /// Constructor that requires the Constituency Name
        /// </summary>
        /// <param name="ConstituencyName">Name of the Constituency being stored</param>
        public Constituency(String ConstituencyName)
        {
            this.constituencyName = ConstituencyName;
            this.VoteReportVotes = null;           
        }

        public override String ToString()
        {
            return constituencyName;
        }
    }
}