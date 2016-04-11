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
    public class CityLabelInvalidException : ExceptionWithOutcome
    {
        public CityLabelInvalidException()
        {
        }

        public CityLabelInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityLabelInvalidException(string message) : base(message)
        {
        }

        public CityLabelInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityLabelInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided city name does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityNameInvalidException : ExceptionWithOutcome
    {
        public CityNameInvalidException()
        {
        }

        public CityNameInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityNameInvalidException(string message) : base(message)
        {
        }

        public CityNameInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityNameInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided state does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityStateInvalidException : ExceptionWithOutcome
    {
        public CityStateInvalidException()
        {
        }

        public CityStateInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityStateInvalidException(string message) : base(message)
        {
        }

        public CityStateInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityStateInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided fuel cost does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityMilesInvalidException : ExceptionWithOutcome
    {
        public CityMilesInvalidException()
        {
        }

        public CityMilesInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityMilesInvalidException(string message) : base(message)
        {
        }

        public CityMilesInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityMilesInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided hour cost does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityHoursInvalidException : ExceptionWithOutcome
    {
        public CityHoursInvalidException()
        {
        }

        public CityHoursInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityHoursInvalidException(string message) : base(message)
        {
        }

        public CityHoursInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityHoursInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    #endregion City Property Exceptions

    #region Route Property Exceptions

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
}
