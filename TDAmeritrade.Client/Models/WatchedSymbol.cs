// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WatchlistSymbol.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public class WatchedSymbol
    {
        /// <summary>
        /// Gets or sets the number of units in the position. Field may have up to 3 digits to the right of the decimal point.
        /// </summary>
        [XmlElement("quantity")]
        public double Quantity { get; set; }

        [XmlElement("security")]
        public SecurityNode Security { get; set; }

        /// <summary>
        /// Gets or sets position type: LONG or SHORT
        /// </summary>
        [XmlElement("position-type")]
        public PositionType PositionType { get; set; }

        /// <summary>
        /// Gets or sets the value calculated by dividing the total cost to acquire the position by the number of units
        /// in the position. The field may contain up to six digits to the right of the decimal point.
        /// </summary>
        [XmlElement("average-price")]
        public double AveragePrice { get; set; }

        [XmlElement("commission")]
        public double Commission { get; set; }

        /// <summary>
        /// Gets or sets the value indicating when the "position" was opened.
        /// </summary>
        [XmlElement("open-date")]
        public string OpenDate { get; set; }

        public class SecurityNode
        {
            [XmlElement("symbol")]
            public string Symbol { get; set; }

            [XmlElement("symbol-with-type-prefix")]
            public string SymbolWithTypePrefix { get; set; }

            [XmlElement("description")]
            public string Description { get; set; }

            [XmlElement("asset-type")]
            public AssetType AssetType { get; set; }
        }
    }
}
