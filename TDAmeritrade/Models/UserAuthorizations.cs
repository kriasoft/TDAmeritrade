//-----------------------------------------------------------------------
// <copyright file="UserAuthorizations.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    /// <summary>
    /// Contains a list of services to which the user has a valid authorization.
    /// </summary>
    public class UserAuthorizations
    {
        /// <summary>
        /// Gets a value indicating whether the user has authorization to the Options360 service.
        /// </summary>
        public bool Options360 { get; internal set; }
    }
}
