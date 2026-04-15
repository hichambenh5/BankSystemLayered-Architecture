using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsGlobal
    {
       public static ClsUser CurrentUser;
        private static string _RegistryPath = @"HKEY_CURRENT_USER\SOFTWARE\MyBankSystem";
        private static string _ValueName = "UserData";

        public static bool RememberUsernameAndPassword(string Username, string PasswordHash)
        {
            try
            {
               
                if (string.IsNullOrEmpty(Username))
                {
                    
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MyBankSystem", true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue(_ValueName, false);
                        }
                    }
                    return true;
                }

                
                string dataToSave = Username + "#||#" + PasswordHash;

                
                Registry.SetValue(_RegistryPath, _ValueName, dataToSave, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to registry: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string PasswordHash)
        {
            try
            {
                string line = Registry.GetValue(_RegistryPath, _ValueName, null) as string;

                if (!string.IsNullOrEmpty(line))
                {
                    string[] valueData = line.Split(new string[] { "#||#" }, StringSplitOptions.None);

                    if (valueData.Length == 2)
                    {
                        Username = valueData[0];
                        PasswordHash = valueData[1];
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    
}
}
