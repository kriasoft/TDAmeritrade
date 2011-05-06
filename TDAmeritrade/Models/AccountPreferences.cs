//-----------------------------------------------------------------------
// <copyright file="AccountPreferences.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents the preference options for the given account.
    /// </summary>
    public struct AccountPreferences
    {
        /// <summary>
        /// Gets a value indicating whether the user has selected Express Trading option on the web site (does not affect API).
        /// </summary>
        public bool IsExpressTrading { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for direct routing options orders.
        /// </summary>
        public bool IsOptionDirectRouting { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for direct routing stock orders.
        /// </summary>
        public bool IsStockDirectRouting { get; internal set; }
    }
}
