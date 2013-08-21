// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionTradingType.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Option trading type enumeration.
    /// </summary>
    public enum OptionTradingType
    {
        None,
        Long,
        Covered,
        Spread,
        Full
    }
}
