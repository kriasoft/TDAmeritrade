//-----------------------------------------------------------------------
// <copyright file="OHLCQuote.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System;

    /// <summary>
    /// Quote in OHLC format.
    /// </summary>
    public struct OHLCQuote
    {
        /// <summary>
        /// Opening price
        /// </summary>
        public float Open;

        /// <summary>
        /// Highest price
        /// </summary>
        public float High;

        /// <summary>
        /// Lowest price
        /// </summary>
        public float Low;

        /// <summary>
        /// Closing price
        /// </summary>
        public float Close;

        /// <summary>
        /// Volume number
        /// </summary>
        public long Volume;

        /// <summary>
        /// Date and time
        /// </summary>
        public DateTime Date;
    }
}
