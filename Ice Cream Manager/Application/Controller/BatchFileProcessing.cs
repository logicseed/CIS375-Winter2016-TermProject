
using IceCreamManager.Model;
///<Author>Rodney Lewis</Author>
using System;
using System.IO;

namespace IceCreamManager.Controller
{
    public class BatchFileProcessing
    {
        public string fileLine;
        public int countedRecords = 0;
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

    public class HeaderFooter : BatchFileProcessing
    {
        string[] recordTypes = new string[] { "IR", "TR", "SR", "T " };
        int sequenceNumber;
        int trailerNumber;
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
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(FileType), ActionSource.BatchFile, ActionType.LoadFile, Outcome.FileRejected, countedLines);
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

        /// <summary>
        /// Processes City file, Rejects line if information is invalid.
        /// </summary>
        /// <param name="FilePath">Pathing to the input file</param>
        public void ProcessCityFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |------city label----||------city name-----||state|
                T #ROWS
            */

            try
            {
                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();
                countedLines++;

                while (file.EndOfStream != false || fileLine.Substring(0, 2) != "T ")
                {
                    fileLine = file.ReadLine();
                    
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

                        City newCity = new City();
                        newCity.Label = cityLabel;
                        newCity.Name = cityName;
                        newCity.State = state;
                        newCity.Save();
                        //Apply all data
                    }
                    else
                    {
                        throw new NotImplementedException();
                        //Reject line
                    }
                }
                file.Close();
            }
            catch (Exception)
            {
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(BatchFileType.City), ActionSource.BatchFile, ActionType.AddCity, Outcome.LineRejected, countedLines);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessCityFileExtension(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD
                |------city label----||Hours||Miles|
            */

            try
            {
                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();
                countedLines++;

                while (file.EndOfStream != false || fileLine.Substring(0, 2) != "T ")
                {
                    fileLine = file.ReadLine();

                    cityLabel = fileLine.Substring(0, Requirement.MaxCityLabelLength);
                    if (cityLabel)  //If city label exists in DB
                    {
                        fileLine = fileLine.Remove(0, Requirement.MaxCityLabelLength);
                        extractedData = fileLine.Substring(0, 4);
                        if (ZeroFillNumberCheck(extractedData))
                        {
                            hours = Convert.ToDouble(extractedData);
                            hours = hours / 100;
                            fileLine = fileLine.Remove(0, 4);

                            extractedData = fileLine.Substring(0, 4);
                            if (ZeroFillNumberCheck(extractedData))
                            {
                                miles = Convert.ToDouble(extractedData);
                                miles = miles / 100;
                                fileLine = fileLine.Remove(0, 4);

                                if (fileLine == null)
                                {
                                    //HOW DO I SEARCH FOR CITY LABELS
                                    cityLabel.TrimEnd(trim);
                                    file.Close();
                                    //Apply all data
                                }
                                else
                                {
                                    //Reject line
                                    throw new NotImplementedException();
                                }
                            }
                            else
                            {
                                //Reject line
                                throw new NotImplementedException();
                            }

                        }
                        else
                        {
                            //Rejct line
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        //Reject line
                        throw new NotImplementedException();
                    }
                }
            }
            catch (Exception)
            {
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(BatchFileType.City), ActionSource.BatchFile, ActionType.LoadFile, Outcome.FileRejected, countedLines);
            }
        }

    }

    class RouteUpload : BatchFileProcessing
    {
        string actionCode;
        int routeNumber;
        string[] cityLabel = new string[10];

        public void ExtractCityLabels()
        {
            for (int i = 0; i < 10; i++)
            {
                extractedData = fileLine.Substring(0, 20);
                extractedData.TrimEnd(trim);
                if (cityProperties.Exists(extractedData)) //Does this city label exist in the DB
                {
                    cityLabel[i] = extractedData;
                }
                else
                {
                    Array.Clear(cityLabel, 0, 10);
                    //Reject line
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessRouteFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD    
                |action code||Route Number||-----city label-----|*10
                T #ROWS
            */
            RouteFactory routeProperties = RouteFactory.Reference;
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

                if (routeNumber) //Does this routeNumber exist in the DB
                {
                    if (actionCode == "C")
                    {
                        //Erase contents of routeNumber
                        ExtractCityLabels();
                        

                        //Apply cityLabls
                    }
                    else if (actionCode == "D")
                    {
                        if (fileLine == null)
                        {
                            //Delete route
                        }
                        else
                        {
                            //Reject line
                        }
                    }
                }
                else
                {
                    if (actionCode == "A")
                    {
                        ExtractCityLabels();
                        Route newRoute = new Route();
                        newRoute.RouteCities.Clear();
                        //Apply cityLabels
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
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Truck Number|
                T #ROWS
            */

            try
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
                        truckNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                        fileLine.Remove(0, 4);

                        if (fileLine == null)
                        {
                            Truck newTruck = new Truck();
                            newTruck.Number = truckNumber;
                            newTruck.Save();
                            //Apply data
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception)
            {
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Truck), ActionSource.BatchFile, ActionType.AddTruck, Outcome.LineRejected, countedLines);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckFuelFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Truck Number||Fuel Rate|
                T #ROWS
            */

            try
            {
                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();
                countedLines++;

                while (file.EndOfStream != false)
                {
                    fileLine = file.ReadLine();
                    countedLines++;

                    extractedData = fileLine.Substring(0, 4);
                    if (ZeroFillNumberCheck(extractedData))
                    {
                        truckNumber = Convert.ToInt32(extractedData);
                        fileLine.Remove(0, 4);

                        extractedData = fileLine.Substring(0, 4);
                        if (ZeroFillNumberCheck(extractedData))
                        {
                            fuelRate = Convert.ToDouble(extractedData);
                            fuelRate = fuelRate / 100;
                            fileLine.Remove(0, 4);
                            if (fileLine == null)
                            {
                                //Apply data
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            throw new NotImplementedException();
                        } 
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            catch (Exception)
            {
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Truck), ActionSource.BatchFile, ActionType.AddTruck, Outcome.LineRejected, countedLines);
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
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessDriverFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Driver Number||Driver Name||Hourly Rate|
                T #ROWS
            */

            try
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
                                Driver newDriver = new Driver();
                                newDriver.Number = driverNumber;
                                newDriver.Name = driverName;
                                newDriver.HourlyRate = hourlyRate;
                                //Apply data
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            catch (Exception)
            {
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Truck), ActionSource.BatchFile, ActionType.AddTruck, Outcome.LineRejected, countedLines);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckDriverFile(string FilePath)
        {
            /*
               HD SEQ#      YYYY-MM-DD 
               |Truck Number||Driver Number|
               T #ROWS
            */

            try
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
                                //
                                //Apply data
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            catch (Exception)
            {
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(BatchFileType.Truck), ActionSource.BatchFile, ActionType.AddTruck, Outcome.LineRejected, countedLines);
            }
        }
    }

    class TruckRouteUpload : BatchFileProcessing
    {
        int truckNumber;
        int routeNumber;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessTruckRouteFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Truck Number||Route Number|
                T #ROWS
            */

            try
            {
                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();
                countedLines++;

                while (file.EndOfStream != false)
                {
                    fileLine = file.ReadLine();

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
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            catch (Exception)
            {
                Logger.Log(EntityType.BatchFile, Convert.ToInt32(BatchFileType.TruckRoute), ActionSource.BatchFile, ActionType.AddTruckToRoute, Outcome.LineRejected, countedLines);

            }
        }
    }

    class IceCreamTruckUpload : BatchFileProcessing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessIceCreamTruckFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                TR|Truck Number|
                |Item Number||Adjustment Quantity|
                IR #ROWS FOR TRUCK
                T #ROWS IN FILE
            */
        }
    }

    class IceCreamTruckSalesUpload : BatchFileProcessing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessIceCreamTruckSalesFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                TR|Truck Number|
                |Item Number||Final Quantity|
                SR #ROWS FOR TRUCK
                T #ROWS IN FILE
            */
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessPollFile(string FilePath)
        {
            /*
                HD SEQ#		YYYY-MM-DD
                |Poll number|
                |item number||Vote|
                T #ROWS IN FILE
            */
        }
    }

    class InventoryUpdateUpload : BatchFileProcessing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessInventoryUpdateFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Item Number||Warehouse Quantity||Price||Description|
                T #ROWS IN FILE
            */

            int itemNumber;
            int warehouseQuantity;
            double price;
            string description;

            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();

                itemNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                fileLine = fileLine.Remove(0, 5);

                warehouseQuantity = Convert.ToInt32(fileLine.Substring(0, 6));
                fileLine = fileLine.Remove(0, 7);

                price = Convert.ToDouble(fileLine.Substring(0, 4));
                price = price / 100;
                fileLine = fileLine.Remove(0, 5);

                description = fileLine.Substring(0, Requirement.MaxDescription);
                fileLine = fileLine.Remove(0, Requirement.MaxDescription);

                if (fileLine == null)
                {
                    //Check if item exists
                    //Apply data if they both exist
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FilePath"></param>
        public void ProcessInventoryUpdateExtensionFile(string FilePath)
        {
            /*      
                HD SEQ#		YYYY-MM-DD
                |Item number||Item freshness|
                T #ROWS IN FILE
            */
        }
    }
}