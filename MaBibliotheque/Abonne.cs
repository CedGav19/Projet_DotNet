using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    public class Abonne : Utilisateur
    {
        #region var et prop 
        private string _motdepasse;

        public string Motdepasse
        {
            get { return _motdepasse; }
            set
            {
                if (_motdepasse == value) return;
                _motdepasse = value;
            }
        }

        


        #endregion

        #region constructeur 
        public Abonne(string n, float t, float pds, string motdepasse) : base(n,t,pds)
        {
            Motdepasse=motdepasse;
        }
        public Abonne() : base() 
        {
            Motdepasse = "";
        }
        #endregion
    }
}
