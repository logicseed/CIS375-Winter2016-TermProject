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
    class BatchFileProcessing
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

    class HeaderFooter : BatchFileProcessing
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
                headerRecord.TrimEnd(trim);
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    sequenceNumber = Extract<int>(ref fileLine, 10);
                }
                else
                {
                    throw new ExceptionWithOutcome($"Batch file: {FileType} - Invalid sequence number format.");
                }
                date = Extract<DateTime>(ref fileLine, 10);

                fileLine.TrimEnd(trim);
                if (fileLine == "")
                {
                    if (headerRecord == "HD")
                    {
                        Log.Success($"Batch file: { FileType } - Header record found.");
                    }
                    else
                    {
                        throw new ExceptionWithOutcome($"Batch file: {FileType} - Header record not found.");
                    }

                    if (sequenceNumber == BatchHistory.GetSequence(FileType))
                    {
                        Log.Success($"Batch file: { FileType } - Date sequence number processed.");
                    }
                    else
                    {
                        throw new ExceptionWithOutcome($"Batch file: { FileType } - Sequence number out of order.");
                    }

                    if (date >= BatchHistory.GetDateUpdated(FileType))
                    {
                        Log.Success($"Batch file: { FileType } - Date processed.");
                    }
                    else
                    {
                        throw new ExceptionWithOutcome($"Batch file: { FileType } - Date out of order.");
                    }

                    while (file.EndOfStream != false)
                    {
                        fileLine = file.ReadLine();
                        foreach (string element in recordTypes)
                        {
                            if ((fileLine.Substring(0, 2)) == element)
                            {
                                countedRecords++;
                                countedLines++;
                            }
                        }
                    }
                    extractedData = Extract<string>(ref fileLine, 2);
                    extractedData.TrimEnd(trim);
                    fileLine.TrimEnd(trim);
                    if (extractedData == "T")
                    {
                        trailerNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        if (trailerNumber == countedRecords)
                        {
                            BatchHistory.SetSequence(FileType, sequenceNumber);
                            BatchHistory.SetDateUpdated(FileType, date);
                            Log.Success($"Batch file: { FileType } - Successful header and footer check.");
                            file.Close();
                            return true;
                        }
                        else
                        {
                            throw new ExceptionWithOutcome($"Batch file: { FileType } - Trailer record doesn't match number of records in file.");
                        }
                    }
                    else
                    {
                        throw new ExceptionWithOutcome($"Batch file: { FileType } - Trailer record not found.");
                    }
                }
                else
                {
                    throw new ExceptionWithOutcome($"Batch file: { FileType } - Extraneous characters beyond record length");
                }
            }
            catch (Exception e)
            {
                Log.Failure(e.Message);
                return false;
            }
        }
    }

    class CityUpload : BatchFileProcessing
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
            while (file.EndOfStream != false || fileLine.Substring(0, 2) != "T ")
            {
                fileLine = file.ReadLine();
                countedLines++;
                cityLabel = Extract<string>(ref fileLine, Requirement.MaxCityLabelLength);
                cityName = Extract<string>(ref fileLine, Requirement.MaxCityNameLength);
                state = Extract<string>(ref fileLine, Requirement.MaxCityStateLength);

                if (fileLine == "")
                {
                    ApplyNewCityData();
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.City } - Extraneous characters beyond record length, failed to add city label: {cityLabel}.");
                }
            }
            Log.Success($"Batch file: { BatchFileType.City } - Successful.");
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

            while (file.EndOfStream != false || fileLine.Substring(0, 2) != "T ")
            {
                fileLine = file.ReadLine();
                countedLines++;

                cityLabel = Extract<string>(ref fileLine, Requirement.MaxCityLabelLength);
                cityLabel.TrimEnd(trim);

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    hours = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.CityExtension } - Invalid hours format, line: {countedLines}.");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    miles = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure($"Batch file: { BatchFileType.CityExtension } - Invalid miles format, line: {countedLines}.");
                    continue;
                }

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
                    Log.Failure($"Batch file: { BatchFileType.City } - Extraneous characters beyond record length, line: {countedLines}.");
                }
            }
            Log.Success("Message");
            file.Close();
        }


    }

    class RouteUpload : BatchFileProcessing
    {
        char actionCode;
        int routeNumber;
        List<string> routeComposition;

        private void ExtractCityLabels()
        {
            for (int i = 0; i < Requirement.MaxRouteCities; i++)
            {
                string cityLabel = Extract<string>(ref fileLine, Requirement.MaxCityLabelLength);
                cityLabel.TrimEnd(trim);

                if (cityAction.Exists(cityLabel))
                {
                    routeComposition.Add(cityLabel);
                }
                else
                {
                    Log.Failure("Message");
                    routeComposition.Clear();
                    break;
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                actionCode = Extract<char>(ref fileLine, 1);

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    routeNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                if (routeAction.NumberInUse(routeNumber)) //Does this routeNumber exist in the DB
                {
                    if (actionCode == 'C')
                    {
                        ExtractCityLabels();
                        if (fileLine == "")
                        {
                            ID = routeAction.GetID(routeNumber);
                            routeAction.Delete(ID);
                            ApplyCityLabels(routeNumber); //Apply cityLabels
                        }
                        else
                        {
                            Log.Failure("Message");
                        }
                    }
                    else if (actionCode == 'D')
                    {
                        if (fileLine == "")
                        {
                            ID = routeAction.GetID(routeNumber);
                            routeAction.Delete(ID);
                        }
                        else
                        {
                            Log.Failure("Message");
                        }
                    }
                    else
                    {
                        Log.Failure("Message");
                    }
                }
                else
                {
                    if (actionCode == 'A')
                    {
                        ExtractCityLabels();
                        if (fileLine == null)
                        {
                            ApplyCityLabels(routeNumber);
                        }
                        else
                        {
                            Log.Failure("Message");
                        }
                    }
                    else
                    {
                        Log.Failure("Message");
                    }
                }
            }
            Log.Success("Message");
            file.Close();
        }
    }

    class TruckUpload : BatchFileProcessing
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);

                    if (fileLine == "")
                    {
                        Truck newTruck = new Truck();
                        newTruck.Number = truckNumber;
                        newTruck.Save();
                    }
                    else
                    {
                        Log.Failure("Message");
                    }
                }
                else
                {
                    Log.Failure("Message");
                }
            }
            Log.Success("Message");
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    fuelRate = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                    fuelRate = fuelRate / 100;
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

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
                    Log.Failure("Message");
                    continue;
                }
            }
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    driverNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

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
                            Log.Failure("Message");
                            continue;
                        }
                        else if (!driverAction.NumberInUse(driverNumber))
                        {
                            Log.Failure("Message");
                            continue;
                        }
                    }
                }
            }
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;
                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    routeNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

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
                            Log.Failure("Message");
                            continue;
                        }
                        else if (!routeAction.NumberInUse(routeNumber))
                        {
                            Log.Failure("Message");
                            continue;
                        }
                    }
                }
            }
        }
    }

    class DriverUpload : BatchFileProcessing
    {
        int driverNumber;
        int truckNumber;
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    driverNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                driverName = Extract<string>(ref fileLine, Requirement.MaxDriverNameLength);
                driverName.TrimEnd(trim);

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    hourlyRate = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                    hourlyRate = hourlyRate / 100;
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                if (fileLine == "")
                {
                    ApplyDriverData();
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }
            }
            Log.Success("Message");
            file.Close();
        }
    }

    class IceCreamTruckUpload : BatchFileProcessing
    {
        int itemQuantity;
        int countedRecords = 0;
        int fileRecord;
        int itemNumber;
        int adjustmentQuantity;
        int oldQuantity;
        int truckNumber;
        int truckID;
        int itemID;
        List<int> adjustmentRecord;
        List<int> itemRecord;
        List<bool> addItem;

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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = Extract<string>(ref fileLine, 3);
                extractedData.TrimEnd(trim);
                if (extractedData == "TR")
                {
                    if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                    {
                        truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                    }
                    else
                    {
                        Log.Failure("Message");
                        continue;
                    }
                }
                else
                {
                    Log.Failure("Message");
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
                            Log.Failure("Message");
                            continue;
                        }

                        extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                        extractedData.TrimEnd(trim);
                        if (extractedData.Length == Requirement.ZeroFillNumberLength)
                        {
                            adjustmentQuantity = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                        }
                        else
                        {
                            fileLine = file.ReadLine();
                            countedLines++;
                            Log.Failure("Message");
                            continue;
                        }

                        if (fileLine == "")
                        {
                            oldQuantity = inventoryAction.GetInventoryQuantity(truckID, itemID);
                            if (oldQuantity > 0)
                            {
                                if (adjustmentQuantity + oldQuantity > 0) //Change item quantity
                                {
                                    itemRecord.Add(itemNumber);
                                    adjustmentRecord.Add(adjustmentQuantity + oldQuantity);
                                    addItem.Add(false);
                                }
                                else
                                {
                                    Log.Failure("Message");
                                }
                            }
                            else if (itemAction.NumberInUse(itemNumber))
                            {
                                if (adjustmentQuantity > 0)
                                {
                                    //Create change record for how much is in the OVERALL INVENTORY
                                    itemRecord.Add(itemNumber);
                                    adjustmentRecord.Add(adjustmentQuantity);
                                    addItem.Add(true);
                                }
                                else
                                {
                                    Log.Failure("Message");
                                }
                            }
                            else
                            {
                                Log.Failure("Message");
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
                                if (addItem[index] == false)
                                {
                                    inventoryAction.ChangeMany(itemID, truckID, adjustmentRecord[index]);
                                }
                                else
                                {
                                    inventoryAction.Add(itemID, truckID, adjustmentRecord[index]);
                                }
                            }
                            itemRecord.Clear();
                            adjustmentRecord.Clear();
                        }
                        else
                        {
                            Log.Failure("Message");
                            itemRecord.Clear();
                            adjustmentRecord.Clear();
                        }
                    }
                    else
                    {
                        Log.Failure("Message");
                        itemRecord.Clear();
                        adjustmentRecord.Clear();
                    }
                }
                else
                {
                    Log.Failure("Message");
                }
                itemRecord.Clear();
                adjustmentRecord.Clear();
            }
        }
    }

    class IceCreamTruckSalesUpload : BatchFileProcessing
    {
        int countedRecords = 0;
        int fileRecord;
        int itemNumber;
        int oldQuantity;
        int newQuantity;
        int truckNumber;
        int truckID;
        int itemID;
        List<int> itemRecord;
        List<int> quantityRecord;
        Dictionary<Item, int> itemList;

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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = Extract<string>(ref fileLine, 3);
                extractedData.TrimEnd(trim);
                if (extractedData == "TR")
                {
                    if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                    {
                        truckNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                    }
                    else
                    {
                        Log.Failure("Message");
                        continue;
                    }
                }
                else
                {
                    Log.Failure("Message");
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
                            Log.Failure("Message");
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
                            Log.Failure("Message");
                            continue;
                        }

                        if (fileLine == "")
                        {
                            itemID = itemAction.GetID(itemNumber);
                            truckID = truckAction.GetID(truckNumber);
                            oldQuantity = inventoryAction.GetInventoryQuantity(truckID, itemID);
                            if ( oldQuantity > 0 )
                            {
                                if (newQuantity <= oldQuantity)
                                {
                                    itemRecord.Add(itemNumber);
                                    quantityRecord.Add(newQuantity);
                                }
                                else
                                {
                                    Log.Failure("Message");
                                }
                            }
                            else
                            {
                                Log.Failure("Message");
                                //Log of item not existing
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
                            Log.Failure("Message");
                            itemRecord.Clear();
                            quantityRecord.Clear();
                        }
                    }
                    else
                    {
                        Log.Failure("Message");
                        itemRecord.Clear();
                        quantityRecord.Clear();
                    }
                }
                else
                {
                    Log.Failure("Message");
                }
            }

        }
    }

    class InventoryUpdateUpload : BatchFileProcessing
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();

                itemNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                if (itemAction.NumberInUse(itemNumber)) //If it it exists in the DB
                {
                    warehouseQuantity = Extract<int>(ref fileLine, 6);
                    price = Extract<double>(ref fileLine, Requirement.ZeroFillNumberLength);
                    price = price / 100;
                    description = Extract<string>(ref fileLine, Requirement.MinItemDescriptionLength);

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
                        Log.Failure("Message");
                    }
                }
                else
                {
                    if (fileLine == null)
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
                        Log.Failure("Message");
                    }
                }
            }
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

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    itemNumber = Extract<int>(ref fileLine, Requirement.ZeroFillNumberLength);
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                if (ZeroFillNumberCheck(fileLine, Requirement.ZeroFillNumberLength))
                {
                    itemFreshness = Extract<int>(ref fileLine, 3);   
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }

                if (fileLine == "")
                {
                    if (itemAction.NumberInUse(itemNumber))
                    {
                        Item oldItem = new Item();
                        oldItem = itemAction.LoadByNumber(itemNumber);
                        oldItem.Lifetime = itemFreshness;
                        oldItem.Save();
                    }
                }
                else
                {
                    Log.Failure("Message");
                    continue;
                }
            }
        }
    }
}