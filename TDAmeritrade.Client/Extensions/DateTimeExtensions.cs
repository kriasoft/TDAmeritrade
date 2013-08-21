// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Extensions
{
    using System;

    public static class DateTimeExtensions
    {
        private static readonly TimeZoneInfo ServerTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

        public static DateTime ToServerTime(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, ServerTimeZone);
        }
    }
}
