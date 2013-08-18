// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AmeritradeClientTest.cs" company="KriaSoft LLC">
//   Copyright © 2013 Konstantin Tarkus, KriaSoft LLC. See LICENSE.txt
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TDAmeritrade.Client.Tests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AmeritradeClientTest
    {
        [TestMethod, TestCategory("Integration")]
        public async Task GetWatchlists_Returns_a_List_of_Watchlists()
        {
            using (var client = new AmeritradeClient())
            {
                var watchlist = await client.GetWatchlists();
                Assert.IsNotNull(watchlist);
            }
        }
    }
}
