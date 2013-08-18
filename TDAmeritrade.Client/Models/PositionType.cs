// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionType.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Xml.Serialization;

    public enum PositionType
    {
        [XmlEnum("LONG")]
        Long,

        [XmlEnum("SHORT")]
        Short
    }
}
