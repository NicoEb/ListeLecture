using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ListeLecture.Controllers;


namespace ListeLecture.Models
{
    public class DataAccess
    {
        const string SqlConnectionString = @"Server=.\SQLExpress;Database=ListeLecture;Trusted_Connection=Yes";
        public static  bool RecupererLivreChoisit(int idLivre, out Livre detailModel)
        {
           
            SqlConnection firstSelect = new SqlConnection(SqlConnectionString);
            firstSelect.Open();
            SqlCommand selectLecteur =
                new SqlCommand("SELECT Titre, Auteur, Note, DateDebutLecture , DateFinLecture FROM Livre where ID = @idLivre", firstSelect);
            selectLecteur.Parameters.AddWithValue("@idLivre", idLivre);
            SqlDataReader dataReader = selectLecteur.ExecuteReader();

            if (dataReader.Read() )
            {

                string titrelivre = (string)dataReader["Titre"];
                string auteurlivre = (string)dataReader["Auteur"];
                int? noteLivre;
                if (dataReader.IsDBNull(2))
                {
                    noteLivre = null;
                }
                else
                {
                    noteLivre = (byte)dataReader["Note"];
                }
                DateTime dateDebutLivre = (DateTime)dataReader["DateDebutLecture"];
                DateTime? dateFinLecture;
                if (dataReader.IsDBNull(4))
                {
                    dateFinLecture = null;
                }
                else
                {
                    dateFinLecture = (DateTime)dataReader["DateFinLecture"];
                }

                detailModel = new Livre(titrelivre, auteurlivre, noteLivre, dateDebutLivre, dateFinLecture,idLivre);

                return true;
            }
            else
            {
                detailModel = null;
                return false;
            }

         
          
        }
        public static bool RecupererConfirmationLectureModel(int idLivre, out Livre detailModel)
        {

            SqlConnection firstSelect = new SqlConnection(SqlConnectionString);
            firstSelect.Open();
            SqlCommand selectLecteur =
                new SqlCommand("SELECT Titre, DateFinLecture FROM Livre where ID = @idLivre", firstSelect);
            selectLecteur.Parameters.AddWithValue("@idLivre", idLivre);
            SqlDataReader dataReader = selectLecteur.ExecuteReader();

            if (dataReader.Read())
            {

                string titrelivre = (string)dataReader["Titre"];
                
                
                DateTime dateFinLecture = (DateTime)dataReader["DateFinLecture"];
               

                detailModel = new Livre(titrelivre, dateFinLecture);

                return true;
            }
            else
            {
                detailModel = null;
                return false;
            }
        }
        public static void MettreAJourDateDeFinDeLecture(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    @"UPDATE Livre SET DateFinLecture = GETDATE() WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                command.ExecuteNonQuery();
            }
        }
        public static List<Livre> RecupererToutLesLivresCours()
        {
            List<Livre> resultats = new List<Livre>();
            SqlConnection livreCours = new SqlConnection(SqlConnectionString);
            livreCours.Open();
            SqlCommand selectLecteur =
               new SqlCommand("SELECT Titre, Auteur, Note, DateDebutLecture, DateFinLecture, ID  FROM Livre ", livreCours);
           
            
            SqlDataReader dataReader = selectLecteur.ExecuteReader();
            while (dataReader.Read())
            {
                int idLivre = (int)dataReader["ID"];
                string titrelivre = (string)dataReader["Titre"];
                string auteurlivre = (string)dataReader["Auteur"];
                int? noteLivre;
                if (dataReader.IsDBNull(2))
                {
                    noteLivre = null;
                }
                else
                {
                    noteLivre = (byte)dataReader["Note"];
                }
                DateTime dateDebutLivre = (DateTime)dataReader["DateDebutLecture"];
                DateTime? dateFinLecture = null;

                if (dataReader.IsDBNull(4))
                {
                    dateFinLecture = null;
                }
                else
                {
                    dateFinLecture = (DateTime)dataReader["DateFinLecture"];
                }


                Livre detailList = new Livre(titrelivre, auteurlivre, noteLivre, dateDebutLivre, dateFinLecture, idLivre);

                resultats.Add(detailList);
            }
            livreCours.Close();

            return resultats;
            
        }
        public static void CreationLivre(Livre nouveauLivre)
        {
           
                SqlConnection connection = new SqlConnection(SqlConnectionString);
                connection.Open();
                SqlCommand livreInsert =
                        new SqlCommand("INSERT INTO Livre (Titre, Auteur, Note, DateDebutLecture, DateFinLecture) " +
                        " VALUES (@titreLivre, @auteurLivre, @noteLivre, @dateDebutLivre, @dateFinLecture )", connection);
                livreInsert.Parameters.AddWithValue("@titreLivre", nouveauLivre.TitreLivre);
                livreInsert.Parameters.AddWithValue("@auteurLivre", nouveauLivre.AuteurLivre);
                livreInsert.Parameters.AddWithValue("@noteLivre", nouveauLivre.NoteLivre);
                livreInsert.Parameters.AddWithValue("@dateDebutLivre", nouveauLivre.DateDebutLivre);
                livreInsert.Parameters.AddWithValue("@dateFinLecture", nouveauLivre.DateFinLecture);


            livreInsert.ExecuteNonQuery();

                connection.Close();
           
        }
        public static bool RecupererIdLivreDuLivre(Livre model, out Livre detailModel)
        {

            SqlConnection firstSelect = new SqlConnection(SqlConnectionString);
            firstSelect.Open();
            SqlCommand selectIdLivre =
                new SqlCommand("SELECT TOP 1 ID FROM Livre WHERE Titre = @titreLivre AND Auteur = @auteurLivre ORDER BY ID DESC", firstSelect);
            selectIdLivre.Parameters.AddWithValue("@titreLivre", model.TitreLivre);
            selectIdLivre.Parameters.AddWithValue("@auteurLivre", model.AuteurLivre);
            SqlDataReader dataReader = selectIdLivre.ExecuteReader();

            if (dataReader.Read())
            {

                int idLivre = (int)dataReader["ID"];
                
                detailModel = new Livre(model.TitreLivre, model.AuteurLivre,model.NoteLivre, model.DateDebutLivre,model.DateFinLecture,idLivre);

                return true;
            }
            else
            {
                detailModel = null;
                return false;
            }
        }

        public static Livre ChargerDetailDepuisBDD(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT Titre, Auteur, Note, DateDebutLecture, DateFinLecture FROM Livre WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                SqlDataReader reader = command.ExecuteReader();

                //On avance sur la première ligne
                reader.Read();

                string titre = (string)reader["Titre"];
                string auteur = (string)reader["Auteur"];

                short? note;
                if (reader.IsDBNull(2))
                {
                    note = null;
                }
                else
                {
                    note = (byte)reader["Note"];
                }

                DateTime dateDebutLecture = (DateTime)reader["DateDebutLecture"];

                DateTime? dateFinLecture;
                if (reader.IsDBNull(4))
                {
                    dateFinLecture = null;
                }
                else
                {

                    dateFinLecture = (DateTime)reader["DateFinLecture"];
                }

                Livre model = new Livre(titre,auteur, note,dateDebutLecture,dateFinLecture,idLivre);
                return model;
            }
        }
    }
}