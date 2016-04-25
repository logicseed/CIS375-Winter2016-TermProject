using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManager.Model;

namespace IceCreamManager.View
{
    partial class MainForm
    {

        private void LocalizeForm(object sender, EventArgs e)
        {
            Text = "!Ice Cream Manager";
            RevenueTab.Text = "!Revenue";
            TrucksTab.Text = "!Trucks";
            ItemsTab.Text = "!Items";
            DriversTab.Text = "!Drivers";
            RoutesTab.Text = "!Routes";
            CitiesTab.Text = "!Cities";
            StatusLabel.Text = "!Processing...";
            MainToolTips.SetToolTip(this.SettingsButton, "!Settings");
            MainToolTips.SetToolTip(this.LogButton, "!View Log");
            MainToolTips.SetToolTip(this.AboutButton, "!About");
        }

        private void SetLocalizedCityStrings()
        {
            AddCityButton.Text = "!Add";
            EditCityButton.Text = "!Edit";
            RemoveCityButton.Text = "!Remove";
            ShowDeletedCities.Text = "!Show Deleted";

        }

        private void SetLocalizedDriverStrings()
        {
            AddDriverButton.Text = "!Add";
            EditDriverButton.Text = "!Edit";
            RemoveDriverButton.Text = "!Remove";
            ShowDeletedDrivers.Text = "!Show Deleted";
        }

        private void SetLocalizedItemStrings()
        {
            AddItemButton.Text = "!Add";
            EditItemButton.Text = "!Edit";
            RemoveItemButton.Text = "!Remove";
            ShowDeletedItems.Text = "!Show Deleted";
        }

        private void SetLocalizedRouteStrings()
        {
            AddRouteButton.Text = "!Add";
            EditRouteButton.Text = "!Edit";
            RemoveRouteButton.Text = "!Remove";
            ShowDeletedRoutes.Text = "!Show Deleted";
        }

        private void SetLocalizedTruckStrings()
        {
            AddTruckButton.Text = "!Add";
            EditTruckButton.Text = "!Edit";
            RemoveTruckButton.Text = "!Remove";
            DefaultInventoryButton.Text = "!Default Inventory";
            ShowDeletedTrucks.Text = "!Show Deleted";
        }

        private void SetLocalizedRevenueStrings()
        {
            StartDateLabel.Text = "!Start Date";
            EndDateLabel.Text = "!End Date";
            RouteRevenueLabel.Text = "!Route";
            CityRevenueLabel.Text = "!City";
            TruckRevenueLabel.Text = "!Truck";
            DriverRevenueLabel.Text = "!Driver";
            ItemRevenueLabel.Text = "!Item";
        }

        private void SetLocalizedBatchStrings()
        {
            BatchTab.Text = "!Batch";
        }
    }
}
