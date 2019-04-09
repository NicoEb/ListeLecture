using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListeLecture.Models
{
    public class Livre
    {
        public int IdLivre { get; private set; }
        public string TitreLivre { get; private set; }
        public string AuteurLivre { get; private set; }
        public int? NoteLivre { get; private set; }
        public DateTime DateDebutLivre { get; private set; }
        public DateTime? DateFinLecture { get; private set; }
        public Livre(string titreLivre, string auteurLivre, int? noteLivre, DateTime dateDebutLivre, DateTime? dateFinLecture, int idLivre)
        {
            IdLivre = idLivre;
            TitreLivre = titreLivre;
            AuteurLivre = auteurLivre;
            NoteLivre = noteLivre;
            DateDebutLivre = dateDebutLivre;
            DateFinLecture = dateFinLecture;
        }
        public Livre(string titreLivre, DateTime dateFinLecture)
        {
            TitreLivre = titreLivre;
            DateFinLecture = dateFinLecture;
        }
        public Livre(string titreLivre, string auteurLivre, DateTime dateDebutLivre)
        {
            TitreLivre = titreLivre;
            AuteurLivre = auteurLivre;
            DateDebutLivre = dateDebutLivre;

        }
    }
}