///<Author>Rodney Lewis</Author>

using System;
using System.Data;
using System.IO;
using IceCreamManager.Model;

namespace IceCreamManager.Controller
{
    class BatchFileProcessing
    {
        public string fileLine;
        public int countedRecords;
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
        DateTime date;

        public bool ProcessHeaderFooter(string FilePath)
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

                extractedData = fileLine.Substring(0, 2);
                if (extractedData == "HD")
                {
                    fileLine = fileLine.Remove(0, 3);
                    sequenceNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                    if (sequenceNumber == ResultsTable.Row(0).Col<int>("sequence_number"))
                    {
                        fileLine = fileLine.Remove(0, 10);
                        date = Convert.ToDateTime(fileLine.Substring(0, 10));
                        if (date >= ResultsTable.Row(0).Col<DateTime>("date"))
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
                                            countedRecords++;
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
                                        return true;
                                    }
                                }
                            }
                            else
                            {
                                file.Close();
                                throw new ArgumentOutOfRangeException();
                                //Reject file 
                            }
                        }
                        else
                        {
                            file.Close();
                            throw new InvalidDataException();
                            //Reject file 
                        }
                    }
                    else
                    {
                        file.Close();
                        throw new Exception();
                        //Reject file 
                    }
                }
                else
                {
                    file.Close();
                    throw new Exception();
                    //Reject file 
                }
                return false;
            }
            catch (Exception)
            {
                //Write to log file with exception code
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

                while (file.EndOfStream != false || fileLine.Substring(0, 2) != "T ")
                {
                    fileLine = file.ReadLine();

                    cityLabel = fileLine.Substring(0, Requirement.MaxLabelLength);
                    fileLine = fileLine.Remove(0, Requirement.MaxLabelLength);

                    cityName = fileLine.Substring(0, Requirement.MaxLabelLength);
                    fileLine = fileLine.Remove(0, Requirement.MaxLabelLength);

                    state = fileLine.Substring(0, Requirement.MaxStateLength);
                    fileLine = fileLine.Remove(0, Requirement.MaxStateLength);

                    if (fileLine == null)
                    {
                        cityLabel.TrimEnd(trim);
                        cityName.TrimEnd(trim);
                        //Apply all data
                    }
                    else
                    {
                        //Reject line
                    }
                }
                file.Close();
            }
            catch (Exception)
            {

                throw;
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

                while (file.EndOfStream != false || fileLine.Substring(0, 2) != "T ")
                {
                    fileLine = file.ReadLine();

                    cityLabel = fileLine.Substring(0, Requirement.MaxLabelLength);
                    if (cityLabel != null)  //If city label exists in DB
                    {
                        fileLine = fileLine.Remove(0, Requirement.MaxLabelLength);
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
                                    cityLabel.TrimEnd(trim);
                                    file.Close();
                                    //Apply all data
                                }
                                else
                                {
                                    //Reject line
                                }
                            }
                            else
                            {
                                //Reject line
                            }
                           
                        }
                        else
                        {
                            //Rejct line
                        }
                    }
                    else
                    {
                        //Reject line
                    }
                }     
            }
            catch (Exception)
            {
                throw;
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
                if (extractedData) //Does this city label exist in the DB
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

            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();

                actionCode = fileLine.Substring(0, 1);
                fileLine = fileLine.Remove(0, 1);

                routeNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                fileLine = fileLine.Remove(0, 4);

                if (routeNumber)  //Does this routeNumber exist in the DB
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
                        //Apply cityLabels
                    }
                }
            }
            file.Close();
        }
    }

    class TruckUpload:BatchFileProcessing
    {
        int truckNumber;
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

            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();
                truckNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                fileLine.Remove(0, 4);

                if (fileLine == null)
                {
                    //Apply data
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
        public void ProcessTruckFuelFile(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Truck Number||Fuel Rate|
                T #ROWS
            */
        }

    }

    class DriverUpload : BatchFileProcessing
    {
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

                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();

                while (file.EndOfStream != false)
                {
                    fileLine = file.ReadLine();

                    truckNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                    fileLine = fileLine.Remove(0, 4);

                    routeNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                    fileLine = fileLine.Remove(0, 4);

                    if (fileLine == null)
                    {
                        //Check if truck and route exist
                            //Apply data if they both exist
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
        }
    }

    class IceCreamTruckUpload:BatchFileProcessing
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