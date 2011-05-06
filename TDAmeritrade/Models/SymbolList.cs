//-----------------------------------------------------------------------
// <copyright file="SymbolList.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Container for one or more Symbol objects.
    /// </summary>
    [CollectionDataContract(Name = "symbol-lookup-result", ItemName = "symbol-result", Namespace = "")]
    public class SymbolList : List<Symbol>
    {
        /// <summary>
        /// Error message
        /// </summary>
        [DataMember(Name = "error", Order = 0)]
        public string ErrorMessage;
    }
}
