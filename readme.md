# YelpSharp
YelpSharp is a .NET wrapper for the Yelp REST API.  It lets you do all kinds of interesting things like searching for businesses, getting user comments and ratings, and handling common errors.  The library is written C#, and is available on NuGet.  

For more information, visit the [Yelp REST API](http://www.yelp.com/developers/documentation/v2/overview)

## Installing 
In most cases, you're going to want to install the YelpSharp NuGet package.  Open up the Package Manager Console in Visual Studio, and run this command:

```
PM> Install-Package YelpSharp
```

## How to Use
The source includes a [few examples](https://github.com/JustinBeckwith/YelpSharp/tree/master/Samples) that should help you get started with ASP.NET and Windows Phone 8.  Before you get started, you need to register for a [Yelp developer account](http://www.yelp.com/developers/getting_started/), and [register for an API key](http://www.yelp.com/developers/getting_started/api_access).  If you are looking for something and having trouble, you can always check out the [unit tests](https://github.com/JustinBeckwith/YelpSharp/blob/master/YelpSharpTests/YelpTest.cs).

### Handling Tokens
The `Yelp` constructor takes a set of options that includes all of the keys neccesary to use the V2 Yelp API.  Keep these keys safe!  There are a variety of ways to store them.  You can put them in the applicationSettings portion of your web.config (recommended), or store them in an environment variable on your dev machine:

```csharp
var options = new Options()
{
    AccessToken = Environment.GetEnvironmentVariable("YELP_ACCESS_TOKEN", EnvironmentVariableTarget.Machine),
    AccessTokenSecret = Environment.GetEnvironmentVariable("YELP_ACCESS_TOKEN_SECRET", EnvironmentVariableTarget.Machine),
    ConsumerKey = Environment.GetEnvironmentVariable("YELP_CONSUMER_KEY", EnvironmentVariableTarget.Machine),
    ConsumerSecret = Environment.GetEnvironmentVariable("YELP_CONSUMER_SECRET", EnvironmentVariableTarget.Machine)
};
```

For a full example of conviently storing your tokens, check out the [MvcSample](https://github.com/JustinBeckwith/YelpSharp/blob/master/Samples/MvcSample/Config.cs).

### Using the Search API
YelpSharp uses the [Task Parallel Library (TPL)](http://msdn.microsoft.com/en-us/library/dd460717.aspx) to make managing asynchronous requests easier.  The search API has two different ways of searching for results.  The simplest way is to pass a city and a search term.  This will search Yelp for all coffee places around Seattle, WA (there are a lot).

```csharp
var task = y.Search("coffee", "seattle, wa").ContinueWith((searchResults) =>
{
    foreach (var business in searchResults.Result.businesses)
    {
        Console.WriteLine(business.name);
    }
});
```

There are a lot of other ways to search.  For more info, the best place to look is the [unit tests](https://github.com/JustinBeckwith/YelpSharp/blob/master/YelpSharpTests/YelpTest.cs).


## Building the Source
If you want to build the source, clone the repository, and open up YelpSharp.sln.  

```
git clone https://github.com/JustinBeckwith/YelpSharp
explorer YelpSharp\YelpSharp.sln
```

## Supported Platforms
YelpSharp targets .NET 4.0, and Windows Phone 8.  If you would like support for other platforms, let me know.  


## License
[MIT License](http://opensource.org/licenses/MIT)

## Questions?
Feel free to submit an issue on the repository, or find me at [@JustinBeckwith](http://twitter.com/JustinBeckwith)






