// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorQuote.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Xml.Serialization;

    [XmlRoot("quote", Namespace = "")]
    public class ErrorQuote
    {
        [XmlElement("symbol")]
        public string Symbol { get; set; }

        [XmlElement("error")]
        public string ErrorMessage { get; set; }
    }
}
