// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class AvailableQuotes
    {
        private readonly SortedSet<Markets> realtime = new SortedSet<Markets>();
        private readonly SortedSet<Markets> delayed = new SortedSet<Markets>();

        internal void Add(Markets market, bool isRealTime)
        {
            if (isRealTime)
            {
                realtime.Add(market);
            }
            else
            {
                delayed.Add(market);
            }
        }

        public List<Markets> All { get { return this.realtime.Union(this.delayed).ToList(); } }

        public List<Markets> RealTime { get { return this.realtime.ToList(); } }

        public List<Markets> Delayed { get { return this.delayed.ToList(); } }
    }
}
