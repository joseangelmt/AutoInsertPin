// Usage AutoInsertPin.exe [pin]
// If the pin is not supplied on the command line, it will be prompted for.
// Modified to work with the XAML UI of signtool.exe

using System;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace AutoInsertPin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string pin;

            if (args.Length == 0)
            {
                Console.WriteLine("Enter PIN:");
                pin = Console.ReadLine();

                if (pin.Length == 0)
                    return;
            }
            else
                pin = args[0];

            Console.WriteLine("Waiting for windows. Press Ctrl+C to finish monitoring windows...");

            while (true)
            {
                try
                {
                    var window = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Windows Security"));
                    await Task.Delay(1000);
                    if (window == null)
                        continue;

                    // Console.WriteLine("Located window");

                    var editControl = window.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                    if (editControl == null)
                        continue;

                    editControl.SetFocus();
                    SendKeys.SendWait("^(a)");      // select all
                    await Task.Delay(250);
                    SendKeys.SendWait("{DELETE}");  // delete
                    await Task.Delay(250);
                    SendKeys.SendWait(pin);         // fill in the PIN
                    await Task.Delay(250);

                    var okControl = window.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "OK"));
                    if (okControl == null)
                        continue;

                    var invokePattern = okControl.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    invokePattern.Invoke();         // click OK

                    await Task.Delay(1000);
                }
                catch(Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
        }
    }
}
