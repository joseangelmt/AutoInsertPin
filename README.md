# AutoInsertPin

With this tool, you can auto-fill the PIN code in the  Windows Security Smart Card dialog box.

If you're using a yubikey or a smart card signing device for code signing with EV code signing certificates, you've got to type the PIN code of the key each time a new process uses the key to sign the file.

This project uses [UI Automation](https://docs.microsoft.com/en-us/dotnet/framework/ui-automation/ui-automation-overview) to type the PIN and accept the dialog automatically for you so you can do an unattended build.

Usage: AutoInsertPin.exe [PIN]

If the pin is not entered on the command line, it will be prompted for.

The application is based on the ideas of [An introduction to UI Automation - with spooky spirographs](http://blog.functionalfun.net/2009/06/introduction-to-ui-automation-with.html)
