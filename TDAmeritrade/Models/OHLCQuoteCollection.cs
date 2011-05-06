//-----------------------------------------------------------------------
// <copyright file="OHLCQuoteCollection.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Collection of symbols wither their historical prices.
    /// </summary>
    public class OHLCQuoteCollection : Dictionary<string, OHLCQuote[]>
    {
        
    }
}
