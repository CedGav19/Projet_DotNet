using MainView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using MaBibliotheque;
using System.ComponentModel;

namespace WPF1
{
    /// <summary>
    /// Logique d'interaction pour Pageconnection.xaml
    /// </summary>
    public partial class Pageconnection : Window
    {
        public Pageconnection()
        {
            InitializeComponent();
            //if (File.Exists("Donnees.json"))
            //    Data.Instance = Serializers.DeserializeJson("Donnees.json");

            username.Text = RegisteryAbonnees.ancienconnecte;
            DataContext = Data.Instance;
            
            string tmp =
                "Bienvenu sur notre application veuillez vous connecter , continuer en tant que invité \nou encore vous inscrire et rejoindre nos "
                + Data.Instance.ListAbonne.Count + " abonées"; 

            Description.Text = tmp;

            
        }

        public void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            string name = username.Text;
            string password = mdp.Password;
            bool trouve = false;

            foreach (var abonne in Data.Instance.ListAbonne)
            {
                if (name == abonne.nom && password == abonne.Motdepasse)
                {
                    trouve = true;
                    Data.Instance.AbonneConnected = abonne;
                    RegisteryAbonnees.ancienconnecte = Data.Instance.AbonneConnected.nom;
                    //  Serializers.SerializeJson(Data.Instance, "Donnees.json");
                    MainWindow W = new MainWindow(); // ici un constructeur d'initialisation et donc la serealization des donnees etc etc 
                    W.Show();
                    this.Close();
                    
                }
            }
            
            if(!trouve)
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            
        }

        private void ContInvite_Click(object sender, RoutedEventArgs e)
        {

            Data.Instance.AbonneConnected = new Utilisateur("invite", 0, 0);
            MainWindow W = new MainWindow();
            W.Show();
            this.Close();
        }

        private void SInscrire_Click(object sender, RoutedEventArgs e)
        {
            Inscription I = new Inscription();
            I.Show();
            this.Close();
        }
    }
}
