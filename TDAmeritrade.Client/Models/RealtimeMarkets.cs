// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RealtimeMarkets.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
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
