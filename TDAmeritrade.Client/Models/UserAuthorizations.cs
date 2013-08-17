// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAuthorizations.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
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
