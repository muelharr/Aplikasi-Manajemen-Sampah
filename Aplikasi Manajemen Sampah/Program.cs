using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Aplikasi_Manajemen_Sampah
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}