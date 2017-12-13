using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// Holds list of data from COnfig Record to iterate through
    /// </summary>
    public class ConfigData
    {
        /// <summary>
        /// Property holding Generic List of ConfigRecords
        /// </summary>
        public List<ConfigRecord> configRecords { get; set; }
        /// <summary>
        /// property for moving to the next record in list
        /// </summary>
        public int NextRecord { get; set; }
        /// <summary>
        /// constructor with no parameters
        /// </summary>
        public ConfigData()
        {
            this.NextRecord = 0;
            configRecords = new List<ConfigRecord>();
        }
    }
}