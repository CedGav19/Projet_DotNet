using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainView;

namespace WPF1
{
    /// <summary>
    /// Logique d'interaction pour WindowObjectif.xaml
    /// </summary>
    public partial class WindowObjectif : Window
    {
        public WindowObjectif()
        {
            InitializeComponent();
            DataContext = Data.Instance;
        }

        private void ButtonAjouter_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.ajouterObjectif();
        }
    }
}
