//-----------------------------------------------------------------------
// <copyright file="RealtimeMarkets.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    /// <summary>
    /// Contains a list of markets and values indicating whether a real-time data is available for each of them.
    /// </summary>
    public class RealtimeMarkets
    {
        /// <summary>
        /// Gets a value indicating whether real-time streaming data is available for NYSE market.
        /// </summary>
        public bool NYSE { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether real-time streaming data is available for NASDAQ market.
        /// </summary>
        public bool NASDAQ { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether real-time streaming data is available for OPRA market.
        /// </summary>
        public bool OPRA { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether real-time streaming data is available for AMEX market.
        /// </summary>
        public bool AMEX { get; internal set; }
    }
}
