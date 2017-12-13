using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    /// <summary>
    /// interface connecting the method from XMLConstituencyFileReader to the Work Class
    /// </summary>
    public interface IConstituencyFileReader
    {
        Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord);
    }
}
