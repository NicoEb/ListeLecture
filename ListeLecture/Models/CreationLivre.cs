using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListeLecture.Models
{
    public class CreationLivre
    {
        public Livre NouveauLivre { get; private set; }

        public CreationLivre(Livre nouveauLivre)
        {
            NouveauLivre = nouveauLivre;
        }
    }
}