using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Softphone
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
      {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
      start: try
          {
              Application.Run(new MainForm());
          }
          catch { }
    }

    static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        
    }
  }
}