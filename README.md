## TD Ameritrade Client Library for .NET

Free, open-source .NET Client for the [TD Ameritrade Trading Platform](https://www.tdameritrade.com/api.page).
Helps developers integrate TD Ameritrade API into custom trading solutions.

### Download

Get the latest version via [NuGet](https://www.nuget.org/packages/TDAmeritrade.Client/)

### Sample

```csharp
using (var client = new AmeritradeClient())
{
    var quotes = client.GetQuotes("GOOG", "AAPL", "MSFT");
    var symbols = client.FindSymbols("bank");
    var prices = client.GetHistoricalPrices("GOOG", startDate: DateTime.Now.AddYears(-1));
}
```

If you have not specified username/password in code, you will be prompted to enter your
TD Ameritrade client's credentials at runtime:

![Login](http://i.imgur.com/GKl4jYw.png)

### Credentials

This library is brought to you by Konstantin Tarkus, KriaSoft LLC;
and released under [Apache License 2.0](https://raw.github.com/kriasoft/tdameritrade/master/LICENSE.txt).
Logo imags are copyrighted by TD Ameritrade, Inc.

Do you have any questions or need help? Email me at [hello@tarkus.me](mailto:hello@tarkus.me)