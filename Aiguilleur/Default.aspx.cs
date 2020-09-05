using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aiguilleur.Models;
using Aiguilleur.Connection;
using System.Data;
using Aiguilleur.Utils;

namespace Aiguilleur
{
    public partial class _Default : Page
    {
        public Aeroport aeroportGlobal = new Aeroport("AE1");
        public static List<Vol> listeVolsGlobale = new List<Vol>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.DropDownList1.Items.Add("hello");         
            /*if (Session["IdAeroport"] != null)
            {
                return; 
            }*/

            DBConnection dbc = new DBConnection();
            try
            {
                //MAKA NY LISTE AN AEROPORT REHETRA ATAO ANATINLE DROPDOWNLIST1
                //Manokatra connection keely
                dbc.OpenConnection();
                List<Aeroport> allAirports = Aeroport.getAirports(dbc);
                foreach(Aeroport a in allAirports)
                {
                    this.DropDownList1.Items.Add(a.villeAeroport+"             "+"["+a.id_aeroport+"]");                
                }
                /*foreach (Aeroport a in allAirports)
                {
                    this.DropDownList1.Va
                    this.DropDownList1.Items.Add(a.ville+' '+a.code_aeroport);
                }
                /*string input = this.TextBox1.Text;
                Aeroport currentAirport = new Aeroport("AE3");
                
                dbc.OpenConnection();
                currentAirport.getAllFlightsAirport(dbc);
                List<Vol> vols = currentAirport.getVols();
                //TableRow row = new TableRow();
                foreach(Vol v in vols)
                {
                    //TableCell cell = new TableCell();
                    //cell.Text = v.idVol;
                    this.DropDownList1.Items.Add(v.id_Vol);
                }*/

                
            }catch(Exception exc)
            {
                throw exc;
            }
            finally
            {
                dbc.CloseConnection();
            }

        }

        protected void GenerateListVolsOfAirport(object sender, EventArgs e)
        {
            string inputIdAirport = this.DropDownList1.Text.Substring(this.DropDownList1.Text.IndexOf('[') + 1); ; //Ilay idAeroport mila aMBOARINA FA TSY METY
            inputIdAirport = inputIdAirport.Remove(inputIdAirport.Length - 1);
            Session["IdAeroport"] = inputIdAirport;
            this.Panel1.Visible = true;
            DateTime dateDebut = new DateTime(1999, 1, 1, 0, 0, 0);
            DateTime dateFin = new DateTime(1999, 1, 1, 0, 0, 0);
            // MGET ANLE DATE DEBUT sy DATE FIN eto
            //exception date par défaut
            if (TextBox1.Text == String.Empty)
            {
                //ATAO 1999-01-01 00:00:0000
                dateDebut = new DateTime(1999,1,1,0,0,0);
            }
            else
            {
                dateDebut = Convert.ToDateTime(TextBox1.Text);
            }
            if(TextBox2.Text == String.Empty)
            {
                dateFin = new DateTime(1999,1,1,0,0,0);
            }
            else
            {
                dateFin = Convert.ToDateTime(TextBox2.Text);
            }

            DBConnection dbc = new DBConnection();
            try
            {
                dbc.OpenConnection();
                Aeroport currentAirport = new Aeroport(inputIdAirport);
                currentAirport.getAllFlightsAirport(dbc, dateDebut, dateFin);
                //filtrena
                currentAirport.getAction();
                currentAirport.getVolAt(dateDebut, dateFin);
                
                //global list and airport for reuse of proposer
                //aeroportGlobal = new Aeroport(currentAirport.id_aeroport);
                /*for (int i = 0 ; i < currentAirport.vols.Count ; i++)
                {
                    listeVolsGlobale.Add(currentAirport.vols[i]);
                }*/
                listeVolsGlobale = currentAirport.vols.ToList();
                

                //bind this.vols to the gridview
                ListeVols.DataSource = currentAirport.vols;
                ListeVols.DataBind();

                //tests 
                //this.TextBox3.Text = inputIdAirport;
                //this.TextBox3.Text = dateFin.ToString();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbc.CloseConnection();
            }
            

            // mamerina tableau ana Vol[] { string NomVol , string action(decoller/atterrir) , DateTime Temps(datedepart/date probable atter) , string Etat } (apiana anreo ny attributs an vol)
        }

        protected void Proposer(object sender, EventArgs e)
        {
            DBConnection dbc = new DBConnection();
            try
            {
                dbc.OpenConnection();

                string inputIdAirport = this.DropDownList1.Text.Substring(this.DropDownList1.Text.IndexOf('[') + 1); ; //Ilay idAeroport mila aMBOARINA FA TSY METY
                inputIdAirport = inputIdAirport.Remove(inputIdAirport.Length - 1);

                aeroportGlobal = new Aeroport(inputIdAirport);
                aeroportGlobal.getPistes(dbc); //azo ny longueurs_pistes sy ny temps de degagements
                                               //Soloina ny ao anatinle GridView : soloina liste ana VolPiste 

                //null foana ilay listeVolsGlobale
                ListeVols.DataSource = Vol.getPisteDistance(dbc, listeVolsGlobale, this.aeroportGlobal); //ilay liste vols entre deux dates sy ilay aeroport


                ListeVols.DataBind();

                //test
                //ListeVols.DataSource = aeroportGlobal.pistes;
                //ListeVols.DataBind();

            }
            
            finally
            {
                dbc.CloseConnection();
            }
            
        }
    }
}