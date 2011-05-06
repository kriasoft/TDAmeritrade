//-----------------------------------------------------------------------
// <copyright file="AccountAuthorizations.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Container for the Authorizations for the given account.
    /// </summary>
    public struct AccountAuthorizations
    {
        /// <summary>
        /// Denotes whether or not the account has APEX status.
        /// </summary>
        public bool Apex;

        /// <summary>
        /// Indicates whether the account is authorized for Level 2 quotes (NASDAQ Level II).
        /// </summary>
        public bool Level2;

        /// <summary>
        /// Indicates if the account is enabled for stock trading.
        /// </summary>
        public bool StockTrading;

        /// <summary>
        /// Indicates if the account is enabled for MARGIN trading. If false, then its a CASH account.
        /// </summary>
        public bool MarginTrading;

        /// <summary>
        /// Indicates if the account is enabled for streaming news.
        /// </summary>
        public bool StreamingNews;

        /// <summary>
        /// Indicates if the account is enabled for options trading. If so, then the type of permissions.
        /// </summary>
        public OptionTradingType OptionTrading;

        /// <summary>
        /// Indicates if the account is enabled for streaming data access.
        /// </summary>
        public bool Streamer;

        /// <summary>
        /// Indicates if the account will use a new middleware (AMX-TIBCO) for margin computation.
        /// </summary>
        public bool AdvancedMargin;
    }
}
