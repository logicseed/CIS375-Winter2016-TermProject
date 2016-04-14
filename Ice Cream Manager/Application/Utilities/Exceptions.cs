/// <project> IceCreamManager </project>
/// <module> CustomExceptions </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System;

namespace IceCreamManager
{
    [Serializable]
    public class ExceptionWithOutcome : Exception
    {
        public ExceptionWithOutcome()
        {
        }

        public ExceptionWithOutcome(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public ExceptionWithOutcome(string message) : base(message)
        {
        }

        public ExceptionWithOutcome(string message, Exception inner) : base(message, inner)
        {
        }

        protected ExceptionWithOutcome(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }

        protected Outcome Outcome { get; set; }
    }

    #region City Property Exceptions

    /// <summary>
    ///   The provided city label does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityLabelException : ExceptionWithOutcome
    {
        public CityLabelException()
        {
        }

        public CityLabelException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityLabelException(string message) : base(message)
        {
        }

        public CityLabelException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityLabelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided city name does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityNameException : ExceptionWithOutcome
    {
        public CityNameException()
        {
        }

        public CityNameException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityNameException(string message) : base(message)
        {
        }

        public CityNameException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided state does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityStateException : ExceptionWithOutcome
    {
        public CityStateException()
        {
        }

        public CityStateException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityStateException(string message) : base(message)
        {
        }

        public CityStateException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityStateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided fuel cost does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityMilesException : ExceptionWithOutcome
    {
        public CityMilesException()
        {
        }

        public CityMilesException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityMilesException(string message) : base(message)
        {
        }

        public CityMilesException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityMilesException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided hour cost does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityHoursException : ExceptionWithOutcome
    {
        public CityHoursException()
        {
        }

        public CityHoursException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityHoursException(string message) : base(message)
        {
        }

        public CityHoursException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityHoursException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    #endregion City Property Exceptions

    #region Route Property Exceptions


    [Serializable]
    public class RouteExistenceException : ExceptionWithOutcome
    {
        public RouteExistenceException() { }
        public RouteExistenceException(Outcome ExceptionOutcome) { Outcome = ExceptionOutcome; }
        public RouteExistenceException(string message) : base(message) { }
        public RouteExistenceException(string message, Exception inner) : base(message, inner) { }
        protected RouteExistenceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   Trying to add too many cities. 
    /// </summary>
    [Serializable]
    public class RouteCityCountException : ExceptionWithOutcome
    {
        public RouteCityCountException()
        {
        }

        public RouteCityCountException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public RouteCityCountException(string message) : base(message)
        {
        }

        public RouteCityCountException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RouteCityCountException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided number does not match requirements. 
    /// </summary>
    [Serializable]
    public class RouteNumberInvalidException : ExceptionWithOutcome
    {
        public RouteNumberInvalidException()
        {
        }

        public RouteNumberInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public RouteNumberInvalidException(string message) : base(message)
        {
        }

        public RouteNumberInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected RouteNumberInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    #endregion Route Property Exceptions

    #region Item Property Exceptions

    [Serializable]
    public class ItemNumberException : ExceptionWithOutcome
    {
        public ItemNumberException()
        {
        }

        public ItemNumberException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public ItemNumberException(string message) : base(message)
        {
        }

        public ItemNumberException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ItemNumberException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    [Serializable]
    public class ItemDescriptionException : ExceptionWithOutcome
    {
        public ItemDescriptionException()
        {
        }

        public ItemDescriptionException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public ItemDescriptionException(string message) : base(message)
        {
        }

        public ItemDescriptionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ItemDescriptionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    [Serializable]
    public class ItemPriceException : ExceptionWithOutcome
    {
        public ItemPriceException()
        {
        }

        public ItemPriceException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public ItemPriceException(string message) : base(message)
        {
        }

        public ItemPriceException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ItemPriceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    [Serializable]
    public class ItemLifetimeException : ExceptionWithOutcome
    {
        public ItemLifetimeException()
        {
        }

        public ItemLifetimeException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public ItemLifetimeException(string message) : base(message)
        {
        }

        public ItemLifetimeException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ItemLifetimeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    [Serializable]
    public class ItemQuantityException : ExceptionWithOutcome
    {
        public ItemQuantityException()
        {
        }

        public ItemQuantityException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public ItemQuantityException(string message) : base(message)
        {
        }

        public ItemQuantityException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ItemQuantityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    #endregion Item Property Exceptions

    #region BatchHistory Exceptions

    [Serializable]
    public class BatchHistorySequenceException : ExceptionWithOutcome
    {
        public BatchHistorySequenceException()
        {
        }

        public BatchHistorySequenceException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public BatchHistorySequenceException(string message) : base(message)
        {
        }

        public BatchHistorySequenceException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BatchHistorySequenceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    [Serializable]
    public class BatchHistoryDateUpdatedException : ExceptionWithOutcome
    {
        public BatchHistoryDateUpdatedException()
        {
        }

        public BatchHistoryDateUpdatedException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public BatchHistoryDateUpdatedException(string message) : base(message)
        {
        }

        public BatchHistoryDateUpdatedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BatchHistoryDateUpdatedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    #endregion BatchHistory Exceptions

    #region Driver Exceptions

    [Serializable]
    public class DriverNumberException : ExceptionWithOutcome
    {
        public DriverNumberException()
        {
        }

        public DriverNumberException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public DriverNumberException(string message) : base(message)
        {
        }

        public DriverNumberException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DriverNumberException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    [Serializable]
    public class DriverNameException : ExceptionWithOutcome
    {
        public DriverNameException()
        {
        }

        public DriverNameException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public DriverNameException(string message) : base(message)
        {
        }

        public DriverNameException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DriverNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    [Serializable]
    public class DriverHourlyRateException : ExceptionWithOutcome
    {
        public DriverHourlyRateException()
        {
        }

        public DriverHourlyRateException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public DriverHourlyRateException(string message) : base(message)
        {
        }

        public DriverHourlyRateException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DriverHourlyRateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    #endregion Driver Exceptions

    #region TruckExceptions


    [Serializable]
    public class TruckNumberException : ExceptionWithOutcome
    {
        public TruckNumberException() { }
        public TruckNumberException(Outcome ExceptionOutcome) { Outcome = ExceptionOutcome; }
        public TruckNumberException(string message) : base(message) { }
        public TruckNumberException(string message, Exception inner) : base(message, inner) { }
        protected TruckNumberException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }


    [Serializable]
    public class TruckFuelRateException : ExceptionWithOutcome
    {
        public TruckFuelRateException() { }
        public TruckFuelRateException(Outcome ExceptionOutcome) { Outcome = ExceptionOutcome; }
        public TruckFuelRateException(string message) : base(message) { }
        public TruckFuelRateException(string message, Exception inner) : base(message, inner) { }
        protected TruckFuelRateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }


    [Serializable]
    public class TruckInventoryCountException : ExceptionWithOutcome
    {
        public TruckInventoryCountException() { }
        public TruckInventoryCountException(Outcome ExceptionOutcome) { Outcome = ExceptionOutcome; }
        public TruckInventoryCountException(string message) : base(message) { }
        public TruckInventoryCountException(string message, Exception inner) : base(message, inner) { }
        protected TruckInventoryCountException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }


    #endregion
}
