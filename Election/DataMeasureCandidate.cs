using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// Class holding information read from an XML file
    /// </summary>
    public class DataMeasureCandidate
    {
        /// <summary>
        /// Property holding the partyname the candidate is representing
        /// </summary>
        public String PartyName { get; private set; }
        /// <summary>
        /// Property holding the Candidates first name
        /// </summary>
        public String Firstname { get; private set; }
        /// <summary>
        /// property holding the candidates lastname
        /// </summary>
        public String Lastname { get; private set; }
        /// <summary>
        /// Property holding Candidates Total votes
        /// </summary>
        public double Votes { get; private set; }
        /// <summary>
        /// Constructor taking four parameters
        /// </summary>
        /// <param name="partyname">requires partyname to passed into constructor</param>
        /// <param name="firstname">First name of candidate required</param>
        /// <param name="lastname">Lastname of candidate required</param>
        /// <param name="votes">total votes for candidate required</param>
        public DataMeasureCandidate(String partyname, String firstname, String lastname, double votes)
        {
            this.PartyName = partyname;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Votes = votes;
        }

        public override String ToString()
        {
            return String.Format("{0}: {1}, {2} - {3}", PartyName, Lastname, Firstname, Votes);
        }
    }
    /// <summary>
    /// Subclass of DataMeasureCandidate requiring one more piece of information
    /// </summary>
    public class DataMeasureCandidateExt : DataMeasureCandidate
    {
        /// <summary>
        /// The constituency name the candidate is part of
        /// </summary>
        public String ConstituencyName { get; private set; }
        /// <summary>
        /// Extended constructor needing 5 parameters
        /// </summary>
        /// <param name="constituencyName">name of the constituency the candidate is part of</param>
        /// <param name="Partyname">party the candidate represents</param>
        /// <param name="FirstName">first name of the candidate</param>
        /// <param name="Lastname">last name of the candidate</param>
        /// <param name="Votes">total votes for the candidate</param>
        public DataMeasureCandidateExt(String constituencyName, String Partyname, String FirstName, String Lastname, double Votes) : base(Partyname, FirstName, Lastname, Votes)
        {
            this.ConstituencyName = constituencyName;
        }

        public override string ToString()
        {
            return ConstituencyName + " " + base.ToString();
        }
    }
}
