// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Watchlist.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("watchlist", Namespace = "")]
    public class Watchlist
    {
        /// <summary>
        /// Gets or sets the name assigned to the given watchlist.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets numeric ID that identifies the watchlist.
        /// </summary>
        [XmlElement("id")]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets a list of symbols in the watchlist.
        /// </summary>
        [XmlArray("symbol-list"), XmlArrayItem("watched-symbol", typeof(WatchedSymbol))]
        public List<WatchedSymbol> Symbols { get; set; }
    }
}
