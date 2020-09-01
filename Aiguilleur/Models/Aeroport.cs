using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Aiguilleur.Connection;
using Dapper;

namespace Aiguilleur.Models
{
    public class Aeroport
    {
        public string idAeroport { get; set; }
        public string codeAeroport { get; set; }
        public string ville { get; set; }

        public List<Vol> vols; //tous les vols entrants/sortants de l'aeroport

        public Aeroport(string idAeroport) //constructeur test 
        {
            this.idAeroport = idAeroport ?? throw new ArgumentNullException(nameof(idAeroport));
        }

        public List<Vol> getVols()
        {
            return this.vols;
        }

        public void getAllFlightsAirport(DBConnection dbc)
        {
            string sqlQuery = "SELECT * FROM VOL WHERE Id_Aeroport_Arrivee ='" + this.idAeroport + "' OR ID_Aeroport_Depart ='" + this.idAeroport +"'" ;
            using (SqlConnection connection = dbc.getCon())
            {
                this.vols = connection.Query<Vol>(sqlQuery).ToList();
            }
            
            
        }

    }
}