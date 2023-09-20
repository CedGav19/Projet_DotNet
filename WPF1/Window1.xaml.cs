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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaBibliotheque;
using MainView;

namespace WPF1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // pour les evts passer un aliment en parametre
        public Window1()
        {
            InitializeComponent();
            DataContext = Data.Instance;
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.ajouterAliment();
        }
    }
}
