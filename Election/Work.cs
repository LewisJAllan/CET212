using System;

namespace Election
{
    public class Work
    {
        public ConfigRecord configRecord { get; private set; } // Data used when this work is processed - config record
        private IConstituencyFileReader IOhandler; // Data used when this work is processed - config record
        public Constituency constituency { get; private set; }  // Result of the work, when null indicates that the work has not yet
                                                      // been completed, note this is a read-only property

        public Work(ConfigRecord data, IConstituencyFileReader IOhandler) //extra param for IconstituencyIO
        {
            constituency = null; // Result of the work is initially null, this shows that the work has not yet been completed
            this.configRecord = data; // Data is initialised when the work is instantiated
            this.IOhandler = IOhandler;
        }
        /// <summary>
        /// // Reads the specified file and extracts the constituency data from it to store in a constituency object.
        /// </summary>
        /// <returns>Constituency</returns>
        public Constituency ReadData()
        {
            // Note that result remains null until this method is executed
            return IOhandler.ReadConstituencyDataFromFile(configRecord);
        }
    }
}
