using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamManager.Model;

namespace IceCreamManager
{
    /// <summary>
    /// Manages all of the events of the GUI
    /// </summary>
    public sealed class Manage
    {
        #region Singleton
        private static readonly Manage SingletonInstance = new Manage();
        public static Manage Events { get { return SingletonInstance; } }
        private Manage() { }
        #endregion Singleton


        //public event EventHandler OnChangedItemList;
        //public void ChangedItemList(EventArgs e)
        //{
        //    OnChangedItemList?.Invoke(this, e);
        //}

        public event EventHandler OnChangedItemList;
        public void ChangedItemList()
        {
            OnChangedItemList?.Invoke(null, null);
        }

        public event EventHandler OnChangedCityList;
        public void ChangedCityList()
        {
            OnChangedCityList?.Invoke(null, null);
        }

        public event EventHandler OnChangedRouteList;
        public void ChangedRouteList()
        {
            OnChangedRouteList?.Invoke(null, null);
        }

        public event EventHandler OnChangedDriverList;
        public void ChangedDriverList()
        {
            OnChangedDriverList?.Invoke(null, null);
        }

        public event EventHandler OnChangedTruckList;
        public void ChangedTruckList()
        {
            OnChangedTruckList?.Invoke(null, null);
        }

        public event EventHandler OnNewLogEntry;
        public void NewLogEntry()
        {
            OnNewLogEntry?.Invoke(null, null);
        }
    }

    public class EventID : EventArgs
    {
        public int ID;
        public EventID(int ID) { this.ID = ID; }
    }
}
