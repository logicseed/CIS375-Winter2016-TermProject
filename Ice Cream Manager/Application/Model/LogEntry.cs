/// <project> IceCreamManager </project>
/// <module> LogEntry </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class LogEntry : DatabaseEntity
    {
        private string message;
        private bool success;
        private DateTime dateLogged;

        public LogEntry()
        {
            ID = 0;
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public bool Success
        {
            get
            {
                return success;
            }
            set
            {
                success = value;
            }
        }

        public DateTime DateLogged
        {
            get
            {
                return dateLogged;
            }
            set
            {
                dateLogged = value;
            }
        }

        public override bool Save()
        {
            return Factory.Log.Save(this);
        }
    }
}
