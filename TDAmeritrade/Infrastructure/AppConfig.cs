//-----------------------------------------------------------------------
// <copyright file="AppConfig.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Infrastructure
{
    using System.Diagnostics.Contracts;
    using System.Net;

    /// <summary>
    /// Configuration settings.
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppConfig"/> class.
        /// </summary>
        /// <param name="serviceUrl">URL of the TD Ameritrade web service.</param>
        /// <param name="proxy">Optional proxy server. All service requests will go through it if specified.</param>
        /// <param name="maxErrorRetry">The maximum number of retry attempts after failed request (ex.: a 5xx response from a service). Must be between 0 and 10. Default is 3.</param>
        /// <param name="keepAlive">Use background service requests to keep client's session from expiring.</param>
        public AppConfig(string serviceUrl, IWebProxy proxy, int maxErrorRetry, bool keepAlive)
        {
            Contract.Requires(serviceUrl != null);
            Contract.Requires(maxErrorRetry > -1 && maxErrorRetry < 11);

            this.ServiceUrl = serviceUrl;
            this.Proxy = proxy;
            this.MaxErrorRetry = maxErrorRetry;
            this.KeepAlive = keepAlive;
        }

        /// <summary>
        /// Gets the URL of the TD Ameritrade web service.
        /// </summary>
        public string ServiceUrl { get; private set; }

        /// <summary>
        /// Gets the proxy server object.
        /// </summary>
        public IWebProxy Proxy { get; private set; }

        /// <summary>
        /// Gets the maximum number of retry attempts after failed request (ex.: a 5xx response from a service).
        /// </summary>
        public int MaxErrorRetry { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the client's session should be kept from expiring.
        /// </summary>
        public bool KeepAlive { get; private set; }
    }
}
