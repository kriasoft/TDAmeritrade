//-----------------------------------------------------------------------
// <copyright file="Symbol.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Container for one or more Symbol objects.
    /// </summary>
    [DataContract(Name = "symbol-result", Namespace = "")]
    public class Symbol
    {
        /// <summary>
        /// Symbol of the security being returned as a possible match.  For example, DELL.
        /// </summary>
        [DataMember(Name = "symbol", Order = 0)]
        public string Name { get; internal set; }

        /// <summary>
        /// Description of the symbol. For example, "DELL INC COM".
        /// </summary>
        [DataMember(Name = "description", Order = 1)]
        public string Description { get; internal set; }
    }
}
