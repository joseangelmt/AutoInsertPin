# AutoInsertPin

With this tool, you can auto-fill the PIN code in the  Windows Security Smart Card dialog box.

If you're using a yubikey or a smart card singing device for code signing with EV code signing certificates, you've to type the PIN code of the key each time a new process uses the key to sign the file.
This project types the PIN and accepts the dialog automatically for you so you can do an unattended build.

This project is based on [UI Automation](https://docs.microsoft.com/en-us/dotnet/framework/ui-automation/ui-automation-overview) and uses the Microsoft.TestApi NuGet package to send commands to the buttons.
The application is based on the ideas of [An introduction to UI Automation - with spooky spirographs](http://blog.functionalfun.net/2009/06/introduction-to-ui-automation-with.html)
