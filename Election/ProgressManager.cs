using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// class to manage items being used by the Consumer class
    /// </summary>
    public class ProgressManager
    {
        private int itemsRemaining;
        public int ItemsRemaining // Property getter/setter methods
        {
            get
            {
                return itemsRemaining;
            }

            set
            {
                lock (this)
                {
                    // MUTEX control for potential multiple thread access to this property
                    itemsRemaining = value;
                }
            }
        }
        /// <summary>
        /// Constructor with no parameters
        /// </summary>
        public ProgressManager()
        {
            this.ItemsRemaining = 0;
        }
        /// <summary>
        /// constructor taking in one parameter
        /// </summary>
        /// <param name="items">number of files still remaining</param>
        public ProgressManager(int items)
        {
            this.ItemsRemaining = items;
        }
    }
}
