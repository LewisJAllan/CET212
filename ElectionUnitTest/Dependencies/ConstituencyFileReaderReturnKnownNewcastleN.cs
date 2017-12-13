using System;
using Election;
using ElectionUnitTest.Helpers;

namespace ElectionUnitTest.Dependencies
{
    public class ConstituencyFileReaderReturnKnownNewcastleN : IConstituencyFileReader
    {
        public Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord)
        {
            // Use helper class to get a known Newcastle North.xml instance
            return Helper_KnownConstituencyDataRepository.GetKnownNewcastleN();
        }
    }
}
