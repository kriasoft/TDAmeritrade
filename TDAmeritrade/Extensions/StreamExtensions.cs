//-----------------------------------------------------------------------
// <copyright file="StreamExtensions.cs" company="KriaSoft, Ltd.">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace System.IO
{
    using System.Diagnostics.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;
using System.Xml.Linq;
    using System.Xml;

    /// <summary>Extension methods for asynchronously working with streams.</summary>
    public static class StreamExtensions
    {
        private const int BUFFER_SIZE = 0x2000;

        /// <summary>
        /// Read from a stream asynchronously.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">An array of bytes to be filled by the read operation.</param>
        /// <param name="offset">The offset at which data should be stored.</param>
        /// <param name="count">The number of bytes to be read.</param>
        /// <returns>A Task containing the number of bytes read.</returns>
        public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int count)
        {
            Contract.Requires(stream != null);

            return Task<int>.Factory.FromAsync(stream.BeginRead, stream.EndRead, buffer, offset, count, stream /* object state */);
        }

        /// <summary>
        /// Write to a stream asynchronously.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="buffer">An array of bytes to be written.</param>
        /// <param name="offset">The offset from which data should be read to be written.</param>
        /// <param name="count">The number of bytes to be written.</param>
        /// <returns>A Task representing the completion of the asynchronous operation.</returns>
        public static Task WriteAsync(this Stream stream, byte[] buffer, int offset, int count)
        {
            Contract.Requires(stream != null);

            return Task.Factory.FromAsync(stream.BeginWrite, stream.EndWrite, buffer, offset, count, stream /* object state */);
        }

        /// <summary>
        /// Reads the contents of the stream asynchronously.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>A Task representing the contents of the file in bytes.</returns>
        public static Task<byte[]> ReadAllBytesAsync(this Stream stream)
        {
            Contract.Requires(stream != null);

            // Create a MemoryStream to store the data read from the input stream
            int initialCapacity = stream.CanSeek ? (int)stream.Length : 0;
            var readData = new MemoryStream(initialCapacity);

            // Copy from the source stream to the memory stream and return the copied data
            return stream.CopyStreamToStreamAsync(readData).ContinueWith(t =>
            {
                t.PropagateExceptions();
                return readData.ToArray();
            });
        }

        /// <summary>
        /// Reads the contents of the stream asynchronously and converts it into <see cref="T:XDocument"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>A Task representing <see cref="T:XDocument"/> object.</returns>
        public static Task<XDocument> ReadXmlAsync(this Stream stream)
        {
            Contract.Requires(stream != null);

            // Create a MemoryStream to store the data read from the input stream
            int initialCapacity = stream.CanSeek ? (int)stream.Length : 0;
            var readData = new MemoryStream(initialCapacity);

            // Copy from the source stream to the memory stream and return the copied data
            return stream.CopyStreamToStreamAsync(readData).ContinueWith(t =>
            {
                t.PropagateExceptions();
                readData.Position = 0;
                return XDocument.Load(readData);
            });
        }

        /// <summary>
        /// Copies the contents of one stream to another, asynchronously.
        /// </summary>
        /// <param name="source">The source stream.</param>
        /// <param name="destination">The destination stream.</param>
        /// <returns>A Task that represents the completion of the asynchronous operation.</returns>
        public static Task CopyStreamToStreamAsync(this Stream source, Stream destination)
        {
            Contract.Requires(source != null);
            Contract.Requires(destination != null);

            return Task.Factory.Iterate(CopyStreamIterator(source, destination));
        }

        /// <summary>
        /// Creates an enumerable to be used with TaskFactoryExtensions.Iterate that copies data from one
        /// stream to another.
        /// </summary>
        /// <param name="input">The input stream.</param>
        /// <param name="output">The output stream.</param>
        /// <returns>An enumerable containing yielded tasks from the copy operation.</returns>
        private static IEnumerable<Task> CopyStreamIterator(Stream input, Stream output)
        {
            // Create two buffers.  One will be used for the current read operation and one for the current
            // write operation.  We'll continually swap back and forth between them.
            byte[][] buffers = new byte[2][] { new byte[BUFFER_SIZE], new byte[BUFFER_SIZE] };
            int filledBufferNum = 0;
            Task writeTask = null;

            // Until there's no more data to be read
            while (true)
            {
                // Read from the input asynchronously
                var readTask = input.ReadAsync(buffers[filledBufferNum], 0, buffers[filledBufferNum].Length);

                // If we have no pending write operations, just yield until the read operation has
                // completed.  If we have both a pending read and a pending write, yield until both the read
                // and the write have completed.
                if (writeTask == null)
                {
                    yield return readTask;
                    readTask.Wait(); // propagate any exception that may have occurred
                }
                else
                {
                    var tasks = new[] { readTask, writeTask };
                    yield return Task.Factory.WhenAll(tasks);
                    Task.WaitAll(tasks); // propagate any exceptions that may have occurred
                }

                // If no data was read, nothing more to do.
                if (readTask.Result <= 0) break;

                // Otherwise, write the written data out to the file
                writeTask = output.WriteAsync(buffers[filledBufferNum], 0, readTask.Result);

                // Swap buffers
                filledBufferNum ^= 1;
            }
        }
    }
}
