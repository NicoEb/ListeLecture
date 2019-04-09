using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListeLecture.Models;
using System.Data.SqlClient;



namespace ListeLecture.Controllers
{
    public class LivresController : Controller
    {
        // GET: Livres
        public ActionResult Accueil()
        {
            List<Livre> livreCours = DataAccess.RecupererToutLesLivresCours();           
            List<Livre> livreEnCours = new List<Livre>();
            List<Livre> livreLus = new List<Livre>();
            foreach (var livreCourant in livreCours)
            {
                if( livreCourant.DateFinLecture is null)
                {
                    livreEnCours.Add(livreCourant);
                }
                else
                {
                    livreLus.Add(livreCourant);
                }
            }
            int nombreTotalLinesLus = livreLus.Count;
            AccueilModel model = new AccueilModel(livreEnCours, livreLus,nombreTotalLinesLus);

            return View(model);
        }
        public ActionResult Detail(int idLivre )
        {
           
            if (DataAccess.RecupererLivreChoisit(idLivre, out Livre model))
            {
                DetailModel livreCourant = new DetailModel(model);               
                return View(livreCourant);
            }
            else
            {
                string messageErreur = "Probleme base de donnée en recuperer Livre detail";
                return RedirectToAction("Erreur", new { messageErreur = messageErreur });
                
            }
           
           
        }
        public ActionResult Erreur(string messageErreur)
        {
            return View();
        }
        public ActionResult TerminerLivre(int idLivre)
        {
            DataAccess.MettreAJourDateDeFinDeLecture(idLivre);
            return RedirectToAction("ConfirmationLecture", new { idLivre = idLivre });
        }
        public ActionResult ConfirmationLecture(int idLivre)
        {

           
            if (DataAccess.RecupererConfirmationLectureModel(idLivre, out Livre model))
            {
                ConfirmationLectureModel livreConfirme = new ConfirmationLectureModel(model);               
                return View(livreConfirme);
            }
            else
            {
                string messageErreur = "Probleme base de donnée en lecture Livre";
                return RedirectToAction("Erreur", new { messageErreur = messageErreur} );
            }
            
        }
        public ActionResult Notation()
        {
            return View();
        }
        public ActionResult Creation()
        {
            return View();
        }
        public ActionResult SubmitCreationLivre(string titre, string auteur)
        {
            Livre model = new Livre(titre, auteur,DateTime.Now);
            CreationLivre nouveauLivre = new CreationLivre(model);
            DataAccess.CreationLivre(model);
           

            if (DataAccess.RecupererIdLivreDuLivre(model, out Livre Idmodel))
            {
                return RedirectToAction("ConfirmationCreation", new { idLivre = Idmodel.IdLivre });
                
            }
            else
            {
                string messageErreur = "Probleme en recuperant Id du Livre";
                return RedirectToAction("Erreur", new { messageErreur = messageErreur });
            }
           
            
        }
        public ActionResult ConfirmationCreation(int idLivre )
        {           
            return View();
        }

        public ActionResult AfficherFormulaireModificationLivre(int idLivre)
        {
            Livre livreCourant = DataAccess.ChargerDetailDepuisBDD(idLivre);
            return View();
        }


    }
}