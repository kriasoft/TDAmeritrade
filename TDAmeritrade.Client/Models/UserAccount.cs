// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAccount.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents an individual account.
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccount"/> class.
        /// </summary>
        public UserAccount()
        {
            this.Preferences = new AccountPreferences();
            this.Authorizations = new AccountAuthorizations { OptionTrading = OptionTradingType.None };
        }

        /// <summary>
        /// Gets the ID of the user's account.
        /// </summary>
        public string AccountID { get; internal set; }

        /// <summary>
        /// Gets the display name for the account; same as shown on the TD Ameritrade web site.
        /// </summary>
        public string DisplayName { get; internal set; }

        /// <summary>
        /// Gets the user friendly description or the name associated with the account.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether or not this account is the main account associated with the User ID/LogIn session.
        /// </summary>
        public bool IsAssociatedAccount { get; internal set; }

        /// <summary>
        /// Gets a TDA internal code for the company the account is associated with. Will be needed for Streaming Quote requests.
        /// </summary>
        public string Company { get; internal set; }

        /// <summary>
        /// Gets a TDA internal code for the segment the account is associated with. Will be needed for Streaming Quote requests.
        /// </summary>
        public string Segment { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the account is enabled for Unified Site. If not, then you will not be able to launch any URL commands with /u/ in them.
        /// </summary>
        public bool IsUnified { get; internal set; }

        /// <summary>
        /// Gets a list of preference settings for the given account.
        /// </summary>
        public AccountPreferences Preferences { get; private set; }

        /// <summary>
        /// Gets a list of authorizations for the given account.
        /// </summary>
        public AccountAuthorizations Authorizations { get; private set; }
    }
}
