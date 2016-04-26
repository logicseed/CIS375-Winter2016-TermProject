///<Author>Rodney Lewis</Author>
using IceCreamManager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IceCreamManager.Controller
{
    //TODO list: 
    // Add comments for functions
    // Add logging messages
    // Finish sales and truck upload, applying the data and checking if it's in default
    // Move more repeated variables to BatchFileProcessing
    public class BatchFileProcessing
    {
        protected ItemFactory itemAction = ItemFactory.Reference;
        protected CityFactory cityAction = CityFactory.Reference;
        protected DriverFactory driverAction = DriverFactory.Reference;
        protected RouteFactory routeAction = RouteFactory.Reference;
        protected TruckFactory truckAction = TruckFactory.Reference;
        protected InventoryItemFactory inventoryAction = InventoryItemFactory.Reference;

        protected string fileLine;
        protected int countedLines = 0;
        protected char trim = ' ';
        protected string extractedData;
        protected int ID;

        /// <summary>
        /// Checks if a string is a valid number by checking it's length after trimming spaces and if it can be converted into a interger or double.
        /// </summary>
        /// <param name="originalString">The string that will be parsed</param>
        /// <param name="numberOfCharacters">The length of the number to be extracted</param>
        /// <returns></returns>
        protected bool ZeroFillNumberCheck(string originalString, int numberOfCharacters)
        {
            string fileNumber = originalString.Substring(0, numberOfCharacters);
            fileNumber.TrimEnd(trim);
            if (fileNumber.Length == numberOfCharacters & fileNumber.All(char.IsDigit))
                return true;
            else
                return false;
        }

        protected DataType Extract<DataType>(ref string originalString, int numberOfCharacters)
        {
            var extractedString = originalString.Substring(0, numberOfCharacters);
            originalString = originalString.Remove(0, numberOfCharacters);
            return (DataType)Convert.ChangeType(extractedString, typeof(DataType));
        }
    }

    public class HeaderFooter : BatchFileProcessing
    {
        string[] recordTypes = new string[] { "IR", "TR", "SR", "T " };
        string headerRecord;
        int sequenceNumber;
        int trailerNumber;
        int countedRecords = 0;
        DateTime date;

        public bool ProcessHeaderFooter(string FilePath, BatchFileType FileType)
        {
            /// <summary>
            /// Checks the header and footer of input files. Takes the header and extracts data by columns, counts the number
            /// of records in the file, and then extracts data from footer and compares the counted number of records.       
            /// </summary>
            /// <param name="FilePath">Pathing to the input file</param>
            /// <returns>
            /// Returns true if passes all if statements and data is applied
            /// If it fails any if statement, throw an exception and returns false
            /// </returns>

            try
            {
                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();
                countedLines++;

                headerRecord = Extract<string>(ref fileLine, 3);
                headerRecord = headerRecord.TrimEnd(trim);
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    sequenceNumber = Extract<int>(ref fileLine, 10);
                }
                else
                {
                    throw new ExceptionWithOutcome($"Batch file: {FileType} - Invalid sequence number format.");
                }
                date = Extract<DateTime>(ref fileLine, 10);

                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    if (headerRecord == "HD")
                    {
                        Log.Success($"Header record found.");
                    }
                    else
                    {
                        throw new ExceptionWithOutcome($"Header record not found.");
                    }

                    if (sequenceNumber == BatchHistory.GetSequence(FileType) + 1)
                    {
                        Log.Success($"Date sequence number processed.");
                    }
                    else
                    {
                        throw new ExceptionWithOutcome($"Sequence number out of order.");
                    }

                    if (date >= BatchHistory.GetDateUpdated(FileType))
                    {
                        Log.Success($"Date processed.");
                    }
                    else
                    {
                        throw new ExceptionWithOutcome($"Date out of order.");
                    }

                    while (!file.EndOfStream)
                    {
                        fileLine = file.ReadLine();
                        if (isRecordType(fileLine))
                            countedLines++;
                        else
                        {
                            countedRecords++;
                            countedLines++;
                        }
                    }
                    extractedData = Extract<string>(ref fileLine, 2);
                    extractedData = extractedData.TrimEnd(trim);
                    fileLine = fileLine.TrimEnd(trim);
                    if (extractedData == "T")
                    {
                        trailerNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        if (trailerNumber == countedRecords)
                        {
                            BatchHistory.SetSequence(FileType, sequenceNumber);
                            BatchHistory.SetDateUpdated(FileType, date);
                            Log.Success("Successful header and footer check.");
                            file.Close();
                            return true;
                        }
                        else
                        {
                            throw new ExceptionWithOutcome("Trailer record doesn't match number of records in file.");
                        }
                    }
                    else
                    {
                        throw new ExceptionWithOutcome("Trailer record not found.");
                    }
                }
                else
                {
                    throw new ExceptionWithOutcome("Extraneous characters beyond record length");
                }
            }
            catch (Exception e)
            {
                Log.Failure($"Batch file: {FileType} - {e}");
                return false;
            }
        }

        private bool isRecordType(string line)
        {
            foreach (string element in recordTypes)
            {
                if ((line.Substring(0, 2)) == element)
                    return true;
            }
            return false;
        }
    }

    public class CityUpload : BatchFileProcessing
    {
        string cityLabel;
        string cityName;
        string state;
        double hours;
        double miles;

        private void ApplyNewCityData()
        {
            cityLabel.TrimEnd(trim);
            cityName.TrimEnd(trim);
            City newCity = new City();
            newCity.Label = cityLabel;
            newCity.Name = cityName;
            newCity.State = state;
            newCity.Save();
        }

        private void ApplyCityHoursMiles()
        {
            City cityProperties = new City();
            int id = cityAction.GetCityID(cityLabel);
            cityProperties = cityAction.Load(id);
            cityProperties.Hours = hours;
            cityProperties.Miles = miles;
            cityProperties.Save();
        }

        /// <summary>
        /// Processes City files, extracts city labels, city name, and state. Accepts these values as they are.
        ///     HD SEQ#      YYYY-MM-DD 
        ///     |------city label----||------city name-----||state|
        ///     T #ROWS  
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessCityFile(string FilePath)
        {
            cityAction.DeleteAll();
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;
            while (!file.EndOfStream || fileLine.Substring(0, 2) != "T ")
            {
                fileLine = file.ReadLine();
                countedLines++;
                cityLabel = Extract<string>(ref fileLine, Requirement.MaxCityLabelLength);
                cityName = Extract<string>(ref fileLine, Requirement.MaxCityNameLength);
                state = Extract<string>(ref fileLine, Requirement.MaxCityStateLength);

                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    ApplyNewCityData();
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.City } - Extraneous characters beyond record length, failed to add city label: {cityLabel} on line {countedLines}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.City } - Processed.");
            file.Close();
        }

        /// <summary>
        /// Processes city file extension that adds the time and distance for each city label.
        /// Checks if these labels exist in the DB, add hours and miles values if they do. Else reject line.
        ///     HD SEQ#      YYYY-MM-DD
        ///     |------city label----||Hours||Miles|
        ///     T ROWS
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessCityFileExtension(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream || fileLine.Substring(0, 2) != "T ")
            {
                fileLine = file.ReadLine();
                countedLines++;

                cityLabel = Extract<string>(ref fileLine, Requirement.MaxCityLabelLength);
                cityLabel = cityLabel.TrimEnd(trim);

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    hours = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.CityExtension } - Invalid hours format, on line: {countedLines}.");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    miles = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.CityExtension } - Invalid miles format, on line: {countedLines}.");
                    continue;
                }
                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    if (cityAction.Exists(cityLabel))
                    {
                        ApplyCityHoursMiles();
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.CityExtension } - City label does not exist, line: {countedLines}.");
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.CityExtension } - Extraneous characters beyond record length, line: {countedLines}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.CityExtension } - Processed.");
            file.Close();
        }


    }

    public class RouteUpload : BatchFileProcessing
    {
        char actionCode;
        int routeNumber;
        List<string> routeComposition = new List<string>();

        private void ExtractCityLabels()
        {
            for (int i = 0; i < Requirement.MaxRouteCities; i++)
            {
                string cityLabel = Extract<string>(ref fileLine, Requirement.MaxCityLabelLength);
                cityLabel = cityLabel.TrimEnd(trim);

                if (cityAction.Exists(cityLabel))
                {
                    routeComposition.Add(cityLabel);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Route } - City Label doesn't exist, on line: {countedLines}.");
                    routeComposition.Clear();
                    return;
                }
            }
        }

        private void ApplyCityLabels(int routeNumber)
        {
            Route newRoute = new Route();
            newRoute.Number = routeNumber;
            for (int i = 0; i < routeComposition.Count(); i++)
            {
                ID = cityAction.GetCityID(routeComposition[i]);
                City oldCity = cityAction.Load(ID);
                newRoute.AddCity(oldCity);
            }
            newRoute.Save();
        }
        /// <summary>
        /// Processes route files
        ///     HD SEQ#      YYYY-MM-DD    
        ///     |action code||Route Number||-----city label-----|*10
        ///     T #ROWS
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessRouteFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                actionCode = Extract<char>(ref fileLine, 1);

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    routeNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Route } - Invalid route number format, on line: {countedLines}.");
                    continue;
                }

                if (routeAction.NumberInUse(routeNumber)) //Does this routeNumber exist in the DB
                {
                    if (actionCode == 'C')
                    {
                        ExtractCityLabels();
                        fileLine = fileLine.TrimEnd(trim);
                        if (fileLine == "")
                        {
                            ID = routeAction.GetID(routeNumber);
                            routeAction.Delete(ID);
                            ApplyCityLabels(routeNumber); //Apply cityLabels
                        }
                        else
                        {
                            Log.Failure($"Batch file: { BatchFileType.Route } - Extraneous characters beyond record length, on line: {countedLines}.");
                        }
                    }
                    else if (actionCode == 'D')
                    {
                        fileLine = fileLine.TrimEnd(trim);
                        if (fileLine == "")
                        {
                            ID = routeAction.GetID(routeNumber);
                            routeAction.Delete(ID);
                        }
                        else
                        {
                            Log.Failure($"Batch file: { BatchFileType.Route } - Extraneous characters beyond record length, on line: {countedLines}.");
                        }
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.Route } - Adding route that already exists, on line: {countedLines}.");
                    }
                }
                else
                {
                    if (actionCode == 'A')
                    {
                        ExtractCityLabels();
                        fileLine = fileLine.TrimEnd(trim);
                        if (fileLine == "")
                        {
                            ApplyCityLabels(routeNumber);
                        }
                        else
                        {
                            Log.Failure($"Batch file: { BatchFileType.Route } - Extraneous characters beyond record length, on line: {countedLines}.");
                        }
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.Route } - No matching action codes, on line: {countedLines}.");
                    }
                }
            }
            Log.Success($"Batch file: { BatchFileType.Route } - Processed.");
            file.Close();
        }
    }

    public class TruckUpload : BatchFileProcessing
    {
        int truckNumber;
        int driverNumber;
        int routeNumber;
        double fuelRate;

        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     |Truck Number|
        ///     T #ROWS
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessTruckFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                    fileLine = fileLine.TrimEnd(trim);
                    if (fileLine == "")
                    {
                        Truck newTruck = new Truck();
                        newTruck.Number = truckNumber;
                        newTruck.Save();
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.Truck } - Extraneous characters beyond record length, on line: {countedLines}.");
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Truck } - Invalid truck number format, on line: {countedLines}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.Truck } - Processed.");
            file.Close();
        }


        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     |Truck Number||Fuel Rate|
        ///     T #ROWS
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessTruckFuelFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckFuel } - Invalid truck number format, on line: {countedLines}.");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    fuelRate = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                    fuelRate = fuelRate / 100;
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckFuel } - Invalid fuel rate format, on line: {countedLines}.");
                    continue;
                }
                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    if (truckAction.NumberInUse(truckNumber))  //Does this truck exist in the DB
                    {
                        Truck oldTruck = new Truck();
                        oldTruck = truckAction.LoadByNumber(truckNumber);
                        oldTruck.FuelRate = fuelRate;
                        oldTruck.Save();
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckFuel } - Extraneous characters beyond record length, on line: {countedLines}.");
                    continue;
                }
            }
            Log.Success($"Batch file: { BatchFileType.TruckFuel } - Processed.");
            file.Close();
        }

        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     |Truck Number||Driver Number|
        ///     T #ROWS
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessTruckDriverFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckDriver } - Invalid truck number format, on line: {countedLines}.");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    driverNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckDriver } - Invalid driver number format, on line: {countedLines}.");
                    continue;
                }
                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    if (truckAction.NumberInUse(truckNumber) & driverAction.NumberInUse(driverNumber))
                    {
                        Truck oldTruck = new Truck();
                        oldTruck = truckAction.LoadByNumber(truckNumber);
                        ID = driverAction.GetID(driverNumber);
                        oldTruck.DriverID = ID;
                    }
                    else
                    {
                        if (!truckAction.NumberInUse(truckNumber))
                        {
                            Log.Failure($"Batch file: { BatchFileType.TruckDriver } - truck doesn't exist, on line: {countedLines}.");
                            continue;
                        }
                        else if (!driverAction.NumberInUse(driverNumber))
                        {
                            Log.Failure($"Batch file: { BatchFileType.TruckDriver } - driver doesn't exist, on line: {countedLines}.");
                            continue;
                        }
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckDriver } - Extraneous characters beyond record length, on line: {countedLines}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.TruckDriver } - Processed");
            file.Close();
        }


        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     |Truck Number||Route Number|
        ///     T #ROWS
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessTruckRouteFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckRoute } - Invalid truck number format, on line: {countedLines}.");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    routeNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckRoute } - Invalid route number format, on line: {countedLines}.");
                    continue;
                }
                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    if (truckAction.NumberInUse(truckNumber) & routeAction.NumberInUse(routeNumber))
                    {
                        Truck oldTruck = new Truck();
                        oldTruck = truckAction.LoadByNumber(truckNumber);
                        ID = routeAction.GetID(routeNumber);
                        oldTruck.RouteID = ID;
                    }
                    else
                    {
                        if (!truckAction.NumberInUse(truckNumber))
                        {
                            Log.Failure($"Batch file: { BatchFileType.TruckRoute } - truck doesn't exist, on line: {countedLines}.");
                            continue;
                        }
                        else if (!routeAction.NumberInUse(routeNumber))
                        {
                            Log.Failure($"Batch file: { BatchFileType.TruckRoute } - route doesn't exist, on line: {countedLines}.");
                            continue;
                        }
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckRoute } - Extraneous characters beyond record length, on line: {countedLines}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.TruckRoute } - Processed");
            file.Close();
        }
    }

    public class DriverUpload : BatchFileProcessing
    {
        int driverNumber;
        string driverName;
        double hourlyRate;

        private void ApplyDriverData()
        {
            Driver newDriver = new Driver();
            newDriver.Number = driverNumber;
            newDriver.Name = driverName;
            newDriver.HourlyRate = hourlyRate;
            newDriver.Save();
        }

        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     |Driver Number||Driver Name||Hourly Rate|
        ///     T #ROWS
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessDriverFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    driverNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Driver } - Invalid driver number format, on line: {countedLines}.");
                    continue;
                }

                driverName = Extract<string>(ref fileLine, Requirement.MaxDriverNameLength);
                driverName = driverName.TrimEnd(trim);

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    hourlyRate = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                    hourlyRate = hourlyRate / 100;
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Driver } - Invalid hourly rate format, on line: {countedLines}.");
                    continue;
                }
                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    ApplyDriverData();
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Driver } - Extraneous characters beyond record length, on line: {countedLines}.");
                    continue;
                }
            }
            Log.Success($"Batch file: { BatchFileType.Driver } - Processed");
            file.Close();
        }
    }

    public class IceCreamTruckUpload : BatchFileProcessing
    {
        int countedRecords = 0;
        int fileRecord;
        int itemNumber;
        int adjustmentQuantity;
        int oldQuantity;
        int truckNumber;
        int truckID;
        int itemID;
        List<int> adjustmentRecord = new List<int>();
        List<int> itemRecord = new List<int>();

        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     TR|Truck Number|
        ///     |Item Number||Adjustment Quantity|
        ///     IR #ROWS FOR TRUCK
        ///     T #ROWS IN FILE
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessIceCreamTruckFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = Extract<string>(ref fileLine, 3);
                extractedData = extractedData.TrimEnd(trim);
                if (extractedData == "TR")
                {
                    if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                    {
                        truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Invalid truck number format, on line: {countedLines}.");
                        continue;
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Truck record not found, on line: {countedLines}.");
                    continue;
                }

                if (truckAction.NumberInUse(truckNumber))
                {
                    fileLine = file.ReadLine();
                    countedLines++;
                    while (fileLine.Substring(0, 2) != "IR")
                    {
                        countedRecords++;
                        if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                        {
                            itemNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        }
                        else
                        {
                            fileLine = file.ReadLine();
                            countedLines++;
                            Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Invalid item number format, on line: {countedLines}.");
                            continue;
                        }

                        extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                        extractedData = extractedData.TrimEnd(trim);
                        if (extractedData.Length == Requirement.ZeroFillNumberLength)
                        {
                            adjustmentQuantity = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        }
                        else
                        {
                            fileLine = file.ReadLine();
                            countedLines++;
                            Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Invalid adjustment quantity format, on line: {countedLines}.");
                            continue;
                        }
                        fileLine = fileLine.TrimEnd(trim);
                        if (fileLine == "")
                        {
                            oldQuantity = inventoryAction.GetInventoryQuantity(truckID, itemID);
                            if (oldQuantity > 0)
                            {
                                if (adjustmentQuantity + oldQuantity >= 0) //Change item quantity
                                {
                                    itemRecord.Add(itemNumber);
                                    adjustmentRecord.Add(adjustmentQuantity + oldQuantity);
                                }
                                else
                                {
                                    Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Adjustment qunatity results in negative number, on line: {countedLines}.");
                                }
                            }
                            else if (itemAction.NumberInUse(itemNumber))
                            {
                                if (adjustmentQuantity >= 0)
                                {
                                    //Create change record for how much is in the OVERALL INVENTORY
                                    itemRecord.Add(itemNumber);
                                    adjustmentRecord.Add(adjustmentQuantity);
                                }
                                else
                                {
                                    Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Adjustment quantity is a negative number, on line: {countedLines}.");
                                }
                            }
                            else
                            {
                                Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Item doesn't exist, on line: {countedLines}.");
                            }

                        }
                        else
                        {
                            Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Extraneous characters beyond record length, on line: {countedLines}.");
                        }
                        fileLine = file.ReadLine();
                        countedLines++;
                    }
                    extractedData = Extract<string>(ref fileLine, 3);
                    if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                    {
                        fileRecord = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        if (fileRecord == countedRecords)
                        {
                            truckID = truckAction.GetID(truckNumber);
                            for (int index = 0; index < countedRecords; index++)
                            {
                                itemID = itemAction.GetID(itemRecord[index]);
                                inventoryAction.ChangeMany(itemID, truckID, adjustmentRecord[index]);
                            }
                            itemRecord.Clear();
                            adjustmentRecord.Clear();
                        }
                        else
                        {
                            Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Item record doesn't match counted records, on line: {countedLines}.");
                            itemRecord.Clear();
                            adjustmentRecord.Clear();
                        }
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Invalid item record format, on line: {countedLines}.");
                        itemRecord.Clear();
                        adjustmentRecord.Clear();
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.TruckInventory } - Truck doesn't exist, on line: {countedLines}.");
                }
                itemRecord.Clear();
                adjustmentRecord.Clear();
            }
            Log.Success($"Batch file: { BatchFileType.TruckInventory } - Processed.");
            file.Close();
        }
    }

    public class IceCreamTruckSalesUpload : BatchFileProcessing
    {
        int countedRecords = 0;
        int fileRecord;
        int itemNumber;
        int oldQuantity;
        int newQuantity;
        int truckNumber;
        int truckID;
        int itemID;
        List<int> itemRecord = new List<int>();
        List<int> quantityRecord = new List<int>();

        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     TR|Truck Number|
        ///     |Item Number||Final Quantity|
        ///     SR #ROWS FOR TRUCK
        ///     T #ROWS IN FILE       
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessIceCreamTruckSalesFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = Extract<string>(ref fileLine, 3);
                extractedData = extractedData.TrimEnd(trim);
                if (extractedData == "TR")
                {
                    if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                    {
                        truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.Sales } - Invalid truck number format, on line: {countedLines}.");
                        continue;
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Sales } - Truck record not found, on line: {countedLines}.");
                    continue;
                }

                if (truckAction.NumberInUse(truckNumber))
                {
                    fileLine = file.ReadLine();
                    countedLines++;
                    while (fileLine.Substring(0, 2) != "SR")
                    {
                        countedRecords++;
                        if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                        {
                            itemNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        }
                        else
                        {
                            fileLine = file.ReadLine();
                            countedLines++;
                            Log.Failure($"Batch file: { BatchFileType.Sales } - Invalid item number format, on line: {countedLines}.");
                            continue;
                        }

                        if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                        {
                            newQuantity = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        }
                        else
                        {
                            fileLine = file.ReadLine();
                            countedLines++;
                            Log.Failure($"Batch file: { BatchFileType.Sales } - Invalid new quantity format, on line: {countedLines}.");
                            continue;
                        }

                        if (fileLine == "")
                        {
                            itemID = itemAction.GetID(itemNumber);
                            truckID = truckAction.GetID(truckNumber);
                            oldQuantity = inventoryAction.GetInventoryQuantity(truckID, itemID);
                            if (oldQuantity > 0)
                            {
                                if (newQuantity <= oldQuantity)
                                {
                                    itemRecord.Add(itemNumber);
                                    quantityRecord.Add(newQuantity);
                                }
                                else
                                {
                                    Log.Failure($"Batch file: { BatchFileType.Sales } - Ice cream was gained, on line: {countedLines}.");
                                }
                            }
                            else
                            {
                                Log.Failure($"Batch file: { BatchFileType.Sales } - Item doesn't exist, on line: {countedLines}.");
                            }
                        }
                        fileLine = file.ReadLine();
                        countedLines++;
                    }
                    extractedData = Extract<string>(ref fileLine, 3);
                    if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                    {
                        fileRecord = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        if (fileRecord == countedRecords)
                        {
                            truckID = truckAction.GetID(truckNumber);
                            for (int index = 0; index < countedRecords; index++)
                            {
                                itemID = itemAction.GetID(itemRecord[index]);
                                inventoryAction.SellMany(itemID, truckID, quantityRecord[index]);
                            }
                            itemRecord.Clear();
                            quantityRecord.Clear();
                        }
                        else
                        {
                            Log.Failure($"Batch file: { BatchFileType.Sales } - Sales record doesn't match counted records, on line: {countedLines}.");
                            itemRecord.Clear();
                            quantityRecord.Clear();
                        }
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.Sales } - Invalid sale record format, on line: {countedLines}.");
                        itemRecord.Clear();
                        quantityRecord.Clear();
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.Sales } - Truck doesn't exist, on line: {countedLines}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.Sales } - Processed");
            file.Close();
        }
    }

    public class InventoryUpdateUpload : BatchFileProcessing
    {
        int itemNumber;
        int warehouseQuantity;
        int itemFreshness;
        double price;
        string description;

        /// <summary>
        /// 
        ///     HD SEQ#      YYYY-MM-DD 
        ///     |Item Number||Warehouse Quantity||Price||Description|
        ///     T #ROWS IN FILE
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessInventoryUpdateFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();

                itemNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                warehouseQuantity = Extract<int>(ref fileLine, 6);
                price = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                price = price / 100;
                description = Extract<string>(ref fileLine, Requirement.MinItemDescriptionLength);

                if (itemAction.NumberInUse(itemNumber)) //If it it exists in the DB
                {
                    fileLine = fileLine.TrimEnd(trim);
                    if (fileLine == "")
                    {
                        Item oldItem = new Item();
                        oldItem = itemAction.LoadByNumber(itemNumber);

                        if (price != 0)
                        {
                            oldItem.Price = price;
                        }
                        if (description != "")
                        {
                            oldItem.Description = description;
                        }
                        if (warehouseQuantity != 0)
                        {
                            oldItem.Quantity = warehouseQuantity;
                        }
                        oldItem.Save();
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.OverallInventory } - Extraneous characters beyond record length, on line: {countedLines}");
                    }
                }
                else
                {
                    fileLine = fileLine.TrimEnd(trim);
                    if (fileLine == "")
                    {
                        Item newItem = new Item();
                        newItem.Number = itemNumber;
                        newItem.Price = price;
                        newItem.Description = description;
                        newItem.Quantity = warehouseQuantity;
                        newItem.Save();
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.OverallInventory } - Extraneous characters beyond record length, on line: {countedLines}");
                    }
                }
            }
            Log.Success($"Batch file: { BatchFileType.OverallInventory } - Processed");
            file.Close();
        }
        /// <summary>
        /// 
        ///     HD SEQ#		YYYY-MM-DD
        ///     |Item number||Item freshness|
        ///     T #ROWS IN FILE
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessInventoryUpdateExtensionFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (!file.EndOfStream)
            {
                fileLine = file.ReadLine();
                countedLines++;

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    itemNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.OverallIventoryExtension } - Invalid item number format, on line: {countedLines}.");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    itemFreshness = Extract<int>(ref fileLine, 3);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.OverallIventoryExtension } - Invalid item freshness format, on line: {countedLines}.");
                    continue;
                }
                fileLine = fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    if (itemAction.NumberInUse(itemNumber))
                    {
                        Item oldItem = new Item();
                        oldItem = itemAction.LoadByNumber(itemNumber);
                        oldItem.Lifetime = itemFreshness;
                        oldItem.Save();
                    }
                    else
                    {
                        Log.Failure($"Batch file: { BatchFileType.OverallIventoryExtension } - Item doesn't exist, on line: {countedLines}.");
                    }
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.OverallIventoryExtension } - Extraneous characters beyond record length, on line: {countedLines}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.OverallIventoryExtension } - Processed");
            file.Close();
        }
    }
}