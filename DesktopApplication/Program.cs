using DesktopApplication;
using DesktopApplication.econtactClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;

internal static class Program
{
    public static IConfiguration Configuration { get; private set; }

    [STAThread]
    static void Main()
    {
        // Load configuration from appsettings.json
        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(Configuration));
    }
}
