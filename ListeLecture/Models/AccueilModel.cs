using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListeLecture.Models
{
    public class AccueilModel
    {
        public List< Livre> LivreEnCours { get; private set; }
        public List<Livre> LivreLus { get; private set; }
        public int NombreTotalLinesLus { get; private set; }

        public AccueilModel(List<Livre> livreEnCours, List<Livre> livreLus ,int nombreTotalLinesLus)
        {
            LivreEnCours = livreEnCours;
            LivreLus = livreLus;
            NombreTotalLinesLus = nombreTotalLinesLus;
        }
    }
}