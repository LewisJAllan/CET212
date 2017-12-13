using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// Class for holding XML file records
    /// </summary>
    public class ConfigRecord
    {
        /// <summary>
        /// property for holding XML Filename
        /// </summary>
        public String Filename { get; private set; }
        /// <summary>
        /// Constructor requiring Filename to be passed when called
        /// </summary>
        /// <param name="Filename">Name of XML file</param>
        public ConfigRecord(String Filename)
        {
            this.Filename = Filename;
        }

        public override String ToString()
        {
            return String.Format("{0}", Filename);
        }

    }
}
