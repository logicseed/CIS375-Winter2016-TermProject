/// <project> IceCreamManager </project>
/// <module> Outcomes </module>
/// <author> Marc King </author>
/// <date_created> 2016-04-09 </date_created>

namespace IceCreamManager
{
    // TODO: This should conform to the outcome codes in the data dictionary. Some codes may exist in this list but not
    // in the data dictionary, before the end of the project they should be checked to make sure they all exist in the
    // data dictionary.
    /// <summary>
    ///   An enumeration of outcome codes to allow for outcomes to be stored in the database as integers, but be
    ///   displayed in code as meaningful information.
    /// </summary>
    public enum Outcome
    {
        // Generic outcomes.
        Unknown = -1,

        Failure = 0,
        Success = 1,
        ValueTooSmall = 2,
        ValueTooLarge = 3,

        // Route outcomes
        TooManyCities = 300,
    }
}
