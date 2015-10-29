using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Iterative.Tools.RunAs
{
    internal static class ConfigurationHelper
    {
        private static readonly string RootRegistryKey = "Software\\Iterative\\RunAs";                

        internal static IEnumerable<Guid> GetAvailableRunAsIds()
        {
            return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ConfigurationHelper.RootRegistryKey, true).GetSubKeyNames().Select(b=>Guid.Parse(b));
        }

        internal static bool ReadConfiguration(string configurationName)
        {
            bool returnValue = false;
            bool.TryParse(ConfigurationHelper.ReadStringConfiguration(configurationName), out returnValue);

            return returnValue;
        }

        internal static string ReadStringConfiguration(string configurationName, string defaultValue = "")
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ConfigurationHelper.RootRegistryKey, false);
            if (key == null)
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ConfigurationHelper.RootRegistryKey);

            return (string)key.GetValue(configurationName, defaultValue);
        }

        internal static void SaveConfiguration(string configurationName, bool value)
        {
            ConfigurationHelper.SaveConfiguration(configurationName, value.ToString(), false);
            typeof(Configuration).GetProperty(configurationName).SetValue(Configuration.Instance, value, null);
        }

        internal static void SaveConfiguration(string configurationName, string value, bool setConfigurationInstance = true)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ConfigurationHelper.RootRegistryKey, true);
            if (key == null)
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ConfigurationHelper.RootRegistryKey);

            key.SetValue(configurationName, value);
            key.Close();
            if (setConfigurationInstance)
            {
                object propertyValue = value;
                PropertyInfo property = typeof(Configuration).GetProperty(configurationName);
                if (property.PropertyType.IsEnum)
                    propertyValue = Enum.Parse(property.PropertyType, value);

                property.SetValue(Configuration.Instance, propertyValue, null);
            }
        }
    }
}
