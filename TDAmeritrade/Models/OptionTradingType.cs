//-----------------------------------------------------------------------
// <copyright file="OptionTradingType.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Option trading type enumeration.
    /// </summary>
    public enum OptionTradingType
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Long
        /// </summary>
        Long,
        /// <summary>
        /// Covered
        /// </summary>
        Covered,
        /// <summary>
        /// Spread
        /// </summary>
        Spread,
        /// <summary>
        /// Full
        /// </summary>
        Full
    }
}
