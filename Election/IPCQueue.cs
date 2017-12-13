using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// public interface connecting the Work, Producer and Consumer classes with the sharing methods
    /// </summary>
    public interface IPCQueue
    {
        void enqueueItem(Work item);
        Work dequeueItem();
    }
}
