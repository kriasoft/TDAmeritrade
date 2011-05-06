//-----------------------------------------------------------------------
// <copyright file="Response.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents a response object returned by the <see cref="T:TDAClient"/> instance.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Response"/> class.
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Response"/> class and set's it's Error property.
        /// </summary>
        /// <param name="error">The error object of the response.</param>
        public Response(ResponseError error)
        {
            Contract.Requires(error != null);

            this.Error = error;
        }

        /// <summary>
        /// Gets the error objects of the response or null.
        /// </summary>
        public ResponseError Error { get; private set; }
    }
}
