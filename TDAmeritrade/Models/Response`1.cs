//-----------------------------------------------------------------------
// <copyright file="Response`1.cs" company="KriaSoft, Ltd.">
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
    /// <typeparam name="T">The type of the value object.</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Response`1"/> class and sets it's Value property
        /// </summary>
        /// <param name="value">The value object of the response.</param>
        public Response(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Response`1"/> class and sets it's Value and Error properties.
        /// </summary>
        /// <param name="value">The value object of the response.</param>
        /// <param name="error">The error object of the response.</param>
        public Response(T value, ResponseError error)
        {
            Contract.Requires(error != null);

            this.Value = value;
            this.Error = error;
        }

        /// <summary>
        /// Gets the value objects of the response.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Gets the error objects of the response or null.
        /// </summary>
        public ResponseError Error { get; private set; }
    }
}
