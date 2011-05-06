//-----------------------------------------------------------------------
// <copyright file="QuotesType.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;
    
    /// <summary>
    /// Real-time or delayed
    /// </summary>
    [DataContract(Namespace = "")]
    public enum QuotesType
    {
        /// <summary>
        /// Real-time data
        /// </summary>
        [EnumMember(Value = "realtime")]
        RealTime,

        /// <summary>
        /// Delayed data
        /// </summary>
        [EnumMember(Value = "delayed")]
        Delayed
    }
}
