///<Author>Rodney Lewis</Author>
using IceCreamManager.Model;
using System;
using System.IO;

namespace IceCreamManager.Controller
{
    class BatchFileProcessing
    {
        public string fileLine;
        public int countedLines = 0;
        public char trim = ' ';
        public string extractedData;

        public bool ZeroFillNumberCheck(string FileNumber)
        {
            //Does it create a valid number
            FileNumber.Trim(trim);
            if (FileNumber.Length == Requirement.ZeroFillNumberLength)
                return true;
            else
                return false;
        }
    }

    class HeaderFooter : BatchFileProcessing
    {
        string[] recordTypes = new string[] { "IR", "TR", "SR", "T " };
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
            /// Returns true if the header and footer pass all if statements
            /// Returns false if at any point it does not pass an if statement
            /// </returns>

            try
            {
                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = fileLine.Substring(0, 2);
                if (extractedData == "HD")
                {
                    fileLine = fileLine.Remove(0, 3);
                    sequenceNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                    if (sequenceNumber == BatchHistory.GetSequence(FileType))
                    {
                        fileLine = fileLine.Remove(0, 10);
                        date = Convert.ToDateTime(fileLine.Substring(0, 10));
                        if (date >= BatchHistory.GetDateUpdated(FileType))
                        {
                            fileLine = fileLine.Remove(0, 10);
                            if (fileLine == null)
                            {
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
                                extractedData = fileLine.Substring(0, 1);
                                if (extractedData == "T")
                                {
                                    fileLine = fileLine.Remove(0, 2);
                                    trailerNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                                    if (trailerNumber == countedRecords)
                                    {
                                        file.Close();
                                        BatchHistory.SetSequence(FileType, sequenceNumber);
                                        BatchHistory.SetDateUpdated(FileType, date);
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                file.Close();
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            file.Close();
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        file.Close();
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    file.Close();
                    throw new NotImplementedException();
                }
                return false;
            }
            catch (Exception)
            {
                Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(FileType), ActionType.LoadFile, Outcome.FileRejected, countedLines);
                return false;
            }
        }
    }

    class CityUpload : BatchFileProcessing
    {
        CityFactory cityAction = CityFactory.Reference;

        string cityLabel;
        string cityName;
        string state;
        double hours;
        double miles;

        /// <summary>
        /// Processes City file, Rejects line if information is invalid.
        /// 
        ///HD SEQ#      YYYY-MM-DD 
        ///|------city label----||------city name-----||state|
        ///T #ROWS
        ///     
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

                cityLabel = fileLine.Substring(0, Requirement.MaxCityLabelLength);
                fileLine = fileLine.Remove(0, Requirement.MaxCityLabelLength);

                cityName = fileLine.Substring(0, Requirement.MaxCityNameLength);
                fileLine = fileLine.Remove(0, Requirement.MaxCityNameLength);

                state = fileLine.Substring(0, Requirement.MaxCityStateLength);
                fileLine = fileLine.Remove(0, Requirement.MaxCityStateLength);

                if (fileLine == null)
                {
                    cityLabel.TrimEnd(trim);
                    cityName.TrimEnd(trim);
                    ApplyNewCityData();
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.City), ActionType.AddCity, Outcome.LineRejected, countedLines);
                }
            }
            file.Close();
        }

        private void ApplyNewCityData()
        {
            City newCity = new City();
            newCity.Label = cityLabel;
            newCity.Name = cityName;
            newCity.State = state;
            newCity.Save();
            //Apply all data
        }

