using System;
using System.Windows.Forms;
using IceCreamManager.Controller;

namespace IceCreamManager.View
{
    partial class MainForm
    {
        HeaderFooter newFile = new HeaderFooter();
        CityUpload cityFiles = new CityUpload();
        RouteUpload routeFiles = new RouteUpload();
        TruckUpload truckFiles = new TruckUpload();
        DriverUpload driverFiles = new DriverUpload();
        IceCreamTruckUpload iceCreamTruckFiles = new IceCreamTruckUpload();
        IceCreamTruckSalesUpload salesFiles = new IceCreamTruckSalesUpload();
        InventoryUpdateUpload inventoryFiles = new InventoryUpdateUpload();


        private void LoadCityFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadCityFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.City))
                cityFiles.ProcessCityFile(fileURI);
        }

        private void LoadCityFileExtensionButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadCityFileExtension"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.CityExtension))
                cityFiles.ProcessCityFileExtension(fileURI);
        }

        private void LoadRouteFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadRouteFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.Route))
                routeFiles.ProcessRouteFile(fileURI);
        }

        private void LoadDriverFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadDriverFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.Driver))
                driverFiles.ProcessDriverFile(fileURI);
        }

        private void LoadTruckFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.Truck))
                truckFiles.ProcessTruckFile(fileURI);
        }

        private void LoadTruckFuelFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckFuelFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.TruckFuel))
                truckFiles.ProcessTruckFuelFile(fileURI);
        }

        private void LoadTruckInventoryFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckInventoryFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.TruckInventory))
                iceCreamTruckFiles.ProcessIceCreamTruckFile(fileURI);
        }

        private void LoadOverallInventoryFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadOverallInventoryFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.OverallInventory))
                inventoryFiles.ProcessInventoryUpdateFile(fileURI);
        }

        private void LoadOverallInventoryExtensionFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadOverallInventoryExtensionFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.OverallIventoryExtension))
                inventoryFiles.ProcessInventoryUpdateExtensionFile(fileURI);
        }

        private void LoadTruckDriverFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckDriverFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.TruckDriver))
                truckFiles.ProcessTruckDriverFile(fileURI);
        }

        private void LoadTruckRouteFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckRouteFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.TruckRoute))
                truckFiles.ProcessTruckRouteFile(fileURI);
        }

        private void LoadSalesFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["ProcessEndOfDay"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
            if (newFile.ProcessHeaderFooter(fileURI, BatchFileType.Sales))
                salesFiles.ProcessIceCreamTruckSalesFile(fileURI);
        }

        private void ProcessStartOfDayButton_Click(object sender, EventArgs e)
        {
            // 
        }

        private void ProcessEndOfDayButton_Click(object sender, EventArgs e)
        {
            // process item waste, fuel use, and salary cost
        }

        private void SetLocalizedBatchStrings()
        {
            ProcessStartOfDayButton.Text = Language["ProcessStartOfDay"];
            LoadCityFileButton.Text = Language["LoadCityFile"];
            LoadCityFileExtensionButton.Text = Language["LoadCityFileExtension"];
            LoadRouteFileButton.Text = Language["LoadRouteFile"];
            LoadDriverFileButton.Text = Language["LoadDriverFile"];
            LoadTruckFileButton.Text = Language["LoadTruckFile"];
            LoadTruckFuelFileButton.Text = Language["LoadTruckFuelFile"];
            LoadTruckInventoryFileButton.Text = Language["LoadTruckInventoryFile"];
            LoadOverallInventoryFileButton.Text = Language["LoadOverallInventoryFile"];
            LoadOverallInventoryExtensionFileButton.Text = Language["LoadOverallInventoryExtensionFile"];
            LoadTruckDriverFileButton.Text = Language["LoadTruckDriverFile"];
            LoadTruckRouteFileButton.Text = Language["LoadTruckRouteFile"];
            LoadSalesFileButton.Text = Language["LoadSalesFile"];
            ProcessEndOfDayButton.Text = Language["ProcessEndOfDay"];
        }

        private string GetFileURIFromUser(string title)
        {
            string fileURI = "";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = $"{Language["BatchFiles"]}|*.TXT|{Language["AllFiles"]}|*.*";
            fileDialog.FilterIndex = 1;
            fileDialog.Title = title;

            DialogResult dialogResult = fileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                fileURI = fileDialog.FileName;
            }

            return fileURI;
        }
    }
}