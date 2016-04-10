/// <project> IceCreamManager </project>
/// <module> CustomExceptions </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System;
using IceCreamManager.Controller;

namespace IceCreamManager.Exceptions
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
    public class CityFuelCostInvalidException : ExceptionWithOutcome
    {
        public CityFuelCostInvalidException()
        {
        }

        public CityFuelCostInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityFuelCostInvalidException(string message) : base(message)
        {
        }

        public CityFuelCostInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityFuelCostInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    ///   The provided hour cost does not match requirements. 
    /// </summary>

    [Serializable]
    public class CityHourCostInvalidException : ExceptionWithOutcome
    {
        public CityHourCostInvalidException()
        {
        }

        public CityHourCostInvalidException(Outcome ExceptionOutcome)
        {
            Outcome = ExceptionOutcome;
        }

        public CityHourCostInvalidException(string message) : base(message)
        {
        }

        public CityHourCostInvalidException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CityHourCostInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    #endregion City Property Exceptions
}
