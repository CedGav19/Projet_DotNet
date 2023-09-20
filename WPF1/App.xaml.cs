using MainView;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace WPF1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            if (File.Exists("Donnees.json"))
                Data.Instance = Serializers.DeserializeJson("Donnees.json");
        }
    }
}
