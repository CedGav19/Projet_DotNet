using MainView;
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
using System.Xml.Linq;
using MaBibliotheque;
using System.IO;
namespace WPF1
{
    
    public partial class Inscription : Window
    {
        public Inscription()
        {
        //    if (File.Exists("Donnees.json"))
        //        Data.Instance = Serializers.DeserializeJson("Donnees.json");
            InitializeComponent();
        }

        private void SInscrire_Click(object sender, RoutedEventArgs e)
        {
            string name = username.Text;
            string password = mdp.Password;
            float pds  =  float.Parse(  Poids.Text);
            int t =   int.Parse(Taille.Text);
          
            bool trouve = false;

            foreach (var abonne in Data.Instance.ListAbonne)
            {
                if (name == abonne.nom )
                {
                    trouve = true;
                    MessageBox.Show("Nom d'utilisateur deja utilisé");
                   
                }
            }
            // Vérifier si le nom d'utilisateur et le mot de passe sont corrects

            if (!trouve)
            {
                 Abonne A = new Abonne(name,t,pds,password);
                Data.Instance.AjouterAbonne(A);
                Data.Instance.AbonneConnected = A;

                RegisteryAbonnees.ancienconnecte = Data.Instance.AbonneConnected.nom;
                //  Serializers.SerializeJson(Data.Instance, "Donnees.json");
                MainWindow W = new MainWindow();
                W.Show();
                this.Close();
            }
        }
    }
}
