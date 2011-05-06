//-----------------------------------------------------------------------
// <copyright file="User.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a TD Ameritrade client / user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.Realtime = new RealtimeMarkets();
            this.Authorizations = new UserAuthorizations();
            this.Status = ExchangeStatus.Unknown;
        }

        /// <summary>
        /// Gets a value indicating whether the user is authenticated or not.
        /// </summary>
        public bool IsAuthenticated { get; internal set; }

        /// <summary>
        /// Gets a user's ID used to log in for the account.
        /// </summary>
        public string UserName { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DateTime"/> value when the user logged in last time.
        /// </summary>
        public DateTime LastLoginDate { get; internal set; }

        /// <summary>
        /// Gets a list of markets and values indicating whether a real-time data is available for each of them.
        /// </summary>
        public RealtimeMarkets Realtime { get; private set; }

        /// <summary>
        /// Gets a list of services to which the user has a valid authorization.
        /// </summary>
        public UserAuthorizations Authorizations { get; private set; }

        /// <summary>
        /// Gets the <see cref="ExchangeStatus"/> of the user.
        /// </summary>
        public ExchangeStatus Status { get; internal set; }

        /// <summary>
        /// Gets the main <see cref="Accont"/> associated with the client.
        /// </summary>
        public Account Account { get; internal set; }

        /// <summary>
        /// Gets a list of user accounts.
        /// </summary>
        public ReadOnlyCollection<Account> Accounts { get; internal set; }
    }
}
