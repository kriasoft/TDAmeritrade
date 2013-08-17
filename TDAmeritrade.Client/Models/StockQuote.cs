// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockQuote.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Xml.Serialization;

    [XmlRoot("quote", Namespace = "")]
    public class StockQuote
    {
        [XmlElement("symbol")]
        public string Symbol { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("bid")]
        public float Bid { get; set; }

        [XmlElement("ask")]
        public float Ask { get; set; }

        [XmlElement("bid-ask-size")]
        public string BidAskSize { get; set; }

        [XmlElement("last")]
        public float Last { get; set; }

        [XmlElement("last-trade-size")]
        public int LastTradeSize { get; set; }

        [XmlElement("last-trade-date")]
        public string LastTradeDate { get; set; }

        [XmlElement("open")]
        public float Open { get; set; }

        [XmlElement("high")]
        public float High { get; set; }

        [XmlElement("low")]
        public float Low { get; set; }

        [XmlElement("close")]
        public float Close { get; set; }

        [XmlElement("volume")]
        public long Volume { get; set; }

        [XmlElement("year-high")]
        public float YearHigh { get; set; }

        [XmlElement("year-low")]
        public float YearLow { get; set; }

        [XmlElement("real-time")]
        public bool IsRealTime { get; set; }

        [XmlElement("exchange")]
        public string Exchange { get; set; }

        [XmlElement("change")]
        public float Change { get; set; }

        [XmlElement("change-percent")]
        public string ChangePercent { get; set; }
    }
}
