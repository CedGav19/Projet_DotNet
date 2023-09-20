using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    public class Utilisateur : INotifyPropertyChanged
    {

        #region var et propriete
        private string _nom;
        private float _taille;
        private float _poids;
        private ObservableCollection<Aliment> _listeAlimentsConsomme = null;
        private ObservableCollection<Objectif> _listObjectifs = null;
        private ObservableCollection<Objectif> _listObjectifsRealise = null;

        public string nom
        {
            get { return _nom; }
            set
            {
                if (_nom == value) return;
                _nom = value;
            }
        }
       

        public float taille
        {
            get { return _taille; }
            set
            {
                if (_taille == value) return;
                _taille= value;
            }
        }
        public float poids
        {
            get { return _poids; }
            set
            {
                if (_poids == value) return;
                _poids = value;
            }
        }
        public float IMC
        {
            get
            {
                if (taille > 0)
                    return poids / (taille / 100 * taille / 100);
                else
                    return 0;
            }
        }

        public ObservableCollection<Aliment> ListAlimentsConsomme
        {
            get { return _listeAlimentsConsomme; }
            set
            {
                if (_listeAlimentsConsomme == value) return;
                _listeAlimentsConsomme = value;
                OnPropertyChanged();
            }
        }
        public float sommekcal
        {
            get
            {
                float tmp = 0;
                foreach (Aliment A in ListAlimentsConsomme)
                {
                    tmp += A.kcal;
                }
                return tmp;

            }

        }
        public float kcalRest
        {
            get
            {
                return 2000 - sommekcal;

            }

        }
        public float sommeproteine
        {
            get
            {
                float tmp = 0;
                foreach (Aliment A in ListAlimentsConsomme)
                {
                    tmp += A.proteine;
                }
                return tmp;

            }
        }
        public float proteineRest
        {
            get
            {
                return 150 - sommeproteine;

            }
        }

        public ObservableCollection<Objectif> ListObjectifs
        {
            get { return _listObjectifs; }
            set
            {
                if (_listObjectifs == value) return;
                _listObjectifs = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Objectif> ListObjectifsRealise
        {
            get { return _listObjectifsRealise; }
            set
            {
                if (_listObjectifsRealise == value) return;
                _listObjectifsRealise = value;
                OnPropertyChanged();
            }
        }
        #endregion



        #region constructeur
        public Utilisateur(string nom, float taille, float poids)
        {
            this.nom = nom;
            this.taille = taille;
            this.poids = poids;

            ListObjectifs = new ObservableCollection<Objectif>();
            ListAlimentsConsomme = new ObservableCollection<Aliment>();
            ListObjectifsRealise = new ObservableCollection<Objectif>();
        }
        public Utilisateur() : this("aucun",175,75)
        {}
        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