        /// <summary>
        /// 
        ///HD SEQ#      YYYY-MM-DD
        ///|------city label----||Hours||Miles|
        ///T ROWS
        ///
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessCityFileExtension(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false || fileLine.Substring(0, 2) != "T ")
            {
                fileLine = file.ReadLine();
                countedLines++;

                cityLabel = fileLine.Substring(0, Requirement.MaxCityLabelLength);
                if (cityAction.Exists(cityLabel))
                {
                    fileLine = fileLine.Remove(0, Requirement.MaxCityLabelLength);
                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        hours = Convert.ToDouble(extractedData);
                        hours = hours / 100;
                        fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                        extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                        if (ZeroFillNumberCheck(extractedData))
                        {
                            miles = Convert.ToDouble(extractedData);
                            miles = miles / 100;
                            fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                            if (fileLine == null)
                            {
                                cityLabel.TrimEnd(trim);
                                ApplyCityHoursMiles();
                            }
                            else
                            {
                                //Reject line
                                Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.CityExtension), ActionType.AddCity, Outcome.LineRejected, countedLines);
                            }
                        }
                        else
                        {
                            //Rejct line
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.CityExtension), ActionType.AddCity, Outcome.LineRejected, countedLines);
                        }

                    }
                    else
                    {
                        //Rejct line
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.CityExtension), ActionType.AddCity, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    //Reject line
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.CityExtension), ActionType.AddCity, Outcome.LineRejected, countedLines);
                }
            }
        }

        private void ApplyCityHoursMiles()
        {
            City cityProperties = new City();
            int id = cityAction.GetCityID(cityLabel);
            cityProperties = cityAction.Load(id);
            cityProperties.Hours = hours;
            cityProperties.Miles = miles;
            cityProperties.Save();
            //Apply all data
        }
    }

    class RouteUpload : BatchFileProcessing
    {
        RouteFactory routeAction = RouteFactory.Reference;
        CityFactory cityAction = CityFactory.Reference;
        string actionCode;
        int routeNumber;
        string[] cityLabel = new string[10];

        public void ExtractCityLabels()
        {
            for (int i = 0; i < 10; i++)
            {
                extractedData = fileLine.Substring(0, 20);
                extractedData.TrimEnd(trim);
                if (cityAction.Exists(extractedData)) //Does this city label exist in the DB
                {
                    cityLabel[i] = extractedData;
                }
                else
                {
                    Array.Clear(cityLabel, 0, 10);
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Route), ActionType.AddCity, Outcome.LineRejected, countedLines);
                }
            }
        }
        /// <summary>
        /// 
        ///HD SEQ#      YYYY-MM-DD    
        ///|action code||Route Number||-----city label-----|*10
        ///T #ROWS
        ///
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessRouteFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();

                actionCode = fileLine.Substring(0, 1);
                fileLine = fileLine.Remove(0, 1);

                routeNumber = Convert.ToInt32(fileLine.Substring(0, Requirement.ZeroFillNumberLength));
                fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                if (routeAction.Exists()) //Does this routeNumber exist in the DB
                {
                    if (actionCode == "C")
                    {
                        //Erase contents of routeNumber
                        ExtractCityLabels();
                        if (fileLine == null)
                        {
                            //Apply cityLabels
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Route), ActionType.ChangeRoute, Outcome.LineRejected, countedLines);
                        }
                    }
                    else if (actionCode == "D")
                    {
                        if (fileLine == null)
                        {
                            //Delete route
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Route), ActionType.DeleteRoute, Outcome.LineRejected, countedLines);
                            //Reject line
                        }
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Route), ActionType.AddRoute, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    if (actionCode == "A")
                    {
                        ExtractCityLabels();
                        if (fileLine == null)
                        {

                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Route), ActionType.AddRoute, Outcome.LineRejected, countedLines);
                        }
                        Route newRoute = new Route();
                        //Add routes to new city
                        //Apply cityLabels
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Route), ActionType.ModifyRoute, Outcome.LineRejected, countedLines);
                    }
                }
            }
            file.Close();
        }
    }

    class TruckUpload : BatchFileProcessing
    {
        int truckNumber;
        double fuelRate;

        /// <summary>
        /// 
        /// HD SEQ#      YYYY-MM-DD 
        /// |Truck Number|
        /// T #ROWS
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckFile(string FilePath)
        {

            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;
                if (ZeroFillNumberCheck(fileLine))
                {
                    truckNumber = Convert.ToInt32(fileLine.Substring(0, Requirement.ZeroFillNumberLength));
                    fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                    if (fileLine == null)
                    {
                        Truck newTruck = new Truck();
                        newTruck.Number = truckNumber;
                        newTruck.Save();
                        //Apply data
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Truck), ActionType.AddTruck, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Truck), ActionType.AddTruck, Outcome.LineRejected, countedLines);
                }
            }
        }


        /// <summary>
        /// 
        /// HD SEQ#      YYYY-MM-DD 
        /// |Truck Number||Fuel Rate|
        /// T #ROWS
        ///
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckFuelFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                if (ZeroFillNumberCheck(extractedData))
                {
                    truckNumber = Convert.ToInt32(extractedData);
                    fileLine.Remove(0, Requirement.ZeroFillNumberLength);
                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);

                    //Does this truck exist in the DB?
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        fuelRate = Convert.ToDouble(extractedData);
                        fuelRate = fuelRate / 100;
                        fileLine.Remove(0, Requirement.ZeroFillNumberLength);
                        if (fileLine == null)
                        {
                            //Apply data
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckFuel), ActionType.AddFuelToTruck, Outcome.LineRejected, countedLines);
                        }
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckFuel), ActionType.AddFuelToTruck, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckFuel), ActionType.AddFuelToTruck, Outcome.LineRejected, countedLines);
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

        /// <summary>
        /// 
        /// HD SEQ#      YYYY-MM-DD 
        /// |Driver Number||Driver Name||Hourly Rate|
        /// T #ROWS
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessDriverFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = fileLine.Substring(0, Requirement.MaxDriverNumber);
                if (ZeroFillNumberCheck(extractedData))
                {
                    driverNumber = Convert.ToInt32(extractedData);
                    fileLine.Remove(0, Requirement.MaxDriverNumber);

                    driverName = fileLine.Substring(0, Requirement.MaxDriverNameLength);
                    fileLine.Remove(0, Requirement.MaxDriverNameLength);

                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        hourlyRate = Convert.ToDouble(extractedData);
                        hourlyRate = hourlyRate / 100;
                        fileLine.Remove(0, Requirement.ZeroFillNumberLength);
                        if (fileLine == null)
                        {
                            ApplyDriverData();
                            //Apply data
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Driver), ActionType.AddDriver, Outcome.LineRejected, countedLines);
                        }
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Driver), ActionType.AddDriver, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Driver), ActionType.AddDriver, Outcome.LineRejected, countedLines);
                }
            }
        }

        private void ApplyDriverData()
        {
            Driver newDriver = new Driver();
            newDriver.Number = driverNumber;
            newDriver.Name = driverName;
            newDriver.HourlyRate = hourlyRate;
        }

        /// <summary>
        /// 
        /// HD SEQ#      YYYY-MM-DD 
        /// |Truck Number||Driver Number|
        /// T #ROWS
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckDriverFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                if (ZeroFillNumberCheck(extractedData))
                {
                    //If truck exists
                    truckNumber = Convert.ToInt32(extractedData);
                    fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        //If driver exists
                        driverNumber = Convert.ToInt32(extractedData);
                        fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                        if (fileLine == null)
                        {
                            //Apply data
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckDriver), ActionType.AddTruckDriver, Outcome.LineRejected, countedLines);
                        }
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckDriver), ActionType.AddTruckDriver, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckDriver), ActionType.AddTruckDriver, Outcome.LineRejected, countedLines);
                }
            }
        }
    }

    class TruckRouteUpload : BatchFileProcessing
    {
        int truckNumber;
        int routeNumber;

        /// <summary>
        /// 
        /// HD SEQ#      YYYY-MM-DD 
        /// |Truck Number||Route Number|
        /// T #ROWS
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckRouteFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                if (ZeroFillNumberCheck(extractedData))
                {
                    truckNumber = Convert.ToInt32(fileLine.Substring(0, Requirement.ZeroFillNumberLength));
                    //if truck exists
                    fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        routeNumber = Convert.ToInt32(fileLine.Substring(0, Requirement.ZeroFillNumberLength));
                        //if route exists
                        fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                        if (fileLine == null)
                        {
                            //Check if truck and route exist
                            //Apply data if they both exist
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckRoute), ActionType.AddTruckToRoute, Outcome.LineRejected, countedLines);
                        }
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckRoute), ActionType.AddTruckToRoute, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckRoute), ActionType.AddTruckToRoute, Outcome.LineRejected, countedLines);
                }
            }
        }
    }

    class IceCreamTruckUpload : BatchFileProcessing
    {
        int countedRecords = 0;
        int fileRecord;
        int itemNumber;
        int adjustmentQuantity;

        /// <summary>
        /// 
        /// HD SEQ#      YYYY-MM-DD 
        /// TR|Truck Number|
        /// |Item Number||Adjustment Quantity|
        /// IR #ROWS FOR TRUCK
        /// T #ROWS IN FILE
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessIceCreamTruckFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;
                extractedData = fileLine.Substring(0, 2);
                if (extractedData == "TR")
                {
                    fileLine = file.ReadLine();
                    countedLines++;
                    countedRecords++;
                    while (fileLine.Substring(0, 2) != "IR")
                    {
                        countedRecords++;
                        extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                        if (ZeroFillNumberCheck(extractedData))
                        {
                            itemNumber = Convert.ToInt32(extractedData);
                            fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);
                            extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);

                            if (ZeroFillNumberCheck(extractedData))
                            {
                                adjustmentQuantity = Convert.ToInt32(extractedData);
                                fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                                if (fileLine == null)
                                {
                                    if (itemNumber)
                                    {
                                        //Change item quantity
                                        if ((adjustmentQuantity + itemQuantity) > 0)
                                        {
                                            //Create change record
                                        }
                                        else
                                        {
                                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.City), ActionType.UpdateTruckItem, Outcome.LineRejected, countedLines);
                                            //Reject line
                                        }
                                    }
                                    else
                                    {
                                        if (adjustmentQuantity > 0)
                                        {
                                            //Create new item
                                            //Create change record
                                        }
                                        else
                                        {
                                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.City), ActionType.AddTruckItem, Outcome.LineRejected, countedLines);
                                            //Reejct line
                                        }
                                    }
                                }
                                else
                                {
                                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.City), ActionType.UpdateTruckItem, Outcome.LineRejected, countedLines);
                                    //Rejct line
                                }
                            }
                        }
                        fileLine = file.ReadLine();
                    }
                    fileLine.Remove(0, 2);
                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        fileRecord = Convert.ToInt32(extractedData);
                        fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                        if (fileRecord == countedRecords)
                        {
                            //Apply all data
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckInventory), ActionType.ModifyTruckInventory, Outcome.RecordRejected, countedLines);                            //Reject set of records
                        }
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckInventory), ActionType.ModifyTruckInventory, Outcome.RecordRejected, countedLines);                        //Reject set of records
                    }
                }

            }
        }
    }

    class IceCreamTruckSalesUpload : BatchFileProcessing
    {
        int countedRecords = 0;
        int fileRecord;
        int itemNumber;
        int newQuantity;

        /// <summary>
        /// 
        ///  HD SEQ#      YYYY-MM-DD 
        /// TR|Truck Number|
        /// |Item Number||Final Quantity|
        /// SR #ROWS FOR TRUCK
        ///  T #ROWS IN FILE
        ///        
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessIceCreamTruckSalesFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;
                extractedData = fileLine.Substring(0, 2);
                if (extractedData == "TR")
                {
                    fileLine = file.ReadLine();
                    countedLines++;
                    countedRecords++;
                    while (fileLine.Substring(0, 2) != "SR")
                    {
                        countedRecords++;
                        extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                        if (ZeroFillNumberCheck(extractedData))
                        {
                            itemNumber = Convert.ToInt32(extractedData);
                            fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);
                            extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);

                            if (ZeroFillNumberCheck(extractedData))
                            {
                                newQuantity = Convert.ToInt32(extractedData);
                                fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                                if (fileLine == null)
                                {
                                    if (itemNumber)
                                    {
                                        //Change item quantity
                                        if (newQuantity > itemQuantity)
                                        {
                                            //Create change record
                                        }
                                        else
                                        {
                                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Sales), ActionType.UpdateItemQuantity, Outcome.LineRejected, countedLines);
                                            //Reject line
                                        }
                                    }
                                    else
                                    {
                                        if (adjustmentQuantity > 0)
                                        {
                                            //Create new item
                                            //Create change record
                                        }
                                        else
                                        {
                                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Sales), ActionType.UpdateItemQuantity, Outcome.LineRejected, countedLines);                                                //Reejct line
                                        }
                                    }
                                }
                                else
                                {
                                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Sales), ActionType.UpdateItemQuantity, Outcome.LineRejected, countedLines);                                        //Rejct line
                                }
                            }
                        }
                        fileLine = file.ReadLine();
                    }
                    fileLine.Remove(0, 2);
                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        fileRecord = Convert.ToInt32(extractedData);
                        fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                        if (fileRecord == countedRecords)
                        {
                            //Apply all data
                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Sales), ActionType.UpdateItemQuantity, Outcome.RecordRejected, countedLines);                                //Reject set of records
                        }
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Sales), ActionType.UpdateItemQuantity, Outcome.RecordRejected, countedLines);                            //Reject set of records
                    }
                }

            }
        }
        /// <summary>
        /// 
        /// HD SEQ#		YYYY-MM-DD
        /// |Poll number|
        /// |item number||Vote|
        /// T #ROWS IN FILE
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessPollFile(string FilePath)
        {
            //TODO: Implement when more information becomes available
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
        ///  HD SEQ#      YYYY-MM-DD 
        ///  |Item Number||Warehouse Quantity||Price||Description|
        ///  T #ROWS IN FILE
        ///  
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessInventoryUpdateFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();

                itemNumber = Convert.ToInt32(fileLine.Substring(0, Requirement.ZeroFillNumberLength));
                fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);
                if (itemNumber) //If it it exists in the DB
                {
                    warehouseQuantity = Convert.ToInt32(fileLine.Substring(0, 6));
                    fileLine = fileLine.Remove(0, 6);

                    price = Convert.ToDouble(fileLine.Substring(0, Requirement.ZeroFillNumberLength));
                    price = price / 100;
                    fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                    description = fileLine.Substring(0, Requirement.MaxItemDescriptionLength);
                    fileLine = fileLine.Remove(0, Requirement.MaxItemDescriptionLength);

                    if (fileLine == null)
                    {
                        if (price != 0)
                        {

                        }

                        if (description != null)
                        {

                        }
                        if (warehouseQuantity != 0)
                        {

                        }
                        else
                        {
                            Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Item), ActionType.AddItemToInventory, Outcome.LineRejected, countedLines);
                        }
                        //Check if item exists
                        //Apply data if they both exist
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Item), ActionType.AddItemToInventory, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Item), ActionType.AddItemToInventory, Outcome.LineRejected, countedLines);
                }
            }
        }
        /// <summary>
        /// 
        /// HD SEQ#		YYYY-MM-DD
        /// |Item number||Item freshness|
        /// T #ROWS IN FILE
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessInventoryUpdateExtensionFile(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();
            countedLines++;

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                countedLines++;

                extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                if (ZeroFillNumberCheck(extractedData))
                {
                    itemNumber = Convert.ToInt32(fileLine.Substring(0, Requirement.ZeroFillNumberLength));
                    //if item exists
                    fileLine = fileLine.Remove(0, Requirement.ZeroFillNumberLength);

                    extractedData = fileLine.Substring(0, Requirement.ZeroFillNumberLength);
                    //extractedData = itemfreshness, think it will only be a 3 digit number;
                    if (fileLine == null)
                    {

                        //Apply data if they both exist
                    }
                    else
                    {
                        Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.ItemExtension), ActionType.AddFreshnessToItem, Outcome.LineRejected, countedLines);
                    }
                }
                else
                {
                    Logger.LogBatch(EntityType.BatchFile, Convert.ToInt32(BatchFileType.ItemExtension), ActionType.AddFreshnessToItem, Outcome.LineRejected, countedLines);
                }
            }
        }
    }
}