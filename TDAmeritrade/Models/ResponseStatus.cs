//-----------------------------------------------------------------------
// <copyright file="ResponseStatus.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Response status code
    /// </summary>
    [DataContract]
    public enum ResponseStatus
    {
        /// <summary>
        /// OK
        /// </summary>
        [EnumMember(Value = "OK")]
        OK,
        /// <summary>
        /// Request failed
        /// </summary>
        [EnumMember(Value = "FAIL")]
        Failed,
        /// <summary>
        /// Session expired
        /// </summary>
        [EnumMember(Value = "LoggedOut")]
        LoggedOut
    }
}
