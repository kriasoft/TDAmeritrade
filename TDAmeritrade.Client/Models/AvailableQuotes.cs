// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailableQuotes.cs" company="KriaSoft LLC">
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

        public List<Markets> All
        {
            get { return this.realtime.Union(this.delayed).ToList(); }
        }

        public List<Markets> RealTime
        {
            get { return this.realtime.ToList(); }
        }

        public List<Markets> Delayed
        {
            get { return this.delayed.ToList(); }
        }

        internal void Add(Markets market, bool isRealTime)
        {
            if (isRealTime)
            {
                this.realtime.Add(market);
            }
            else
            {
                this.delayed.Add(market);
            }
        }
    }
}
