// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetType.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.ComponentModel;
    using System.Xml.Serialization;

    public enum AssetType
    {
        [XmlEnum("")]
        Unknown,

        [XmlEnum("E")]
        EquityOrETF,
        
        [XmlEnum("F")]
        MutualFund,

        [XmlEnum("O")]
        Option,

        [XmlEnum("B")]
        Bond,

        [XmlEnum("I")]
        Index
    }
}
