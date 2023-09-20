using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    public class Recette
    {
        private ObservableCollection<Aliment> aliments;

        public Recette()
        {
            aliments = new ObservableCollection<Aliment>();
        }

        public void AjouterAliment(Aliment aliment)
        {
            aliments.Add(aliment);
        }

        public ObservableCollection<Aliment> GetAliments()
        {
            return aliments;
        }

        public float GetKcaloriesTotales()
        {
            float totalKcal = 0;
            foreach (Aliment aliment in aliments)
            {
                totalKcal += aliment.kcal;
            }
            return totalKcal;
        }

        public float GetProteineTotale()
        {
            float totalProteine = 0;
            foreach (Aliment aliment in aliments)
            {
                totalProteine += aliment.proteine;
            }
            return totalProteine;
        }

        public float GetScoreMoyen()
        {
            float totalProteine = 0;
            int cpt=0; 
            foreach (Aliment aliment in aliments)
            {
                totalProteine += aliment.score;
                cpt++;
            }
            return totalProteine/cpt;
        }



    }
}
