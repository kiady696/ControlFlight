﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aiguilleur.Models;
using Aiguilleur.Connection;

namespace Aiguilleur
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.DropDownList1.Items.Add("hello");         
            if (this.DropDownList1.Items.Count > 0)
            {
                return; 
            }
          
            DBConnection dbc = new DBConnection();
            try
            {
                //MAKA NY LISTE AN AEROPORT REHETRA ATAO ANATINLE DROPDOWNLIST1
                //Manokatra connection keely
                dbc.OpenConnection();
                List<Aeroport> allAirports = Aeroport.getAirports(dbc);
                foreach(Aeroport a in allAirports)
                {
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
            string inputAirport = this.DropDownList1.SelectedItem.Value;
            
            Console.Write(inputAirport);
        }

        
    }
}