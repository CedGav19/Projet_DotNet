using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    public class PlanAlimentaire
    {
        #region var et prop
        private string _intitule;
        private int _kcal; // int que on utilsera comme un pourcentage
        private int _proteine;

        public string intitule
        {
            get { return _intitule; }
            set
            {
                if (_intitule == value) return;
                _intitule = value;
            }
        }

        public int kcal
        {
            get { return _kcal; }
            set
            {
                if (_kcal == value) return;
                _kcal = value;
            }
        }
   

        public int proteine
        {
            get { return _proteine; }
            set
            {
                if (_proteine == value) return;
                _proteine = value;
            }
        }
#endregion

    }
}
