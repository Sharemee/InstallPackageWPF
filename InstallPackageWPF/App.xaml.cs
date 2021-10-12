using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;

namespace InstallPackageWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool createdNew;
            string mutexName = "InstallPackageWPF";
            Mutex singleInstanceWatcher = new Mutex(false, mutexName, out createdNew);
            if (!createdNew)
            {
                Environment.Exit(-1);
            }
            Process[] p = Process.GetProcessesByName("MusicTeachingWindow");
            if (p != null && p.Count() > 0)
            {
                MessageBox.Show("请退出正在运行的“音乐教学客户端”程序");
                Environment.Exit(0);
            }
        }
    }
}
