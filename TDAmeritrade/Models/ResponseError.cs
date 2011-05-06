//-----------------------------------------------------------------------
// <copyright file="ResponseError.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace TDAmeritrade.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents and error returned during API call.
    /// </summary>
    public class ResponseError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ResponseError"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ResponseError(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ResponseError"/> class.
        /// </summary>
        /// <param name="code">The code of the error.</param>
        /// <param name="message">The error message.</param>
        public ResponseError(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// Gets the code of the error.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; private set; }
    }
}
