using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// user interface to share information passed in and out of the FormBasedUI.cs
    /// </summary>
    public interface IUserInterface
    {
        void SetupConfigData();
        void RunProducerConsumer();
        void DisplayResults();
    }
}
