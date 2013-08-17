// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionQuote.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Xml.Serialization;

    [XmlRoot("quote", Namespace = "")]
    public class OptionQuote
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

        [XmlElement("strike-price")]
        public float StrikePrice { get; set; }

        [XmlElement("open-interest")]
        public int OpenInterest { get; set; }

        [XmlElement("expiration-month")]
        public int ExpirationMonth { get; set; }

        [XmlElement("expiration-day")]
        public int ExpirationDay { get; set; }

        [XmlElement("expiration-year")]
        public int ExpirationYear { get; set; }

        [XmlElement("real-time")]
        public bool IsRealTime { get; set; }

        [XmlElement("exchange")]
        public string Exchange { get; set; }

        [XmlElement("underlying-symbol")]
        public string UnderlyingSymbol { get; set; }

        [XmlElement("delta")]
        public float Delta { get; set; }

        [XmlElement("gamma")]
        public float Gamma { get; set; }

        [XmlElement("theta")]
        public float Theta { get; set; }

        [XmlElement("vega")]
        public float Vega { get; set; }

        [XmlElement("rho")]
        public float Rho { get; set; }

        [XmlElement("implied-volatility")]
        public float ImpliedVolatitily { get; set; }

        [XmlElement("days-to-expiration")]
        public int DaysToExpiration { get; set; }

        [XmlElement("time-value-index")]
        public float TimeValueIndex { get; set; }

        [XmlElement("multiplier")]
        public float Multiplier { get; set; }
    }
}
