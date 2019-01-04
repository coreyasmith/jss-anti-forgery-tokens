# JavaScript Services Anti-Forgery Tokens

This is a sample repository to demonstrate how to use .NET anti-forgery tokens
in [Sitecore JavaScript Services][1] with both MVC and Web API controllers using
out-of-the-box anti-forgery token validators. The demo API is also completely
mocked in disconnected mode to show how this functionality can work in both
disconnected and connected modes.

## Setup

Clone this repository. The rest of the setup assumes you cloned to
`C:\Projects\Sitecore\JssAntiForgeryTokens`.

### Disconnected Mode

1. Run `yarn install` in
   [/src/Project/JssRocks/client](/src/Project/JssRocks/client).
2. Run `jss start`.

### Connected Mode

1. Install an instance of [Sitecore 9.1 Initial Release][2].
   - The default install path is
    `C:\inetpub\wwwroot\jssaftokens.localhost`.
   - The default URL is `jssaftokens.localhost`.
2. Install [Sitecore JavaScript Services 11.0.0][3].
3. If you used a clone path, install directory, or URL different than the
   defaults above, open
   [JssAntiForgeryTokens.sln](JssAntiForgeryTokens.sln) and modify
   the following files in the `.config` folder:
   - `CoreySmith.Project.Common.Dev.config`
     - Change `sourceFolder` to your repository directory.
   - `CoreySmith.Project.JssRocks.Dev.config`
     - Change `hostName` to the URL you used for your instance.
   - `PublishSettings.targets`
     - Change `publishUrl` to the path of your Sitecore instance.
   - `scjssconfig.json`
     - Change `instancePath` to the path of your Sitecore instance.
     - Change `deployUrl` host name to the host name of your Sitecore instance.
     - Change `layoutServiceHost` to the URL of your Sitecore instance.
4. Navigate to [/src/Project/JssRocks/client](/src/Project/JssRocks/client) and
   deploy the JSS app with `jss deploy files`.
5. Build the solution in Visual Studio.
   - This will publish all code to your instance thanks to
     [Helix Publishing Pipeline][4].
   - Note: you may need to reload the solution and build a second time if you
     get errors about missing assemblies/references when you load Sitecore.
6. Perform a Unicorn sync at `/unicorn.aspx?verb=sync`.
7. Navigate to your site at <http://hostname.localhost.>

[1]: https://jss.sitecore.net
[2]: https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/91/Sitecore_Experience_Platform_91_Initial_Release.aspx
[3]: https://dev.sitecore.net/Downloads/Sitecore_JavaScript_Services/110/Sitecore_JavaScript_Services_1100.aspx
[4]: https://github.com/richardszalay/helix-publishing-pipeline
