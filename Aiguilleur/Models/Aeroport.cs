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
        public string id_aeroport { get; set; }
        public string code_aeroport { get; set; }
        public string ville { get; set; }

        public List<Vol> vols; //tous les vols entrants/sortants de l'aeroport

        public Aeroport(string idAeroport)  //constructeur test 
        {
            this.id_aeroport = idAeroport ?? throw new ArgumentNullException(nameof(idAeroport));
        }

        public Aeroport(string id_aeroport, string code_aeroport, string ville) : this(id_aeroport)
        {
            this.code_aeroport = code_aeroport ?? throw new ArgumentNullException(nameof(code_aeroport));
            this.ville = ville ?? throw new ArgumentNullException(nameof(ville));
        }

        public List<Vol> getVols()
        {
            return this.vols;
        }

        public void getAllFlightsAirport(DBConnection dbc)
        {
            string sqlQuery = "SELECT * FROM VOL WHERE Id_Aeroport_Arrivee ='" + this.id_aeroport + "' OR ID_Aeroport_Depart ='" + this.id_aeroport +"'" ;
            using (SqlConnection connection = dbc.getCon())
            {
                this.vols = connection.Query<Vol>(sqlQuery).ToList();
            }
            
            
        }

        public static List<Aeroport> getAirports(DBConnection dbc)
        {
            string query = "SELECT * FROM AEROPORT ";
            List<Aeroport> res = null;
            using (SqlConnection connection = dbc.getCon())
            {
                res = connection.Query<Aeroport>(query).ToList();
            }
            return res;
        }

    }
}