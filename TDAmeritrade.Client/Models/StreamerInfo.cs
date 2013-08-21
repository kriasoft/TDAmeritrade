// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamerInfo.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    /// <summary>
    /// Container for StreamerInfo information object.
    /// </summary>
    [XmlRoot("streamer-info", Namespace = "")]
    public class StreamerInfo
    {
        /// <summary>
        /// Gets or sets the domain of the server that should be used for streaming data.
        /// </summary>
        [XmlElement("streamer-url", Order = 0)]
        public string StreamerUrl { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed in the "token" parameter in all streamer requests.
        /// </summary>
        [XmlElement("token", Order = 1)]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed  in the "timestamp" parameter in all streamer requests.
        /// </summary>
        [XmlElement("timestamp", Order = 2)]
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed  in the "cddomain" parameter in all streamer requests.
        /// </summary>
        [XmlElement("cd-domain-id", Order = 3)]
        public string CDDomainID { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed  in the "usergroup" parameter in all streamer requests.
        /// </summary>
        [XmlElement("usergroup", Order = 4)]
        public string UserGroup { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed  in the "accesslevel" parameter in all streamer requests.
        /// </summary>
        [XmlElement("access-level", Order = 5)]
        public string AccessLevel { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed  in the "acl" parameter in all streamer requests.
        /// </summary>
        [XmlElement("acl", Order = 6)]
        public string Acl { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed  in the "appid" parameter in all streamer requests.
        /// <remarks>
        /// NOTE: This is NOT the same as the Source ID assigned to the developer application.
        /// </remarks>
        /// </summary>
        [XmlElement("app-id", Order = 7)]
        public string AppID { get; set; }

        /// <summary>
        /// Gets or sets the variable to be passed  in the "authorized" parameter in all streamer requests.
        /// </summary>
        [XmlElement("authorized", Order = 8)]
        public string Authorized { get; set; }

        /// <summary>
        /// Gets or sets a plain text message of the error, in case one occurred.
        /// </summary>
        [XmlElement("error-msg", Order = 9)]
        internal string ErrorMessage { get; set; }
    }
}
