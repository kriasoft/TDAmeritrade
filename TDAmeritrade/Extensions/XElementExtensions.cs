//-----------------------------------------------------------------------
// <copyright file="XElementExtensions.cs" company="KriaSoft, LLC">
//     TD Ameritrade .NET SDK v1.1.0 (June 01, 2011)
//     Copyright © 2011 Konstantin Tarkus (k.tarkus@kriasoft.com)
// </copyright>
//-----------------------------------------------------------------------

namespace System.Xml.Linq
{
    using System;
    using System.Globalization;

    using TDAmeritrade.Models;

    /// <summary>
    /// Extension methods for <see cref="XElement"/>.
    /// </summary>
    public static class XElementExtensions
    {
        /// <summary>
        /// Converts the <see cref="XElement"/>'s value string into <see cref="Boolean"/> value.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> object containing 'true' or 'false' string value.</param>
        /// <returns>true or false</returns>
        public static bool ToBoolean(this XElement element)
        {
            return Boolean.Parse(element.Value);
        }

        /// <summary>
        /// Converts the <see cref="XElement"/>'s value string into <see cref="DateTime"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> object containing a date and time string.</param>
        /// <returns>The <see cref="DateTime"/> object.</returns>
        public static DateTime ToDate(this XElement element)
        {
            var date = element.Value;
            date = date.Substring(0, 10) + "T" + date.Substring(11, 8) + ".000" + date.Substring(20, 3).Replace("EDT", "-04:00").Replace("EST", "-05:00");
            return DateTime.Parse(date, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the <see cref="XElement"/>'s value into <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/>'s object containing time span value in minutes.</param>
        /// <returns>The <see cref="TimeSpan"/>.</returns>
        public static TimeSpan ToTimeSpan(this XElement element)
        {
            return TimeSpan.FromMinutes(Double.Parse(element.Value, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Converts the <see cref="XElement"/>'s value into Boolean based on whether it's value equals 'realtime' or 'delayed'.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> object containing 'realtime' or 'delayed' string value.</param>
        /// <returns>true if real-time; false if delayed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The XDocument's value neither 'realtime' nor a 'delayed'.</exception>
        public static bool IsRealtime(this XElement element)
        {
            switch (element.Value)
            {
                case "realtime":
                    return true;
                case "delayed":
                    return false;
                default:
                    throw new ArgumentOutOfRangeException("element", String.Format("Expected 'realtime' or 'delayed' but actual value was '{0}'.", element.Value));
            }
        }

        /// <summary>
        /// Converts the <see cref="XElement"/>'s value into <see cref="ExchangeStatus"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> object containing 'professional', 'non-professional' or 'unknown' string value.</param>
        /// <returns>The <see cref="ExchangeStatus"/>.</returns>
        public static ExchangeStatus ToExchangeStatus(this XElement element)
        {
            switch (element.Value)
            {
                case "professional":
                    return ExchangeStatus.Professional;
                case "non-professional":
                    return ExchangeStatus.NonProfessional;
                case "unknown":
                    return ExchangeStatus.Unknown;
                default:
                    throw new ArgumentOutOfRangeException("element", String.Format("Expected 'professional', 'non-professional' or 'unknown' but actual value was '{0}'.", element.Value));
            }
        }

        /// <summary>
        /// Converts the <see cref="XElement"/>'s value into <see cref="OptionTradingType"/>.
        /// </summary>
        /// <param name="element">The <see cref="XElement"/> object containing 'none', 'long', 'covered', 'spread' or 'full' string value.</param>
        /// <returns>The <see cref="OptionTradingType"/>.</returns>
        public static OptionTradingType ToOptionTradingType(this XElement element)
        {
            switch (element.Value)
            {
                case "none":
                    return OptionTradingType.None;
                case "long":
                    return OptionTradingType.Long;
                case "covered":
                    return OptionTradingType.Covered;
                case "spread":
                    return OptionTradingType.Spread;
                case "full":
                    return OptionTradingType.Full;
                default:
                    throw new ArgumentOutOfRangeException("element", String.Format("Expected 'none', 'long', 'covered', 'spread' or 'full' but actual value was '{0}'.", element.Value));
            }
        }
    }
}
