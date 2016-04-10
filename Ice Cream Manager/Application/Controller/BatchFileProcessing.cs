///<Author>Rodney Lewis</Author>

using System;
using System.Data;
using System.IO;
using IceCreamManager.Model;

namespace IceCreamManager.Controller
{

    class BatchFileProcessing : DatabaseEntity
    {
        private string fileLine;
        private int countedRecords;
        private char trim = ' ';

        public bool ProcessHeaderFooter(string FilePath)
        {
            /// <summary>
            /// Checks the header and footer of input files. Takes the header and extracts data by columns, counts the number
            /// of records in the file, and then extracts data from footer and compares the counted number of records.       
            /// </summary>
            /// <param name="FilePath">Pathing the input file</param>
            /// <returns>
            /// Returns true if the header and footer pass all if statements
            /// Returns false if at any point it does not pass an if statement
            /// </returns>

            string extractedData;
            string[] recordTypes = new string[] { "IR", "TR", "SR", "T " };
            int sequenceNumber;
            int trailerNumber;
            DateTime date;

            try
            {
                string DatabaseCommand = $"SELECT * FROM batch_file WHERE id = {ID}";
                DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

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

        public void ProcessCityUpload(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |------city label----||------city name-----||state|
                T #ROWS
            */
            string cityLabel;
            string cityName;
            string state;

            try
            {
                StreamReader file = new StreamReader(FilePath);
                fileLine = file.ReadLine();

                while (file.EndOfStream != false && fileLine.Substring(0, 2) != "T ")
                {
                    fileLine = file.ReadLine();

                    cityLabel = fileLine.Substring(0, 20);
                    fileLine = fileLine.Remove(0, 20);

                    cityName = fileLine.Substring(0, 20);
                    fileLine = fileLine.Remove(0, 20);

                    state = fileLine.Substring(0, 2);
                    fileLine = fileLine.Remove(0, 2);

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

        public void ProcessRouteUpload(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD    
                |action code||Route Number||-----city label-----|*10
                T #ROWS
            */
            string DatabaseCommand = $"SELECT * FROM city WHERE id = {ID}";
            DataTable ResultsTable = Database.DataTableFromCommand(DatabaseCommand);

            string actionCode;
            int routeNumber;
            string[] cityLabel = new string[10];

            StreamReader file = new StreamReader(FilePath);
            fileLine = file.ReadLine();

            while (file.EndOfStream != false)
            {
                fileLine = file.ReadLine();

                actionCode = fileLine.Substring(0, 1);
                fileLine = fileLine.Remove(0, 1);

                routeNumber = Convert.ToInt32(fileLine.Substring(0, 4));
                fileLine = fileLine.Remove(0, 4);

                if (actionCode == "A")
                {
                   
                }
                else if (actionCode == "C")
                {

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
                        throw new Exception();
                    }
                }

                if (fileLine == null)
                {
                    //Apply all data

                }
                else
                {
                    //Reject line
                }
            }
            file.Close();
        }

        public void ProcessTruckUpload(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Truck Number|
                T #ROWS
            */
        }

        public void ProcessTruckRouteUpload(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Truck Number||Route Number|
                T #ROWS
            */
        }

        public void ProcessIceCreamTruck(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                TR|Truck Number|
                |Item Number||Adjustment Quantity|
                IR #ROWS FOR TRUCK
                T #ROWS IN FILE
            */
        }

        public void ProcessIceCreamTruckSales(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                TR|Truck Number|
                |Item Number||Final Quantity|
                SR #ROWS FOR TRUCK
                T #ROWS IN FILE
            */
        }

        public void ProcessInventoryUpdate(string FilePath)
        {
            /*
                HD SEQ#      YYYY-MM-DD 
                |Item Number||Warehouse Quantity||Price||Description|
                T #ROWS IN FILE
            */
        }

        public void ProcessPoll(string FilePath)
        {
            /*
                HD SEQ#		YYYY-MM-DD
                |Poll number||item number|
                T #ROWS IN FILE
            */
        }

        public void ProcessDriver(string FilePath)
        {
            /*
                HD SEQ#		YYYY-MM-DD
                |Driver Number||Driver Name|
                T #ROWS IN FILE
            */
        }

        public void ProcessInventoryUpdateExtension(string FilePath)
        {
            /*      
                HD SEQ#		YYYY-MM-DD
                |Item number||Item freshness|
                T #ROWS IN FILE
            */
        }

        public void ProcessCityUploadExtension(string FilePath)
        {
            /*
                HD SEQ#		YYYY-MM-DD
                |City label||Fuel usage||hourly cost|
            */
        }



        protected override string TableName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string CreateCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected override string UpdateCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool Load(int ID)
        {
            throw new NotImplementedException();
        }

        public override bool Fill(DatabaseEntityProperties EntityProperties)
        {
            throw new NotImplementedException();
        }
    }
}