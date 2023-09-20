using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    public class Objectif

    {

        #region var et set/get

        private float _poidsSouhaite;
        private float _poidsDepart;
        private string _intitule;
        private DateTime _dateSouhaite;


        public float poidsSouhaite
        {
            get { return _poidsSouhaite; }
            set
            {
                if (_poidsSouhaite == value) return;
                _poidsSouhaite = value;

            }
        }

        public float poidsDepart
        {
            get { return _poidsDepart; }
            set
            {
                if (_poidsDepart == value) return;
                _poidsDepart = value;
            }
        }

        public string intitule
        {
            get { return _intitule; }
            set
            {
                if (_intitule == value) return;
                _intitule = value;
            }
        }

        public DateTime dateSouhaite
        {
            get { return _dateSouhaite; }
            set
            {
                if (_dateSouhaite == value) return;
                _dateSouhaite = value;
            }
        }

        #endregion


        #region constructeur

        public Objectif(string i, float pdsdep, float pdsvoulu, DateTime d)
        {
            intitule = i;
            poidsDepart = pdsdep;
            poidsSouhaite = pdsvoulu;
            dateSouhaite = d;
        }

        public Objectif() : this("aucun", 75, 75, new DateTime())
        {

        }

        #endregion

        #region methode

        public override string ToString()
        {
            return intitule + " " + dateSouhaite + " " + poidsSouhaite + "kg";
        }

        #endregion

    }
}
