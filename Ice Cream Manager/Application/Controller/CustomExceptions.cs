/// <project> IceCreamManager </project>
/// <module> CustomExceptions </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

using System;

namespace IceCreamManager.Exceptions
{
    #region City Property Exceptions

    /// <summary>
    ///   The provided city label does not match requirements. 
    /// </summary>
    [Serializable]
    public class CityLabelInvalidException : Exception
    {
        public CityLabelInvalidException()
        {
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
    public class CityNameInvalidException : Exception
    {
        public CityNameInvalidException()
        {
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
    public class CityStateInvalidException : Exception
    {
        public CityStateInvalidException()
        {
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
    public class CityFuelCostInvalidException : Exception
    {
        public CityFuelCostInvalidException()
        {
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
    public class CityHourCostInvalidException : Exception
    {
        public CityHourCostInvalidException()
        {
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
