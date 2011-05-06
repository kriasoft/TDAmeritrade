//-----------------------------------------------------------------------
// <copyright file="Quote.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Container for detailed quote fields.
    /// </summary>
    [DataContract(Name = "quote", Namespace = "")]
    public struct Quote
    {
        /// <summary>
        /// Symbol of the security being quoted. For example, "DELL".
        /// </summary>
        [DataMember(Name = "symbol", Order = 0)]
        public string Symbol;

        /// <summary>
        /// Contains a description of the symbol. For example, "DELL INC COM
        /// Status Alert: Delinquent:" The string "Status Alert:" is appended to
        /// each description except for asset type "F" when an FSI flag is set on a
        /// symbol. Any text following this string specifies some trading status message.
        /// </summary>
        [DataMember(Name = "description", Order = 1)]
        public string Description;

        /// <summary>
        /// The highest price anyone has declared that they are willing to pay for a security.
        /// </summary>
        [DataMember(Name = "bid", Order = 2)]
        public double Bid;

        /// <summary>
        /// The lowest price anyone will offer to sell a security.
        /// </summary>
        [DataMember(Name = "ask", Order = 3)]
        public double Ask;

        /// <summary>
        /// The size of the  bid/ask  shows how many shares the market has available at those prices.
        /// The value is displayed as "bid qty X ask qty". For example, "3900X1800".
        /// </summary>
        [DataMember(Name = "bid-ask-size", Order = 4)]
        public string BidAskSize;

        /// <summary>
        /// The price of the last trade for this symbol.
        /// </summary>
        [DataMember(Name = "last", Order = 5)]
        public double Last;

        /// <summary>
        /// The number of shares traded at the last price.
        /// </summary>
        [DataMember(Name = "last-trade-size", Order = 6)]
        public long LastTradeSize;

        /// <summary>
        /// The date and time of the last trade. For example, "2006-06-30 14:36:27 EDT".
        /// </summary>
        [DataMember(Name = "last-trade-date", Order = 7)]
        public DateTime LastTradeDate;

        /// <summary>
        /// The price of the first trade at normal market open. Extended hours' trading is not reflected in this value.
        /// </summary>
        [DataMember(Name = "open", Order = 8)]
        public double Open;

        /// <summary>
        /// The highest price trade for the symbol during the normal trading session.
        /// If the session is still open this represents the highest price to the time of the quote.
        /// </summary>
        [DataMember(Name = "high", Order = 9)]
        public double High;

        /// <summary>
        /// The lowest price trade for the symbol during the normal trading session.
        /// If the session is still open this represents the lowest price to the time of the quote.
        /// </summary>
        [DataMember(Name = "low", Order = 10)]
        public double Low;

        /// <summary>
        /// The price of the last trade for the symbol at the end of the previous trading session.
        /// </summary>
        [DataMember(Name = "close", Order = 11)]
        public double Close;

        /// <summary>
        /// The number of shares traded for the symbol.
        /// </summary>
        [DataMember(Name = "volume", Order = 12)]
        public long Volume;

        /// <summary>
        /// The highest price trade for the symbol in the past 52 weeks.
        /// </summary>
        [DataMember(Name = "year-high", Order = 13)]
        public double YearHigh;

        /// <summary>
        /// The lowest price trade for the symbol in the past 52 weeks.
        /// </summary>
        [DataMember(Name = "year-low", Order = 14)]
        public double YearLow;

        /// <summary>
        /// Indicates whether the quote information is real-time or delayed.
        ///     True — Real-time quote if the account is subscribed to RT
        ///     False — Delayed quote if the account  not subscribed to RT
        /// </summary>
        [DataMember(Name = "real-time", Order = 15)]
        public bool RealTime;

        /// <summary>
        /// Stock exchange where security symbol is listed. For example, "NASDAQ", "AMEX", "NYSE", "OTC", "PACX".
        /// </summary>
        [DataMember(Name = "exchange", Order = 16)]
        public string Exchange;

        /// <summary>
        /// Type of asset the symbol represents (Equity in this case).
        /// </summary>
        [DataMember(Name = "asset-type", Order = 17)]
        public AssetType AssetType;

        /// <summary>
        /// The difference between the last trade price and the previous trading session's closing price.
        /// If the last trade price is greater than the previous session's closing price, the value is returned
        /// without a leading sign. If the last trade price is less than the previous session's closing
        /// price the value is returned with "-" as the leading character.
        /// </summary>
        [DataMember(Name = "change", Order = 18)]
        public double Change;

        /// <summary>
        /// Percent change from the last trade price compared to the previous session's closing price.
        /// For example, if the previous session closing price is 14.48 and the last trade price is 14.88,
        /// the change is 0.40 and the change percent is 2.76. The value is returned as 2.76%.
        /// </summary>
        [DataMember(Name = "change-percent", Order = 19)]
        public string ChangePercent;
    }
}
