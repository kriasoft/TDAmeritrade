//-----------------------------------------------------------------------
// <copyright file="QuoteError.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    /// <summary>
    /// Represents a symbol with an associated error message.
    /// </summary>
    public class QuoteError
    {
        /// <summary>
        /// Symbol name
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
