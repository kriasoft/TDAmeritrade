// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FundQuote.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Xml.Serialization;

    [XmlRoot("quote", Namespace = "")]
    public class FundQuote
    {
        [XmlElement("symbol")]
        public string Symbol { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("nav")]
        public float Nav { get; set; }

        [XmlElement("change")]
        public float Change { get; set; }

        [XmlElement("real-time")]
        public bool IsRealTime { get; set; }
    }
}
