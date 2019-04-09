using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListeLecture.Models
{
    public class FormulaireModificationModel
    {
        public Livre LivreEnCourDeModification { get; private set; }

        public FormulaireModificationModel(Livre livreEnCourDeModification)
        {
            LivreEnCourDeModification = livreEnCourDeModification;
        }
    }
}