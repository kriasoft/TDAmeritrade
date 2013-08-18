## TD Ameritrade Client Library for .NET

Free, open-source .NET Client for the [TD Ameritrade Trading Platform](https://www.tdameritrade.com/api.page).
Helps developers integrate TD Ameritrade API into custom trading solutions.

### Download

Get the latest version via [NuGet](https://www.nuget.org/packages/TDAmeritrade.Client/)

### Sample

```csharp
using (var client = new AmeritradeClient())
{
    client.LogIn();
    var quotes = await client.GetQuotes("GOOG", "AAPL", "MSFT");
    var symbols = await client.FindSymbols("bank");
    var prices = await client.GetHistoricalPrices("GOOG", startDate: DateTime.Now.AddYears(-1));
    var watchlists = await client.GetWatchlists();
}
```

If you have not specified username/password in code, you will be prompted to enter your
TD Ameritrade client's credentials at runtime:

![Login](http://i.imgur.com/GKl4jYw.png)

### Credits

Copyright (c) 2013 [Konstantin Tarkus](http://www.linkedin.com/in/koistya), [KriaSoft LLC](http://www.kriasoft.com)

This software is released under the Apache License 2.0 (the "License"); you may not use the software
except in compliance with the License. You can find a copy of the License in the file
[LICENSE.txt](https://raw.github.com/kriasoft/tdameritrade/master/LICENSE.txt) accompanying this file. 

Logo image is a trademark of TD Ameritrade, Inc.

### Contacts

Do you have any questions or need help? Email me at [hello@tarkus.me](mailto:hello@tarkus.me)
or visit our [discussion board](https://groups.google.com/forum/#!forum/tdasdk).

**P.S.**: Your contributions of any kind are welcome!