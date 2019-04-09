using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListeLecture.Models
{
    public class DetailModel
    {
        public Livre LivreCourant { get; private set; }
       
        public DetailModel ( Livre livreCourant)
        {
            LivreCourant = livreCourant;
        }
        
    }
    
}