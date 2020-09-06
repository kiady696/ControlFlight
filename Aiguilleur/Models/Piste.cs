using Aiguilleur.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;

namespace Aiguilleur.Models
{
    public class Piste
    {
        public Piste() { }
        public Piste(string id_piste)
        {
            this.id_piste = id_piste ?? throw new ArgumentNullException(nameof(id_piste));
        }

        public string id_piste { get; set; }
        public string id_aeroport { get; set; }
        public string num_piste { get; set; }
        public double longueur { get; set; } //en mètres
        public double Degagement { get; set; } //en heures

        public List<Occupation> tempsMisyAvion { get; set; }

        public void getOccupations(DBConnection dbc)
        {
            string sqlQuery = "SELECT * FROM Occupation WHERE Id_Piste='" + this.id_piste + "' ORDER BY Debut_Occupation ASC "; //APIANA ENTRE DEUX DATES FA LASA ALAINY DAHOLO NY ATRAMZAY
            System.Diagnostics.Debug.WriteLine(sqlQuery);
            using (IDbConnection db = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\KIADY\Documents\S6\Tahina - projets S6\C#\Aiguilleur\Aiguilleur\App_Data\aiguilleur.mdf;Integrated Security=True"))
            {
                db.Open();
                this.tempsMisyAvion = db.Query<Occupation>(sqlQuery).ToList();
                //System.Diagnostics.Debug.WriteLine("TEMPS MISY AVION 1 :" + tempsMisyAvion[0].debut_occupation);
                db.Close();
            }
        }



    }
}