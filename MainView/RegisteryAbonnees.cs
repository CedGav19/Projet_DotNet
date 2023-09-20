using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MaBibliotheque;

namespace MainView
{

    public static class RegisteryAbonnees   
    {
        private static readonly string RegistryKeyPath = "HEPL\\ExamenCSharp";

        public static string ancienconnecte
        {
            get => GetValueOrDefault();
            set => SetValue(value);
        }

        private static string GetValueOrDefault([CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (registryKey != null)
                {
                    var value = registryKey.GetValue(propertyName);
                    if (value != null )
                    {
                        return (string)value;
                    }
                }
            }

            return ""; // Valeur par défaut si la clé ou la valeur n'existent pas
        }

        private static void SetValue(string value, [CallerMemberName] string propertyName = "")
        {
            using (var registryKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                if (registryKey != null)
                {
                    registryKey.SetValue(propertyName, value);
                }
            }
        }
    }
}
