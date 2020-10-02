using Microsoft.Test.Input;
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
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Error: Not passed the password as first argument.");
                return;
            }

            Console.WriteLine("Waiting for windows. Press Ctrl+C to finish monitoring windows...");

            while (true)
            {
                try
                {
                    var window = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Windows Security"));
                    if (window == null)
                    {
                        await Task.Delay(1000);
                        continue;

                    }
                    await Task.Delay(1000);

                    Console.WriteLine("Located window");

                    var editControl = window.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "PIN"));
                    if (editControl == null)
                        continue;

                    editControl.SetFocus();
                    SendKeys.SendWait("^(a)");
                    await Task.Delay(250);
                    SendKeys.SendWait("{DELETE}");
                    await Task.Delay(250);
                    SendKeys.SendWait(args[0]);
                    await Task.Delay(250);

                    var okControl = window.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "OK"));
                    if (okControl == null)
                        continue;

                    Mouse.MoveTo(new System.Drawing.Point((int)okControl.GetClickablePoint().X, (int)okControl.GetClickablePoint().Y));
                    Mouse.Click(MouseButton.Left);

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
