using IndianStateAnalyser.POCO;
using IndianStateAnalyser;

namespace CensusAnalyserTest
{
    [TestClass]
    public class IndianCensusTestClass
    {
        string stateCodePath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\StateCode.csv";
        string stateCensusPath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\StateCensusData.csv";
        string wrongCensusPath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\StateCensusData.csv";
        string wrongStateCodePath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\StateCode.csv";
        string wrongTypeStateCodePath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\StateCode.txt";
        string wrongHeaderStateCodePath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\WorngStateCode.csv";
        string wrongHeaderStateCensusPath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\WorngStateCensusData.csv";
        string delimiterStateCodePath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\DelimiterStateCode.csv";
        string delimiterStateCensusPath = @"C:\Users\Achal\source\repos\IndianStateAnalyser\CensusAnalyserTest\Census\DelemiterStateCensusData.csv";
        public CSVAdapterFactory csv;
        public Dictionary<string, CensusDataDAO> stateRecords;
        public Dictionary<string, StateCodeDAO> totalRecords;
        [TestInitialize]
        public void SetUp()
        {
            csv = new CSVAdapterFactory();
            totalRecords = new Dictionary<string, StateCodeDAO>();
            stateRecords = new Dictionary<string, CensusDataDAO>();
        }
        [TestMethod]
        public void GivenStateCensusCSVFileShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
        /// TC 1.2
       
        [TestMethod]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
               
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.3
        
        [TestMethod]
        public void GivenWrongTypeReturnsCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
                Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.4
        
        [TestMethod]
        public void GivenWrongDelimeterReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.5
        
        [TestMethod]
        public void GivenWrongHeaderReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 2.1
        
        [TestMethod]
        public void GivenStateCode_CSVFile_ShouldReturn_RecordsCount()
        {
            //totalRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, totalRecords.Count);
        }
        /// TC 2.2
       
        [TestMethod]
        public void GivenIncorrectPathCodeCustomException()
        {
            var stateCustomException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateCustomException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 2.3
        
        [TestMethod]
        public void GivenIncorrectPathTypeCodeReturnException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        /// TC 2.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [TestMethod]
        public void GivenWrongHeaderStateCodeReturnCustomException()
        {
            var stateException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        /// TC 2.5
        /// Giving wrong header type should return incorrect header type custom exception
        [TestMethod]
        public void GivenWrongDelimiterCodeReturnCustomException()
        {
            var stateException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }

    }
}