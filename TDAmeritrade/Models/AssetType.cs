//-----------------------------------------------------------------------
// <copyright file="AssetType.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// An asset type enumeration.
    /// </summary>
    [DataContract(Namespace = "")]
    public enum AssetType
    {
        /// <summary>
        /// Equites or ETFs
        /// </summary>
        [EnumMember(Value = "E")]
        EquityOrETF,
        /// <summary>
        /// Mutual funds
        /// </summary>
        [EnumMember(Value = "F")]
        MutualFund,
        /// <summary>
        /// Indexes
        /// </summary>
        [EnumMember(Value = "I")]
        Index,
        /// <summary>
        /// Options
        /// </summary>
        [EnumMember(Value = "O")]
        Option,
        /// <summary>
        /// Bonds
        /// </summary>
        [EnumMember(Value = "B")]
        Bond
    }
}
