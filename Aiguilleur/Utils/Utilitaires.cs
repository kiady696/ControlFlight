using Aiguilleur.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aiguilleur.Utils
{
    public class Utilitaires
    {
        //Check if this piste is adequate for this Vol % length and temp
        public static bool checkPiste(VolPiste vp , Piste p)
        {
            if(vp.besoin >= p.longueur)
            {
                return false;
            }
            else
            {
                if (p.tempsMisyAvion == null)
                {
                    p.tempsMisyAvion = new List<Occupation>();
                    return true;

                }
                else
                {
                    foreach (Occupation o in p.tempsMisyAvion)
                    {
                        System.Diagnostics.Debug.WriteLine("vol :" + vp.id_Vol + " - " + vp.dateProbableArrivee + " - " + vp.fin_utilisation);
                        System.Diagnostics.Debug.WriteLine("Occupation :" + o.id_piste + " - " + o.debut_occupation + " - " + o.fin_occupation);
                        
                        IntervalleTemps intvol = new IntervalleTemps(vp.dateProbableArrivee, vp.fin_utilisation);
                        IntervalleTemps intOcc = new IntervalleTemps(o.debut_occupation, o.fin_occupation);
                        if (intvol.checkIfCrossWith(intOcc))
                        {
                            return false;
                        }

                    }
                }
            }
                

            return false;
             
        }

        public static bool checkPisteLongueur(VolPiste vp, Piste p)
        {
            if (vp.besoin >= p.longueur)
            {
                return false;
            }
            return true;
        }

                public static DateTime parseStringInputToDbDateTime(string dateInput,string dateFormatDb)
        {
            try
            {
                //dateFormatDb = "yyyy / MM / dd HH: mm: ss.fff";
                //DateTime res = Convert.ToDateTime(dateInput);
                
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime res = DateTime.ParseExact("05/09/2020", "yyyy-MM-dd h:m:s tt", provider);
                System.Diagnostics.Debug.WriteLine(res.ToString());
                return res;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static DateTime getToday()
        {
            DateTime today = DateTime.Today;
            return today;
        }

        public static void FillDDL<T>(DropDownList DDL, List<ListItem> list)
        {
            DDL.DataSource = list;
            DDL.DataBind();
            DDL.Items.Insert(0, list[0]);
            DDL.SelectedIndex = 0;
        }
    }
}