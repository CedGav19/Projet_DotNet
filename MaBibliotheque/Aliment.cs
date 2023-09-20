using System.Runtime.CompilerServices;

namespace MaBibliotheque
{
    public class Aliment : EventArgs
    {
        #region var et propriete

        private string _nom;
        private float _kcal;
        private float _proteine;
        private string _image; 
        private int _score;

        public string nom
        {
            get { return _nom; }
            set
            {
                if (_nom == value) return;
                _nom = value;
            }
        }

        public float kcal
        {
            get { return _kcal; }
            set
            {
                if (_kcal == value) return;
                _kcal = value;
            }
        }

        public float proteine
        {
            get { return _proteine; }
            set
            {
                if (_proteine == value) return;
                _proteine = value;
            }
        }
        public int score
        {
            get { return _score; }
            set
            {
                if (_score == value) return;
                _score = value;
            }
        }

        public string image
        {
            get { return _image; }
            set
            {
                if (_image == value) return;
                _image = value;
            }
        }
        #endregion



        #region constructeur
        public  Aliment(string n, float k, float p,int s , string i )
        {
            nom = n; 
            kcal = k;
            proteine = p;
            image = i;
        }
       public Aliment(string n, float k)  :this(n,k,0,0,"lalal")
       {}
        public Aliment() : this("aucun",0,0,0, "lalala")
       {}
       #endregion






    }
}