// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryReaderExtensions.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Extensions
{
    using System;
    using System.IO;

    internal static class BinaryReaderExtensions
    {
        public static short ReadInt16BE(this BinaryReader reader)
        {
            return BitConverter.ToInt16(reader.ReadBytes(sizeof(short)).Reverse(), 0);
        }

        public static int ReadInt32BE(this BinaryReader reader)
        {
            return BitConverter.ToInt32(reader.ReadBytes(sizeof(int)).Reverse(), 0);
        }

        public static long ReadInt64BE(this BinaryReader reader)
        {
            return BitConverter.ToInt64(reader.ReadBytes(sizeof(long)).Reverse(), 0);
        }

        public static float ToSingleBE(this BinaryReader reader)
        {
            return BitConverter.ToSingle(reader.ReadBytes(sizeof(float)).Reverse(), 0);
        }

        private static byte[] Reverse(this byte[] array)
        {
            Array.Reverse(array);
            return array;
        }
    }
}
