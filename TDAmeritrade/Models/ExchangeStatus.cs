//-----------------------------------------------------------------------
// <copyright file="ExchangeStatus.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The client's status.
    /// </summary>
    [DataContract(Namespace = "")]
    public enum ExchangeStatus
    {
        /// <summary>
        /// Professional
        /// </summary>
        Professional,
        /// <summary>
        /// Non-professional
        /// </summary>
        NonProfessional,
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown
    }
}
