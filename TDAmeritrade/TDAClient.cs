//-----------------------------------------------------------------------
// <copyright file="TDAClient.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using TDAmeritrade.Infrastructure;
    using TDAmeritrade.Models;
    using System.Collections.ObjectModel;

    /// <summary>
    /// TD Ameritrade client library which provides methods for sending data to and
    /// receiving data from a TD Ameritrade API web service.
    /// </summary>
    public partial class TDAClient : IDisposable
    {
        /// <summary>
        /// A cookie container.
        /// </summary>
        private readonly CookieContainer cookies = new CookieContainer();

        /// <summary>
        /// Session ID.
        /// </summary>
        private string sessionID;

        /// <summary>
        /// Timeout span.
        /// </summary>
        private TimeSpan timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="TDAClient"/> class. This is an implementation
        /// of TD Ameritrade API Client; the client allows you to manage your TD Ameritrade account.
        /// </summary>
        /// <param name="appKey">
        /// The Application ID (Source ID) of the software client assigned by TD Ameritrade.
        /// </param>
        /// <param name="appName">
        /// The name of the client software application. It will be passed as HTTP user agent header with each
        /// HTTP request to the service.
        /// </param>
        /// <param name="appVersion">The version number of the client software application.</param>
        /// <param name="serviceUrl">URL of the TD Ameritrade web service. This is an optional property; change it only if you want
        /// to try a different service endpoint or want to switch between https and http.</param>
        /// <param name="proxy">Optional proxy server. All service requests will go through it if specified.</param>
        /// <param name="maxErrorRetry">The maximum number of retry attempts after failed request (ex.: a 5xx response from a service). Must be between 0 and 10. Default is 3.</param>
        /// <param name="keepAlive">Use background service requests to keep client sessions from expiring. Default is True.</param>
        public TDAClient(string appKey = "AMTDTest", string appName = "TD Ameritrade .NET SDK", string appVersion = "1.1.0", string serviceUrl = "https://apis.tdameritrade.com/apps/100/", IWebProxy proxy = null, int maxErrorRetry = 3, bool keepAlive = true)
        {
            Contract.Requires(appKey != null);
            Contract.Requires(appName != null);
            Contract.Requires(appVersion != null);
            Contract.Requires(serviceUrl != null);
            Contract.Requires(maxErrorRetry > -1 && maxErrorRetry < 11);

            this.App = new AppInfo(appKey, appName, appVersion);
            this.Config = new AppConfig(serviceUrl, proxy, maxErrorRetry, keepAlive);
            this.User = new User();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="TDAClient"/> class.
        /// </summary>
        ~TDAClient()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets information about this client application.
        /// </summary>
        public AppInfo App { get; private set; }

        /// <summary>
        /// Gets TD Ameritrade client configuration settings.
        /// </summary>
        public AppConfig Config { get; private set; }

        /// <summary>
        /// User context.
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Logs in user to the TD Ameritrade web service.
        /// </summary>
        /// <param name="userid">The user's ID.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>true if user logged in successfully; false if not</returns>
        public Response<bool> LogIn(string userid, string password)
        {
            return this.LogInAsync(userid, password).Result;
        }

        /// <summary>
        /// Logs in user asynchronously to the TD Ameritrade web service.
        /// </summary>
        /// <param name="userid">The user's ID.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>true if user logged in successfully; false if not</returns>
        public Task<Response<bool>> LogInAsync(string userid, string password)
        {
            var url = this.Config.ServiceUrl + "LogIn?source=" + Uri.EscapeDataString(this.App.Key) + "&version=" + Uri.EscapeDataString(this.App.Version);
            var data = new { userid = userid, password = password, source = this.App.Key, version = this.App.Version };

            return GetXmlAsync(url, data)
                .ContinueWith(task =>
            {
                var xml = task.Result.Root;

                if (xml.Element("result").Value == "OK")
                {
                    var user = xml.Element("xml-log-in");
                    this.sessionID = user.Element("session-id").Value;
                    this.timeout = user.Element("timeout").ToTimeSpan();
                    this.User = new User
                    {
                        IsAuthenticated = true,
                        UserName = user.Element("user-id").Value,
                        LastLoginDate = user.Element("login-time").ToDate(),
                        Status = user.Element("exchange-status").ToExchangeStatus(),
                    };

                    this.User.Realtime.NYSE = user.Element("nyse-quotes").IsRealtime();
                    this.User.Realtime.NASDAQ = user.Element("nasdaq-quotes").IsRealtime();
                    this.User.Realtime.OPRA = user.Element("opra-quotes").IsRealtime();
                    this.User.Realtime.AMEX = user.Element("amex-quotes").IsRealtime();
                    this.User.Authorizations.Options360 = user.Element("authorizations").Element("options360").ToBoolean();

                    this.User.Accounts = new ReadOnlyCollection<Account>(
                        user.Element("accounts").Elements("account").Select(x =>
                            {
                                var pref = x.Element("preferences");
                                var auth = x.Element("authorizations");

                                var account = new Account
                                {
                                    ID = x.Element("account-id").Value,
                                    DisplayName = x.Element("display-name").Value,
                                    Description = x.Element("description").Value,
                                    IsAssociatedAccount = x.Element("associated-account").ToBoolean(),
                                    Company = x.Element("company").Value,
                                    Segment = x.Element("segment").Value,
                                    IsUnified = x.Element("unified").ToBoolean(),
                                    Preferences = new AccountPreferences
                                    {
                                        IsExpressTrading = pref.Element("express-trading").ToBoolean(),
                                        IsOptionDirectRouting = pref.Element("option-direct-routing").ToBoolean(),
                                        IsStockDirectRouting = pref.Element("stock-direct-routing").ToBoolean(),
                                    },
                                    Authorizations = new AccountAuthorizations
                                    {
                                        Apex = auth.Element("apex").ToBoolean(),
                                        Level2 = auth.Element("level2").ToBoolean(),
                                        StockTrading = auth.Element("stock-trading").ToBoolean(),
                                        MarginTrading = auth.Element("margin-trading").ToBoolean(),
                                        StreamingNews = auth.Element("streaming-news").ToBoolean(),
                                        OptionTrading = auth.Element("option-trading").ToOptionTradingType(),
                                        Streamer = auth.Element("streamer").ToBoolean(),
                                        AdvancedMargin = auth.Element("advanced-margin").ToBoolean(),
                                    }
                                };

                                return account;
                            }
                        ).ToList()
                    );

                    this.User.Account = this.User.Accounts.FirstOrDefault(x => x.ID == user.Element("associated-account-id").Value);

                    return new Response<bool>(true);
                }

                this.User = new User();
                return new Response<bool>(false, new ResponseError(xml.Element("error").Value));
            });
        }

        /// <summary>
        /// Logs out user from the TD Ameritrade web service.
        /// </summary>
        /// <returns>The <see cref="T:Response"/>.</returns>
        public Response LogOut()
        {
            return LogOutAsync().Result;
        }

        /// <summary>
        /// Logs out user asynchronously from the TD Ameritrade web service.
        /// </summary>
        /// <returns>The <see cref="T:Response"/>.</returns>
        public Task<Response> LogOutAsync()
        {
            var url = this.Config.ServiceUrl + "LogOut?source=" + Uri.EscapeDataString(this.App.Key);

            return GetXmlAsync(url)
                .ContinueWith(task =>
                {
                    var xml = task.Result.Root;

                    if (xml.Element("result").Value == "LoggedOut")
                    {
                        this.User = new User();
                        return new Response();
                    }

                    return new Response(new ResponseError(xml.Element("error").Value));
                });
        }

        /// <summary>
        /// Sends KeepAlive command to the TD Ameritrade web service, which prevents user's session from expiring.
        /// </summary>
        /// <returns>The <see cref="T:Response"/>.</returns>
        public Response KeepAlive()
        {
            return KeepAliveAsync().Result;
        }

        /// <summary>
        /// Sends KeepAlive command asynchronously to the TD Ameritrade web service, which prevents user's session from expiring.
        /// </summary>
        /// <returns>The <see cref="T:Response"/>.</returns>
        public Task<Response> KeepAliveAsync()
        {
            var url = "https://apis.tdameritrade.com/apps/KeepAlive?source=" + Uri.EscapeDataString(this.App.Key);

            return GetTextAsync(url)
                .ContinueWith(task =>
                {
                    if (new string[] { "LoggedOn", "InvalidSession" }.Contains(task.Result))
                    {
                        return new Response();
                    }

                    return new Response(new ResponseError("Unexpected response received from the web service."));
                });
        }

        /// <summary>
        /// Disposes <see cref="TDAClient"/> instance.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this); // Prevents finalizer from running.
        }

        /// <summary>
        /// Disposes <see cref="TDAClient"/> instance.
        /// </summary>
        /// <param name="disposing">true - release managed and unmanaged resources; false - release managed resources only.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO: Dispose managed objects.
            }

            // TODO: Dispose unmanaged objects.
        }

        /// <summary>
        /// Downloads a text string asynchronously.
        /// </summary>
        /// <param name="url">The URL of the resource to be downloaded.</param>
        /// <returns>The <see cref="T:String"/>.</returns>
        private Task<string> GetTextAsync(string url)
        {
            return GetTextAsync(url, null);
        }

        /// <summary>
        /// Downloads a text string asynchronously.
        /// </summary>
        /// <param name="url">The URL of the resource to be downloaded.</param>
        /// <param name="data">Optional data to be passed alone with the web request.</param>
        /// <returns>The <see cref="T:String"/>.</returns>
        private Task<string> GetTextAsync(string url, object data)
        {
            return Task.Factory.StartNew(() =>
            {
                var webRequest = CreateWebRequest(url);

                if (data == null)
                {
                    return webRequest.DownloadDataAsync().ContinueWith<string>(result =>
                        {
                            return Encoding.ASCII.GetString(result.Result);
                        });
                }
                else
                {
                    return webRequest.PostDataAsync(data).ContinueWith(_ =>
                    {
                        return webRequest.DownloadDataAsync().ContinueWith<string>(result =>
                        {
                            return Encoding.ASCII.GetString(result.Result);
                        });
                    }).Unwrap();
                }
            }).Unwrap();
        }

        /// <summary>
        /// Downloads <see cref="XDocument"/> asynchronously.
        /// </summary>
        /// <param name="url">The URL of the resource to be downloaded.</param>
        /// <returns>The <see cref="XDocument"/> object.</returns>
        private Task<XDocument> GetXmlAsync(string url)
        {
            return GetXmlAsync(url, null);
        }

        /// <summary>
        /// Downloads <see cref="XDocument"/> asynchronously.
        /// </summary>
        /// <param name="url">The URL of the resource to be downloaded.</param>
        /// <param name="data">Optional data to be passed alone with the web request.</param>
        /// <returns>The <see cref="XDocument"/> object.</returns>
        private Task<XDocument> GetXmlAsync(string url, object data)
        {
            return Task.Factory.StartNew(() =>
            {
                var webRequest = CreateWebRequest(url);

                if (data == null)
                {
                    return webRequest.DownloadXmlAsync();
                }
                else
                {
                    return webRequest.PostDataAsync(data).ContinueWith(_ =>
                    {
                        return webRequest.DownloadXmlAsync();
                    }).Unwrap();
                }
            }).Unwrap();
        }

        /// <summary>
        /// Creates <see cref="HttpWebRequest"/>.
        /// </summary>
        /// <param name="url">The URL string.</param>
        /// <returns>The <see cref="HttpWebRequest"/>.</returns>
        private HttpWebRequest CreateWebRequest(string url)
        {
            Contract.Requires(url != null);

            var request = (HttpWebRequest)WebRequest.Create(url);

            request.UserAgent = this.App.Name + " v" + this.App.Version;
            request.CookieContainer = this.cookies;

            if (this.Config.Proxy != null)
            {
                request.Proxy = this.Config.Proxy;
            }

            return request;
        }
    }
}
