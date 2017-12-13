using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    class MissingInformationException : Exception
    {
        //set output method for when e.Message is called for example
        private static String msg = "Please select a constituency before continuing";

        //call original msg from Exception class to be used for this subclass
        /// <summary>
        /// using original exception message to output created exceptions message
        /// </summary>
        public MissingInformationException()
            : base(msg)
        {
            //any additional code to go here otherwise leave blank
        }
    }
}
