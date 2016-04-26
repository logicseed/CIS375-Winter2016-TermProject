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

            SetLocalizedBatchStrings();
            SetLocalizedCityStrings();
            SetLocalizedDriverStrings();
            SetLocalizedItemStrings();
            SetLocalizedRevenueStrings();
            SetLocalizedRouteStrings();
            SetLocalizedTruckStrings();

        }

        private void SetLocalizedCityStrings()
        {
            AddCityButton.Text = Language["Add"];
            EditCityButton.Text = Language["Edit"];
            RemoveCityButton.Text = Language["Remove"];
            ShowDeletedCities.Text = Language["ShowDeleted"];

        }

        private void SetLocalizedDriverStrings()
        {
            AddDriverButton.Text = Language["Add"];
            EditDriverButton.Text = Language["Edit"];
            RemoveDriverButton.Text = Language["Remove"];
            ShowDeletedDrivers.Text = Language["ShowDeleted"];
        }

        private void SetLocalizedItemStrings()
        {
            AddItemButton.Text = Language["Add"];
            EditItemButton.Text = Language["Edit"];
            RemoveItemButton.Text = Language["Remove"];
            ShowDeletedItems.Text = Language["ShowDeleted"];
        }

        private void SetLocalizedRouteStrings()
        {
            AddRouteButton.Text = Language["Add"];
            EditRouteButton.Text = Language["Edit"];
            RemoveRouteButton.Text = Language["Remove"];
            ShowDeletedRoutes.Text = Language["ShowDeleted"];
        }

        private void SetLocalizedTruckStrings()
        {
            AddTruckButton.Text = Language["Add"];
            EditTruckButton.Text = Language["Edit"];
            RemoveTruckButton.Text = Language["Remove"];
            DefaultInventoryButton.Text = Language["DefaultInventory"];
            ShowDeletedTrucks.Text = Language["ShowDeleted"];
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
        }
    }
}

