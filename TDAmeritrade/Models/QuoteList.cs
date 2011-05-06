//-----------------------------------------------------------------------
// <copyright file="QuoteList.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Container for one or more <see cref="TDAmeritrade.Model.Quote"/> objects
    /// </summary>
    [CollectionDataContract(Name = "quote-list", ItemName = "quote", Namespace = "")]
    public class QuoteList : List<Quote>
    {
        /// <summary>
        /// An error message.
        /// </summary>
        [DataMember(Name = "error", Order = 0)]
        public string ErrorMessage;

        /// <summary>
        /// A list of symbols which have not been found.
        /// </summary>
        [IgnoreDataMember]
        public QuoteError[] Errors;
    }
}
