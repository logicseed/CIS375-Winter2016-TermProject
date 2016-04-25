using System;
using System.Windows.Forms;

namespace IceCreamManager.View
{
    partial class MainForm
    {
        private void LoadCityFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadCityFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadCityFileExtensionButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadCityFileExtension"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadRouteFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadRouteFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadDriverFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadDriverFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadTruckFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadTruckFuelFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckFuelFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadTruckInventoryFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckInventoryFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadOverallInventoryFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadOverallInventoryFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadOverallInventoryExtensionFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadOverallInventoryExtensionFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadTruckDriverFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckDriverFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadTruckRouteFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["LoadTruckRouteFile"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
        }

        private void LoadSalesFileButton_Click(object sender, EventArgs e)
        {
            var fileURI = GetFileURIFromUser(Language["ProcessEndOfDay"]);
            if (fileURI == "") return;

            // use fileURI to call a method to process the file
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
