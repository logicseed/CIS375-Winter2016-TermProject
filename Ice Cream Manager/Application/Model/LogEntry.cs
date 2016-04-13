/// <project> IceCreamManager </project>
/// <module> LogEntry </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-10 </date_created>

using System;

namespace IceCreamManager.Model
{
    public class LogEntry : DatabaseEntity
    {
        private EntityType mainEntityType;
        private int mainEntityID;
        private EntityType subEntityType = EntityType.None;
        private int subEntityID = 0;
        private ActionSource source;
        private ActionType action;
        private Outcome outcome;
        private int batchFileLine;
        private DateTime dateLogged;

        public LogEntry()
        {
            ID = 0;
        }

        public EntityType MainEntityType
        {
            get
            {
                return mainEntityType;
            }
            set
            {
                mainEntityType = value;
            }
        }

        public int MainEntityID
        {
            get
            {
                return mainEntityID;
            }
            set
            {
                mainEntityID = value;
            }
        }

        public EntityType SubEntityType
        {
            get
            {
                return subEntityType;
            }
            set
            {
                subEntityType = value;
            }
        }

        public int SubEntityID
        {
            get
            {
                return subEntityID;
            }
            set
            {
                subEntityID = value;
            }
        }

        public ActionSource Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }

        public ActionType Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }

        public Outcome Outcome
        {
            get
            {
                return outcome;
            }
            set
            {
                outcome = value;
            }
        }

        public int BatchFileLine
        {
            get
            {
                return batchFileLine;
            }
            set
            {
                batchFileLine = value;
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
        
    }
}
