using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListeLecture.Models
{
    public class ConfirmationLectureModel
    {
        public Livre LivreConfirmation { get; private set; }
       
        public ConfirmationLectureModel( Livre livreConfirmation)
        {
            LivreConfirmation = livreConfirmation;  
        }
    }
}