using IndianStateAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateAnalyser
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDataDAO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            try
            {
                switch (country)
                {
                    case CensusAnalyser.Country.INDIA:
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
                }
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
