using System.Management;
using System.Windows;

namespace ウマ娘プリティーダービー
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            {
                ManagementObjectCollection mbsList = null;
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
                mbsList = mbs.Get();
                string id1 = "";
                foreach (ManagementObject mo in mbsList)
                {
                    id1 = mo["ProcessorID"].ToString();
                }
                {
                    Microsoft.Win32.RegistryKey regkey =
                    Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\HWID");
                    regkey.SetValue("HWID", id1);
                }
            }
            {
                Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                regkey.SetValue("NoClose", 1);
            }
            {
                Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\Winmgmt", true);
                regkey.SetValue("ImagePath", "Luna.#9802",
                Microsoft.Win32.RegistryValueKind.ExpandString);
            }          
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            
                Microsoft.Win32.RegistryKey regkey =
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                regkey.SetValue("NoClose", 0);
            
            
                Microsoft.Win32.RegistryKey regkey1 =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\Winmgmt", true);
                regkey1.SetValue("ImagePath", "%systemroot%\\system32\\svchost.exe -k netsvcs -p",
                Microsoft.Win32.RegistryValueKind.ExpandString);
            
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {

            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string HWID = "";
            foreach (ManagementObject mo in mbsList)
            {
                HWID = mo["ProcessorID"].ToString();
            }

            Microsoft.Win32.RegistryKey regkey =
            Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\HWID", false);
            string stringValue = (string)regkey.GetValue("HWID");


            if (HWID == stringValue)
            {
                MessageBox.Show("Not hidden.", "HWID Hider", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Hidden.", "HWID Hider", MessageBoxButton.OK);
            }
        }
    }
}
