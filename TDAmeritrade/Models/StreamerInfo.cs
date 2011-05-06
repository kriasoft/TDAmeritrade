//-----------------------------------------------------------------------
// <copyright file="StreamerInfo.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Container for StreamerInfo information object.
    /// </summary>
    [DataContract(Name = "streamer-info", Namespace = "")]
    public class StreamerInfo
    {
        /// <summary>
        /// The domain of the server that should be used for streaming data.
        /// </summary>
        [DataMember(Name = "streamer-url", Order = 0)]
        public string StreamerURL { get; internal set; }

        /// <summary>
        /// Variable to be passed in the "token" parameter in all streamer requests.
        /// </summary>
        [DataMember(Name = "token", Order = 1)]
        public string Token { get; internal set; }

        /// <summary>
        /// Variable to be passed  in the "timestamp" parameter in all streamer requests.
        /// </summary>
        [DataMember(Name = "timestamp", Order = 2)]
        public string Timestamp { get; internal set; }

        /// <summary>
        /// Variable to be passed  in the "cddomain" parameter in all streamer requests.
        /// </summary>
        [DataMember(Name = "cd-domain-id", Order = 3)]
        public string CDDomainID { get; internal set; }

        /// <summary>
        /// Variable to be passed  in the "usergroup" parameter in all streamer requests.
        /// </summary>
        [DataMember(Name = "usergroup", Order  = 4)]
        public string UserGroup { get; internal set; }

        /// <summary>
        /// Variable to be passed  in the "accesslevel" parameter in all streamer requests.
        /// </summary>
        [DataMember(Name = "access-level", Order = 5)]
        public string AccessLevel { get; internal set; }

        /// <summary>
        /// Variable to be passed  in the "acl" parameter in all streamer requests.
        /// </summary>
        [DataMember(Name = "acl", Order = 6)]
        public string ACL { get; internal set; }

        /// <summary>
        /// Variable to be passed  in the "appid" parameter in all streamer requests.
        /// NOTE: This is NOT the same as the Source ID assigned to the developer application.
        /// </summary>
        [DataMember(Name = "app-id", Order = 7)]
        public string AppID { get; internal set; }

        /// <summary>
        /// Variable to be passed  in the "authorized" parameter in all streamer requests.
        /// </summary>
        [DataMember(Name = "authorized", Order = 8)]
        public string Authorized { get; internal set; }

        /// <summary>
        /// Plain text of the error, in case one occurred.
        /// </summary>
        [DataMember(Name = "error-msg", Order = 9)]
        internal string ErrorMessage { get; set; }
    }
}
