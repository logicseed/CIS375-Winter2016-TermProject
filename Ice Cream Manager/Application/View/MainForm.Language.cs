/// <project> IceCreamManager </project>
/// <module> MainForm.Language </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-25 </date_created>

using System;

namespace IceCreamManager.View
{
    partial class MainForm
    {

        private void LocalizeForm(object sender, EventArgs e)
        {
            Text = "Ice Cream Manager";
            RevenueTab.Text = Language["Revenue"];
            BatchTab.Text = Language["Batch"];
            TrucksTab.Text = Language["Trucks"];
            ItemsTab.Text = Language["Items"];
            DriversTab.Text = Language["Drivers"];
            RoutesTab.Text = Language["Routes"];
            CitiesTab.Text = Language["Cities"];
            StatusLabel.Text = Language["Processing"] + "...";
            MainToolTips.SetToolTip(this.SettingsButton, Language["Settings"]);
            MainToolTips.SetToolTip(this.LogButton, Language["ViewLog"]);
            MainToolTips.SetToolTip(this.AboutButton, Language["About"]);

            switch (MainTabs.SelectedTab.Name)
            {
                case "BatchTab":
                    SetLocalizedBatchStrings();
                    break;
                case "CitiesTab":
                    SetLocalizedCityStrings();
                    break;
                case "DriversTab":
                    SetLocalizedDriverStrings();
                    break;
                case "ItemsTab":
                    SetLocalizedItemStrings();
                    break;
                case "RevenueTab":
                    SetLocalizedRevenueStrings();
                    break;
                case "RoutesTab":
                    SetLocalizedRouteStrings();
                    break;
                case "TrucksTab":
                    SetLocalizedTruckStrings();
                    break;
            }
        }

        private void SetLocalizedCityStrings()
        {
            AddCityButton.Text = Language["Add"];
            EditCityButton.Text = Language["Edit"];
            RemoveCityButton.Text = Language["Remove"];
            ShowDeletedCities.Text = Language["ShowDeleted"];

            CityGridView.Columns["Label"].HeaderText = Language["Label"];
            CityGridView.Columns["Name"].HeaderText = Language["Name"];
            CityGridView.Columns["State"].HeaderText = Language["State"];
            CityGridView.Columns["Miles"].HeaderText = Language["Miles"];
            CityGridView.Columns["Hours"].HeaderText = Language["Hours"];
        }

        private void SetLocalizedDriverStrings()
        {
            AddDriverButton.Text = Language["Add"];
            EditDriverButton.Text = Language["Edit"];
            RemoveDriverButton.Text = Language["Remove"];
            ShowDeletedDrivers.Text = Language["ShowDeleted"];

            DriverGridView.Columns["Number"].HeaderText = Language["Number"];
            DriverGridView.Columns["Name"].HeaderText = Language["Name"];
            DriverGridView.Columns["HourlyRate"].HeaderText = Language["HourlyRate"];
        }

        private void SetLocalizedItemStrings()
        {
            AddItemButton.Text = Language["Add"];
            EditItemButton.Text = Language["Edit"];
            RemoveItemButton.Text = Language["Remove"];
            ShowDeletedItems.Text = Language["ShowDeleted"];

            ItemGridView.Columns["Number"].HeaderText = Language["Number"];
            ItemGridView.Columns["Description"].HeaderText = Language["Description"];
            ItemGridView.Columns["Price"].HeaderText = Language["Price"];
            ItemGridView.Columns["Quantity"].HeaderText = Language["Quantity"];
            ItemGridView.Columns["Lifetime"].HeaderText = Language["Lifetime"];
        }

        private void SetLocalizedRouteStrings()
        {
            AddRouteButton.Text = Language["Add"];
            EditRouteButton.Text = Language["Edit"];
            RemoveRouteButton.Text = Language["Remove"];
            ShowDeletedRoutes.Text = Language["ShowDeleted"];

            RouteGridView.Columns["Number"].HeaderText = Language["Number"];
            RouteGridView.Columns["Cities"].HeaderText = Language["Cities"];
        }

        private void SetLocalizedTruckStrings()
        {
            AddTruckButton.Text = Language["Add"];
            EditTruckButton.Text = Language["Edit"];
            RemoveTruckButton.Text = Language["Remove"];
            DefaultInventoryButton.Text = Language["DefaultInventory"];
            ShowDeletedTrucks.Text = Language["ShowDeleted"];

            TruckGridView.Columns["Number"].HeaderText = Language["Number"];
            TruckGridView.Columns["Driver"].HeaderText = Language["Driver"];
            TruckGridView.Columns["Route"].HeaderText = Language["Route"];
            TruckGridView.Columns["FuelRate"].HeaderText = Language["FuelRate"];
            TruckGridView.Columns["Items"].HeaderText = Language["Items"];
        }

        private void SetLocalizedRevenueStrings()
        {
            StartDateLabel.Text = Language["StartDate"];
            EndDateLabel.Text = Language["EndDate"];
            RouteRevenueLabel.Text = Language["Route"];
            CityRevenueLabel.Text = Language["City"];
            TruckRevenueLabel.Text = Language["Truck"];
            DriverRevenueLabel.Text = Language["Driver"];
            ItemRevenueLabel.Text = Language["Item"];

            RevenueGrid.Columns["Revenue"].HeaderText = Language["Revenue"];
            RevenueGrid.Columns["Date"].HeaderText = Language["Date"];
            RevenueGrid.Columns["Sales"].HeaderText = Language["Sales"];
            RevenueGrid.Columns["ItemWaste"].HeaderText = Language["ItemWaste"];
            RevenueGrid.Columns["FuelUse"].HeaderText = Language["FuelUse"];
            RevenueGrid.Columns["SalaryCost"].HeaderText = Language["SalaryCost"];
        }
    }
}
