using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using MaBibliotheque;
using System.IO;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.FileIO;

namespace MainView
{
    [Serializable]
    public class Data : INotifyPropertyChanged 
    {

        #region variable   et proprietées
       
        private ObservableCollection<Abonne> _listAbonnes = null;
        private static Data _instance = new Data();
        private Objectif _objectifValideSelected;

        private Objectif _nvObjectif;
        private Aliment _alimentCBSelected;
        private Aliment _alimentConsommeLVSelected;
         
         private Utilisateur _abonneConnected;
         private ObservableCollection<Aliment> _listAliments = null;

        public static Data Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                if (_instance == value) return;
                _instance = value;
                
            }
        }



        public ObservableCollection<Aliment> ListAliments
        {
            get { return _listAliments; }
            set
            {
                if (_listAliments == value) return;
                _listAliments = value;
                OnPropertyChanged();
            }
        }

     
        public ObservableCollection<Abonne> ListAbonne
        {
            get { return _listAbonnes; }
            set
            {
                if (_listAbonnes == value) return;
                _listAbonnes = value;
                OnPropertyChanged();
            }
        }

       

        public Aliment AlimentCBSelected
        {
            get { return _alimentCBSelected; }
            set
            {
                if (_alimentCBSelected == value) return;
                _alimentCBSelected = value;
                OnPropertyChanged();
            }
        }
        public Aliment AlimentConsommeLVSelected
        {
            get { return _alimentConsommeLVSelected; }
            set
            {
                if (_alimentConsommeLVSelected == value) return;
                _alimentConsommeLVSelected = value;
                OnPropertyChanged();
            }
        }
        public Utilisateur AbonneConnected
        {
            get { return _abonneConnected; }
            set
            {
                if (_abonneConnected == value) return;
                _abonneConnected = value;
                OnPropertyChanged();
            }
        }

        public Objectif NvObjectif
        {
            get { return _nvObjectif; }
            set
            {
                if (_nvObjectif == value) return;
                _nvObjectif = value;
                OnPropertyChanged();
            }
        }



        public Objectif ObjectifValideSelected
         {
                get { return _objectifValideSelected; }
                set
                {
                    if (_objectifValideSelected == value) return ;
                    _objectifValideSelected = value;
                    OnPropertyChanged();
                }
         }




        #endregion

        public Data()
        {
            ListAliments = new ObservableCollection<Aliment>();
            ListAbonne = new ObservableCollection<Abonne>();
            AbonneConnected = new Abonne();
            
            ObjectifValideSelected = null; 
            NvObjectif = new Objectif();

            ListAbonne.Add(new Abonne());
          
          loadAliments();
          AlimentCBSelected = ListAliments[0];
        }

        #region methode

        public void ajouterAliment()
        {

            Data.Instance.AbonneConnected.ListAlimentsConsomme.Add(Data.Instance.AlimentCBSelected);
            OnPropertyChanged("AbonneConnected");
        }
        public void SupprimerAliment()
        {

            Data.Instance.AbonneConnected.ListAlimentsConsomme.Remove(Data.Instance.AlimentConsommeLVSelected);
            OnPropertyChanged("AbonneConnected");
           
        }

        public void ajouterObjectif()
        {
            Instance.NvObjectif.poidsDepart = Instance.AbonneConnected.poids;

            Objectif tmpObjectif = new Objectif(Instance.NvObjectif.intitule, Instance.AbonneConnected.poids, Instance.NvObjectif.poidsSouhaite, Instance.NvObjectif.dateSouhaite);
            Data.Instance.AbonneConnected.ListObjectifs.Add(tmpObjectif);
            OnPropertyChanged("AbonneConnected");
        }
        public void ValiderObjectif(Objectif O)
        {
            //probleme on supprime le premier et on ajoute le dernier
            Instance.AbonneConnected.ListObjectifs.Remove(O);
            Instance.AbonneConnected.ListObjectifsRealise.Add(O);
            OnPropertyChanged("AbonneConnected");
        }
        public void annulerObjectifValide()
        {
            Data.Instance.AbonneConnected.ListObjectifs.Add(Data.Instance.ObjectifValideSelected);

            Data.Instance.AbonneConnected.ListObjectifsRealise.Remove(Data.Instance.ObjectifValideSelected);
            OnPropertyChanged("AbonneConnected");
        }

        public void SupprimerObjectifsValide()
        {
            
            Data.Instance.AbonneConnected.ListObjectifsRealise.Remove(Data.Instance.ObjectifValideSelected);
            OnPropertyChanged("AbonneConnected");
        }

        public void AjouterAbonne(Abonne A)
        {
            Data.Instance.ListAbonne.Add(A);

            Serializers.SerializeJson(Data.Instance, "Donnees.json");
        }

        public void reinitialiserAlimMange()
        {
            AbonneConnected.ListAlimentsConsomme.Clear();
            OnPropertyChanged("AbonneConnected");
        }


        public void loadAliments()
        {
            ObservableCollection<Aliment> tmpAliments = new ObservableCollection<Aliment>();
            string csvFilePath = "Aliments.csv";


            var reader = new StreamReader(csvFilePath);
            var csvParser = new TextFieldParser(reader);

            csvParser.SetDelimiters(";");

            // Ignorer la première ligne si elle contient des en-têtes
            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                string[] fields = csvParser.ReadFields();
                Aliment A = new Aliment();
                A.nom = fields[0];
                    A.kcal =float.Parse( fields[1]);
                    A.proteine = float.Parse(fields[2]);
                    A.score = int.Parse(fields[3]);
                   A.image  = "C:/Users/user/Desktop/bac2/labo-final-CedGav19/WPF1/image/" + fields[0]+".jpg";
                
                    
               ListAliments.Add(A);

            }
          
        }



        #endregion


        #region InotifyProportychanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
