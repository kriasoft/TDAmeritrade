//-----------------------------------------------------------------------
// <copyright file="WebRequestExtensions.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace System.Net
{
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Extension methods for working with <see cref="WebRequest"/> asynchronously.
    /// </summary>
    public static class WebRequestExtensions
    {
        /// <summary>
        /// Creates a <see cref="T:Task"/> that represents an asynchronous request to GetResponse.
        /// </summary>
        /// <param name="webRequest">The <see cref="T:WebRequest"/> instance.</param>
        /// <returns>A <see cref="T:Task"/> containing the retrieved <see cref="T:WebResponse"/> object.</returns>
        public static Task<WebResponse> GetResponseAsync(this WebRequest webRequest)
        {
            Contract.Requires(webRequest != null);

            return Task<WebResponse>.Factory.FromAsync(webRequest.BeginGetResponse, webRequest.EndGetResponse, webRequest /* object state */);
        }

        /// <summary>
        /// Creates a <see cref="T:Task"/> that represents an asynchronous request to GetRequestStream.
        /// </summary>
        /// <param name="webRequest">The <see cref="T:WebRequest"/> instance.</param>
        /// <returns>A <see cref="T:Task"/> containing the retrieved <see cref="T:Stream"/> object.</returns>
        public static Task<Stream> GetRequestStreamAsync(this WebRequest webRequest)
        {
            Contract.Requires(webRequest != null);

            return Task<Stream>.Factory.FromAsync(webRequest.BeginGetRequestStream, webRequest.EndGetRequestStream, webRequest /* object state */);
        }

        /// <summary>
        /// Creates a <see cref="T:Task"/> that represents downloading all of the data from the <see cref="T:WebRequest"/>.
        /// </summary>
        /// <param name="webRequest">The <see cref="T:WebRequest"/> instance.</param>
        /// <returns>A <see cref="T:Task"/> containing the downloaded content.</returns>
        public static Task<byte[]> DownloadDataAsync(this WebRequest webRequest)
        {
            // Asynchronously get the response.  When that's done, asynchronously read the contents.
            return webRequest.GetResponseAsync().ContinueWith(response =>
            {
                return response.Result.GetResponseStream().ReadAllBytesAsync();
            }).Unwrap();
        }

        /// <summary>
        /// Creates a <see cref="T:Task"/> that represents sending all of the data to the <see cref="T:WebRequest"/>.
        /// </summary>
        /// <param name="webRequest">The <see cref="T:WebRequest"/> instance.</param>
        /// <param name="data">A data object to be sent alone with the <see cref="T:WebRequest"/>.</param>
        /// <returns>A <see cref="T:Task"/> objected returned after sending data to a <see cref="T:WebRequest"/>.</returns>
        public static Task PostDataAsync(this WebRequest webRequest, object data)
        {
            Contract.Requires(webRequest != null);
            Contract.Requires(data != null);

            byte[] buffer;
            var sb = new StringBuilder();

            foreach (PropertyInfo pi in data.GetType().GetProperties())
            {
                sb.Append((sb.Length == 0 ? String.Empty : "&") + pi.Name + "=" + Uri.UnescapeDataString(pi.GetValue(data, null).ToString()));
            }

            buffer = Encoding.ASCII.GetBytes(sb.ToString());

            webRequest.ContentLength = buffer.Length;
            webRequest.Method = WebRequestMethods.Http.Post;
            webRequest.ContentType = "application/x-www-form-urlencoded";

            return webRequest.GetRequestStreamAsync().ContinueWith(stream =>
            {
                return stream.Result.WriteAsync(buffer, 0, buffer.Length);
            }).Unwrap();
        }

        /// <summary>
        /// Creates a <see cref="T:Task"/> that represents an asynchronous web request that returns <see cref="T:XDocument"/> object.
        /// </summary>
        /// <param name="webRequest">The <see cref="T:WebRequest"/> instance.</param>
        /// <returns>A <see cref="T:Task"/> containing <see cref="T:XDocument"/> object.</returns>
        public static Task<XDocument> DownloadXmlAsync(this WebRequest webRequest)
        {
            return webRequest.GetResponseAsync().ContinueWith(response =>
            {
                return response.Result.GetResponseStream().ReadXmlAsync();
            }).Unwrap();
        }
    }
}
