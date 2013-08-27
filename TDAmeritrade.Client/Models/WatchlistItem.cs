// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WatchlistItem.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System;

    public class WatchlistItem
    {
        public string Symbol { get; set; }

        public int? Quantity { get; set; }

        public double? AveragePrice { get; set; }

        public double? Commission { get; set; }

        public DateTime? OpenDate { get; set; }
    }
}
