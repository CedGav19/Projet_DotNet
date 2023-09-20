using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaBibliotheque;
using MainView;
using System.IO;


namespace WPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //if (File.Exists("Donnees.json"))
            //    Data.Instance = Serializers.DeserializeJson("Donnees.json");
            DataContext = Data.Instance;
        }

        private void ButtonAjoutAliment_Click(object sender, RoutedEventArgs e)
        {
            Window1 W1 = new Window1();
            W1.Show(); 
        }

        private void ButtonSupprimerAliment_Click(object sender, RoutedEventArgs e)
        {
            Data.Instance.SupprimerAliment();
        }

        private void Click_Checkbox(object sender, RoutedEventArgs e)
        {
            Data.Instance.ValiderObjectif((sender as CheckBox).Content as Objectif);
        }

        private void ButtonAjouterObjectif_Click(object sender, RoutedEventArgs e)
        {
            WindowObjectif WO1 = new WindowObjectif();
            WO1.Show();
        }

        private void ButtonSupprimerObjectif_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Instance.ObjectifValideSelected == null)
            {
                MessageBox.Show("pas de selection");
            }
            else
            {
                Data.Instance.SupprimerObjectifsValide();
            }
         
        }

        private void ButtonAnnulerObjectif_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Instance.ObjectifValideSelected == null)
            {
                MessageBox.Show("pas de selection");
            }
            else
            {
                Data.Instance.annulerObjectifValide();
            }
        }

        private void Button_Sauvegarder(object sender, RoutedEventArgs e)
        {

            Serializers.SerializeJson(Data.Instance, "Donnees.json");
        }

        private void ReinitialiserAlimMange(object sender, RoutedEventArgs e)
        {
            Data.Instance.reinitialiserAlimMange();

        }

        private void Deconnecter_Click(object sender, RoutedEventArgs e)
        {
            Pageconnection P1 = new Pageconnection();
            P1.Show();
            this.Close();
        }
    }
}
