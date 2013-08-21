// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountAuthorizations.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Container for the Authorizations for the given account.
    /// </summary>
    public class AccountAuthorizations
    {
        /// <summary>
        /// Gets a value indicating whether or not the account has APEX status.
        /// </summary>
        public bool Apex { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is authorized for Level 2 quotes (NASDAQ Level II).
        /// </summary>
        public bool Level2 { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for stock trading.
        /// </summary>
        public bool StockTrading { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for MARGIN trading. If false, then its a CASH account.
        /// </summary>
        public bool MarginTrading { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for streaming news.
        /// </summary>
        public bool StreamingNews { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for options trading. If so, then the type of permissions.
        /// </summary>
        public OptionTradingType OptionTrading { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for streaming data access.
        /// </summary>
        public bool Streamer { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account will use a new middleware (AMX-TIBCO) for margin computation.
        /// </summary>
        public bool AdvancedMargin { get; internal set; }
    }
}
