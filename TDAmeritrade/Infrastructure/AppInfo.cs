//-----------------------------------------------------------------------
// <copyright file="AppInfo.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Infrastructure
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// TD Ameritrade client application info.
    /// </summary>
    public class AppInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppInfo"/> class.
        /// </summary>
        /// <param name="key">
        /// The Application ID (Source ID) of the software client assigned by TD Ameritrade.
        /// </param>
        /// <param name="name">
        /// The name of the client software application. It will be passed as HTTP user agent header with each
        /// HTTP request to the service alone with it's version number.
        /// </param>
        /// <param name="version">
        /// The version of the client software application.
        /// </param>
        public AppInfo(string key, string name, string version)
        {
            Contract.Requires(key != null);
            Contract.Requires(name != null);
            Contract.Requires(version != null);

            this.Key = key;
            this.Name = name;
            this.Version = version;
        }

        /// <summary>
        /// Gets the Application ID (Source ID) of the software client assigned by TD Ameritrade.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the name of the client application.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the version of the client application.
        /// </summary>
        public string Version { get; private set; }
    }
}
